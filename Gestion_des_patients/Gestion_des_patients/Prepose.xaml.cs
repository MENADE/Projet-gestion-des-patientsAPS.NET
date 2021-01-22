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
    /// Logique d'interaction pour Prepose.xaml
    /// </summary>
    public partial class Prepose : Window
    {
     //public static tblPatient base_nss;
        public Prepose()
        {
            InitializeComponent();
        }

        private void bn_recherche_Click(object sender, RoutedEventArgs e)
        {             
            tblPatient patient = new tblPatient();
            try
            {
                int nss_saisie = int.Parse(text_recherche.Text.ToString());
                var base_nss = (from s in Menu.myBDD.tblPatients.ToList() where s.NSS == nss_saisie select s).FirstOrDefault();

                if (!String.IsNullOrEmpty(text_recherche.Text.ToString()))
                {
                    if (base_nss != null && nss_saisie == base_nss.NSS)
                    {
                        Ajouter_admission ajout_patient = new Ajouter_admission(base_nss);
                        ajout_patient.ShowDialog();
                    }
                    else
                    {
                        Ajouter_patient ajout_patient = new Ajouter_patient();
                        ajout_patient.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez introduire un numéro de sécurité sociale NSS.",
                    "Attention", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                }

            }
            catch (Exception  )
            {
                MessageBox.Show("Veuillez introduire un numéro de sécurité sociale NSS valide.",
                   "Attention", MessageBoxButton.OK,
                   MessageBoxImage.Information);
            }       
         
        }









    }
}
