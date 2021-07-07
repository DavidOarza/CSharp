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

namespace Tema3MVP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Categorie> categorii = new List<Categorie>();
        List<Alergen> alergeni = new List<Alergen>();
        List<Preparat> preparate = new List<Preparat>();
        public MainWindow()
        {
            InitializeComponent();

            DataAccess db = new DataAccess();
            categorii = db.GetCategorii();
            foreach(Categorie c in categorii)
            {
                cmbCategorii.Items.Add(c.Denumire);
            }
        }

        private void cmbCategorii_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataAccess db = new DataAccess();
            preparate = db.GetPreparate(cmbCategorii.SelectedItem.ToString());
            lstMeniu.ItemsSource = preparate;
            lstMeniu.DisplayMemberPath = "InfoPreparat";
        }

        private void btnInapoi_Click(object sender, RoutedEventArgs e)
        {
            StartingWindow start = new StartingWindow();
            start.Show();
            Close();
        }

        private void lstMeniu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstAlergeni.ItemsSource = null;
            DataAccess db = new DataAccess();
            int idPreparatSelectat = lstMeniu.SelectedIndex;

            if (idPreparatSelectat >= 0)
            {
                alergeni = db.GetAlergeni(preparate[idPreparatSelectat].IdPreparat);

                if (alergeni.Count() > 0)
                {
                    lstAlergeni.ItemsSource = alergeni;
                    lstAlergeni.DisplayMemberPath = "InfoAlergen";
                }
            }
        }
    }
}
