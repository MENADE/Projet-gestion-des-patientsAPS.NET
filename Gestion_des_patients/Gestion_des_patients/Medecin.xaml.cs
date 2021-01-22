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
    /// Logique d'interaction pour Medecin.xaml
    /// </summary>
    public partial class Medecin : Window
    {
        public Medecin()
        {
            InitializeComponent();
            var AdmissionenCour = from c in Menu.myBDD.tblAdmissions.ToList() where c.date_congé == null select c;
            this.DataContext = AdmissionenCour;


            var lits_disponible = from c in Menu.myBDD.tblLits.ToList() where c.occupé == false select c;
            list_lits_disponible.DataContext = lits_disponible;


            var lit_recement_libéré = from c in Menu.myBDD.tblLits.ToList() where c.occupé == false select c;
            datagrid_lits_libere.DataContext = lit_recement_libéré;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void bn_dateconge_Click(object sender, RoutedEventArgs e)
        {

            tblAdmission admi1 = combo_ID_cong.SelectedItem as tblAdmission;
            tblAdmission admis_change = (from c in Menu.myBDD.tblAdmissions.ToList() where c.IDAdmission == admi1.IDAdmission select c).FirstOrDefault();

            //Etape 1: suppression de l'admission récuprée de la sélection (admi1) de la base de donnée Note: sa date_congé =null  (date non précise)
            Menu.myBDD.tblAdmissions.Remove(admis_change);
            Menu.myBDD.SaveChanges();

            //Etape2 : remplacement dans la base de données de l'admission supprimé par une nouvelle admission dont valeur de date_congé !=null (date précise)
            admi1.date_congé = (DateTime?)text_datecongdonne.SelectedDate;
            Menu.myBDD.tblAdmissions.Add(admi1);
            Menu.myBDD.SaveChanges();

            //Etape3: afficher le lit a libéré de l'admission modifier admi1 avec la nouvelle date de congé           
            var aa = (from c in Menu.myBDD.tblAdmissions.ToList() where c == admi1 select c).ToList();

            datagrid_admis_conge.DataContext = null;
            datagrid_admis_conge.DataContext = aa;

            //Etape4: rendre disponible le lit de l'admission modifier : occupé devient FALSE dans la base de données
            tblLit litlibre = (tblLit)(from c in Menu.myBDD.tblLits.ToList() where c.Numérolit == admi1.Numérolit select c).FirstOrDefault();

            litlibre.occupé = false;
            Menu.myBDD.SaveChanges();
            statut_lit.Text = "Le lit Numéro " + litlibre.Numérolit + "  sera libéré a partir du " + admi1.date_congé;

            // affichage des lits qui viennent d'être libérés  

            var lit_recement_libéré = from c in Menu.myBDD.tblLits.ToList() where c.Numérolit == litlibre.Numérolit select c;
            datagrid_lits_libere.DataContext = lit_recement_libéré;

            //actualiser la liste des admissions en cours 
            var list_admis_cong_null = from c in Menu.myBDD.tblAdmissions.ToList() where c.date_congé == null select c;
            combo_ID_cong.DataContext = list_admis_cong_null;

            combo_ID_cong.SelectedIndex = 0;

            //liste des lits disponibles

            var lits_disponible = from c in Menu.myBDD.tblLits.ToList() where c.occupé == false select c;            
            list_lits_disponible.DataContext = lits_disponible;

           MessageBox.Show($"Félicitation, le congé donné a l'admission ID  { admi1.IDAdmission} a été valité, automatiquement son lit est libéré a partir du {admi1.date_congé}",  "Attention", MessageBoxButton.OK,
                   MessageBoxImage.Information);
         
        }

        private void list_lits_disponible_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            tblLit lit1 = list_lits_disponible.SelectedItem as tblLit;
            var lit_select = (from c in Menu.myBDD.tblLits.ToList() where c == lit1 select c).ToList();

            datagrid_lits_libere.DataContext = null;
            datagrid_lits_libere.DataContext = lit_select;

        }

        private void affichag_lits_dispo_Click(object sender, RoutedEventArgs e)
        {
            var list_litlibre = from c in Menu.myBDD.tblLits.ToList() where c.occupé == false select c;
            datagrid_lits_libere.DataContext = list_litlibre;

        }

        private void bn_liste_admis_enCour_Click(object sender, RoutedEventArgs e)
        {
            var AdmissionenCour_apres_conge = from c in Menu.myBDD.tblAdmissions.ToList() where c.date_congé == null select c;
            
            datagrid_admis_conge.DataContext = null;
            datagrid_admis_conge.DataContext = AdmissionenCour_apres_conge;

        }

        private void combo_ID_cong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tblAdmission admiencour = combo_ID_cong.SelectedItem as tblAdmission;

            var admi_en_cour_select = (from c in Menu.myBDD.tblAdmissions.ToList() where c == admiencour select c).ToList();

            datagrid_admis_conge.DataContext =null ;
            datagrid_admis_conge.DataContext = admi_en_cour_select;

        }
    }
}
