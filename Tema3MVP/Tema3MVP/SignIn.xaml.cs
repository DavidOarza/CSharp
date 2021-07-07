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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace Tema3MVP
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public SignIn()
        {
            InitializeComponent();
        }
        private void btnInapoi_Click(object sender, RoutedEventArgs e)
        {
            StartingWindow start = new StartingWindow();
            start.Show();
            Close();
        }

        private void btnInregistrare_Click(object sender, RoutedEventArgs e)
        {
            DataAccess db = new DataAccess();

            if(db.AddClient(txtEmail.Text) == true)
            {
                btnInregistrare.Content = "Utilizator existent";
                btnInregistrare.IsEnabled = false;
            }
            else
            {
                SqlConnection con = new System.Data.SqlClient.SqlConnection(Helper.Connection("RestaurantDB"));
                SqlCommand cmd = con.CreateCommand();
                
                cmd.CommandText = "Execute spAdaugareClient @Nume,@Prenume,@Email,@Telefon,@AdresaDeLivrare,@Parola";

                cmd.Parameters.Add("@Nume", SqlDbType.VarChar, 50).Value = txtNume.Text.ToString();
                cmd.Parameters.Add("@Prenume", SqlDbType.VarChar, 50).Value = txtPrenume.Text.ToString();
                cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = txtEmail.Text.ToString();
                cmd.Parameters.Add("@Telefon", SqlDbType.VarChar, 50).Value = txtTelefon.Text.ToString();
                cmd.Parameters.Add("@AdresaDeLivrare", SqlDbType.VarChar, 50).Value = txtAdresaLivrare.Text.ToString();
                cmd.Parameters.Add("@Parola", SqlDbType.VarChar, 50).Value = txtParola.Text.ToString();

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                btnInregistrare.Content = "Utilizator inregistrat";
                btnInregistrare.IsEnabled = false;
            }
        }
    }
}
