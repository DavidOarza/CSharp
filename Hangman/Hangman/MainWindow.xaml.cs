using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Hangman
{
    public partial class MainWindow : Window
    {
        private Game Hangman { get; set; }
        private List<Button> btn { get; set; }
        private List<Label> lbl { get; set; }
        private Image StageImage { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            lbl = new List<Label>();
            btn = new List<Button>();
            CreateNewGameBtn();
        }

        private void CitiesBtnClick(object sender, RoutedEventArgs e)
        {
            string[] words = System.IO.File.ReadAllLines("../../Cities.txt");
            InitializeGameField(words[new Random().Next(0, words.Length)]);
        }

        private void CarsBtnClick(object sender, RoutedEventArgs e)
        {
            string[] words = System.IO.File.ReadAllLines("../../Cars.txt");
            InitializeGameField(words[new Random().Next(0, words.Length)]);
        }

        private void CharacterBtnClick(object sender, RoutedEventArgs e)
        {
            int[] temp = Hangman.GetChar((sender as Button).Content.ToString()[0]);

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == 1)
                {
                    lbl[i].Content = Hangman.Word[i];
                }
            }

            StageImage.Source = Hangman.GetStageImage();

            if (lbl.Count(l => l.Content == null) == 0)
            {
                GameOver("Congratulations! You Won!");
            }
            else if (Hangman.IsGameOver())
            {
                GameOver("Game Over! You Lost!");
            }
            else
            {
                (sender as Button).IsEnabled = false;
            }
        }

        private void GameOver(string message)
        {
            MessageBox.Show(message);
            btn.ForEach(b => b.IsEnabled = false);
        }

        private void InitializeGameField(string word)
        {
            Hangman = new Game(word);

            lbl.Clear();
            btn.Clear();
            GameGrid.Children.Clear();

            CreateImage();
            StageImage.Source = Hangman.GetStageImage();

            CreateNewGameBtn();
            CreateCharBtn(Hangman.Alphabet);
            CreateCharLbl(Hangman.Lenght);
        }

        private void CreateNewGameBtn()
        {
            Button btnCity = new Button();
            btnCity.VerticalAlignment = VerticalAlignment.Center;
            btnCity.HorizontalAlignment = HorizontalAlignment.Left;
            btnCity.Width = 150;
            btnCity.Height = 35;

            btnCity.Content = "Cities";
            btnCity.Click += new RoutedEventHandler(CitiesBtnClick);

            Button btnCar = new Button();
            btnCar.VerticalAlignment = VerticalAlignment.Center;
            btnCar.HorizontalAlignment = HorizontalAlignment.Right;
            btnCar.Width = 150;
            btnCar.Height = 35;

            btnCar.Content = "Cars";
            btnCar.Click += new RoutedEventHandler(CarsBtnClick);

            GameGrid.Children.Add(btnCity);
            GameGrid.Children.Add(btnCar);
        }

        private void CreateImage()
        {
            StageImage = new Image();

            StageImage.Name = "StageImage";
            StageImage.VerticalAlignment = VerticalAlignment.Center;
            StageImage.HorizontalAlignment = HorizontalAlignment.Center;
            StageImage.Width = 150;
            StageImage.Height = 150;

            GameGrid.Children.Add(StageImage);
        }

        private void CreateCharLbl(int lenght)
        {
            for (int i = 0; i < lenght; i++)
            {
                Label lbl = new Label();
                lbl.FontSize = 20;
                lbl.HorizontalContentAlignment = HorizontalAlignment.Center;
                lbl.VerticalContentAlignment = VerticalAlignment.Center;
                lbl.BorderThickness = new Thickness(1, 1, 1, 1);
                lbl.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x2D, 0x2D, 0x30));
                lbl.Height = lbl.Width = 38;
                lbl.HorizontalAlignment = HorizontalAlignment.Left;
                lbl.VerticalAlignment = VerticalAlignment.Top;

                lbl.Name = "Character" + i.ToString();

                lbl.Margin = new Thickness(i * lbl.Width, 0d, 0d, 0d);

                this.lbl.Add(lbl);

                GameGrid.Children.Add(lbl);
            }
        }

        private void CreateCharBtn(char[] alph)
        {
            double bot = 0;
            int count = 0;
            for (int i = 0; i < alph.Length; i++, count++)
            {
                Button btn = new Button();
                btn.FontSize = 20;
                btn.HorizontalContentAlignment = HorizontalAlignment.Center;
                btn.VerticalContentAlignment = VerticalAlignment.Center;
                btn.Height = btn.Width = 38;
                btn.HorizontalAlignment = HorizontalAlignment.Left;
                btn.VerticalAlignment = VerticalAlignment.Bottom;

                btn.Content = alph[i].ToString();

                if ((count + 1) * btn.Width > GameGrid.Width)
                {
                    count = 0;
                    bot += btn.Height;
                }

                btn.Margin = new Thickness(count * btn.Width, 0, 0, bot);
                btn.Click += new RoutedEventHandler(CharacterBtnClick);

                this.btn.Add(btn);

                GameGrid.Children.Add(btn);
            }
        }
    }
}
