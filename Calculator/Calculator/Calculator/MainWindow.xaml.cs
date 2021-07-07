using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        long nr1 = 0;
        long nr2 = 0;
        string operation = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        public long ReturnNumber(long btnNumber)
        {
            if (operation == "")
            {
                nr1 = nr1 * 10 + btnNumber;
                return nr1;
            }
            else
            {
                nr2 = nr2 * 10 + btnNumber;
                return nr2;
            }
        }

        private void btnZero_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = ReturnNumber(0).ToString();

        }

        private void btnOne_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = ReturnNumber(1).ToString();

        }

        private void btnTwo_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = ReturnNumber(2).ToString();
        }

        private void btnThree_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = ReturnNumber(3).ToString();
        }

        private void btnFour_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = ReturnNumber(4).ToString();
        }

        private void btnFive_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = ReturnNumber(5).ToString();
        }

        private void btnSix_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = ReturnNumber(6).ToString();
        }

        private void btnSeven_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = ReturnNumber(7).ToString();
        }

        private void btnEight_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = ReturnNumber(8).ToString();
        }

        private void btnNine_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = ReturnNumber(9).ToString();
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            operation = "+";
            txtDisplay.Text = "0";
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            operation = "-";
            txtDisplay.Text = "0";
        }

        private void btnTimes_Click(object sender, RoutedEventArgs e)
        {
            operation = "*";
            txtDisplay.Text = "0";
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            operation = "/";
            txtDisplay.Text = "0";
        }

        private void btnSqr_Click(object sender, RoutedEventArgs e)
        {
            operation = "SQR";
            nr2 = nr1;
            txtDisplay.Text = (nr1 * nr2).ToString();
            nr1 = nr1 * nr2;
            nr2 = 0;
            operation = "";
        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            switch(operation)
            {
                case "+":
                    txtDisplay.Text = (nr1 + nr2).ToString();
                    nr1 = nr1 + nr2;
                    nr2 = 0;
                    operation = "";
                    break;

                case "-":
                    txtDisplay.Text = (nr1 - nr2).ToString();
                    nr1 = nr1 - nr2;
                    nr2 = 0;
                    operation = "";
                    break;

                case "*":
                    txtDisplay.Text = (nr1 * nr2).ToString();
                    nr1 = nr1 * nr2;
                    nr2 = 0;
                    operation = "";
                    break;

                case "/":
                    if (nr2 == 0)
                        txtDisplay.Text = "Can't divide by 0";
                    else
                    {
                        txtDisplay.Text = (nr1 / nr2).ToString();
                        nr1 = nr1 / nr2;
                        nr2 = 0;
                        operation = "";
                    }
                    break;
            }
        }

        private void btnClearEntry_Click(object sender, RoutedEventArgs e)
        {
            if(operation == "")
                nr1 = 0;
            else
                nr2 = 0;

            txtDisplay.Text = "0";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            nr1 = 0;
            nr2 = 0;
            operation = "";
            txtDisplay.Text = "0";
        }

        private void btnBackspace_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                nr1 = (nr1 / 10);
                txtDisplay.Text = nr1.ToString();
            }
            else
            {
                nr2 = (nr2 / 10);
                txtDisplay.Text = nr2.ToString();
            }
        }
    }
}
