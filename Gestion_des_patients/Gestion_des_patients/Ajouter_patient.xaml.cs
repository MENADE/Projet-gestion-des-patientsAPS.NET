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
    /// Logique d'interaction pour Ajouter_patient.xaml
    /// </summary>
    public partial class Ajouter_patient : Window
    {
        public Ajouter_patient()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query1 =
from c in Menu.myBDD.tblPatients
select new { c.NSS, c.date_naissance, c.nom, c.prénom, c.adresse, c.ville, c.province, c.code_postal, c.téléphone, c.IDAssurance };
            datagrid_patient.DataContext = query1.ToList();
        }

        private void bnajout_patient_Click(object sender, RoutedEventArgs e)
        {
            int nss = int.Parse(text_nss.Text);
            int idassurance = int.Parse(text_idassurance.Text);
            
            tblPatient patienModel = new tblPatient(nss, text_date_naissance.SelectedDate, text_name.Text, text_prénom.Text, 
                text_adresse.Text, text_ville.Text, text_province.Text, text_code_postal.Text, text_téléphone.Text, idassurance);

            Menu.myBDD.tblPatients.Add(patienModel);

            try
            {
                Menu.myBDD.SaveChanges();

                datagrid_patient.DataContext = null;
                datagrid_patient.DataContext = Menu.myBDD.tblPatients.ToList();
                MessageBox.Show("ajout effectué avec succes!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    


    }
}
