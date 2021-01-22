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

namespace Gestion_des_patients
{
    /// <summary>
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public static Hospital_DataEntities3 myBDD;




        public Menu()
        {
            InitializeComponent();
            myBDD = new Hospital_DataEntities3();

            DateTime thisDay = DateTime.Now;
            text_update_date.Text = thisDay.ToString();
        }

        private void bnconnect_Click(object sender, RoutedEventArgs e)
        {
        // Récupération des valeurs saisies par l'utilisateur en lettres minuscules.
            string utilisateur = textlogin.Text.Trim().ToLower();
            string motPasse = textmotpasse.Password.Trim().ToLower();

            if (!String.IsNullOrEmpty(utilisateur) && !String.IsNullOrEmpty(motPasse))
            {

                if ((utilisateur == "admin") && (motPasse == "admin"))
                {
                    Administrateur administra = new Administrateur();
                    administra.ShowDialog();
                }

                if ((utilisateur == "prep") && (motPasse == "prep"))
                {
                    Prepose prepose = new Prepose();
                    prepose.ShowDialog();
                }

                if ((utilisateur == "med") && (motPasse == "med"))
                {
                    Medecin m = new Medecin();
                    m.ShowDialog();
                }
                //else
                //{
                //    MessageBox.Show("Les informations saisies sont incorrecte.",
                //    "Attention", MessageBoxButton.OK,
                //    MessageBoxImage.Information);

                //    textlogin.Text = String.Empty;
                //    textmotpasse.Text = String.Empty;
                //    textlogin.Focus();
                //}
            }
            else {
                MessageBox.Show("Les informations saisies ne sont pas valides.",
               "Attention",
               MessageBoxButton.OK,
               MessageBoxImage.Information);
                textlogin.Focus();
            }               

        }

        private void bnannuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
