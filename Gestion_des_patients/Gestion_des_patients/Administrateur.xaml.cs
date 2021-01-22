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
    /// Logique d'interaction pour Administrateur.xaml
    /// </summary>
    public partial class Administrateur : Window
    {
        public Administrateur()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query =

      from c in Menu.myBDD.tblMedecins
      select new { c.IDMédecin, c.nom, c.prénom };
            datagrid_Medecin.DataContext = query.ToList();

        }

        private void Bnajout_Med_Click(object sender, RoutedEventArgs e)
        {
            tblMedecin med1 = new tblMedecin(int.Parse(textId_med.Text), textnom_med.Text, textprenom_med.Text);
            Menu.myBDD.tblMedecins.Add(med1);

            try
            {
                Menu.myBDD.SaveChanges();

                datagrid_Medecin.DataContext = null;
            datagrid_Medecin.DataContext = Menu.myBDD.tblMedecins.ToList();
                MessageBox.Show("ajout effectué avec succes!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Bnsupprim_Med_Click(object sender, RoutedEventArgs e)
        {    
           
            int a = int.Parse(textId_sup_med.Text);

            tblMedecin o = (from s in Menu.myBDD.tblMedecins.ToList() where s.IDMédecin == a select s).FirstOrDefault();

            Menu.myBDD.tblMedecins.Remove(o);

            try
            {  
                
                Menu.myBDD.SaveChanges();

                datagrid_Medecin.DataContext = null;
                datagrid_Medecin.DataContext = Menu.myBDD.tblMedecins.ToList();

                MessageBox.Show("supression effectué avec succes!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("L'évaluation de la fonction nécessite tous les threads!");

                MessageBox.Show(ex.Message);
            }       

        }

       
    }
}
