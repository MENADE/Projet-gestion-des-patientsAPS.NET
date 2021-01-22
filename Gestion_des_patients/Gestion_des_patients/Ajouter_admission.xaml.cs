using System;
using System.Collections.Generic;
using System.Data;
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
    /// Logique d'interaction pour Ajouter_admission.xaml
    /// </summary>
    public partial class Ajouter_admission : Window
    {


        tblPatient nssModel;
        public Ajouter_admission(tblPatient base_nss)
        {
            InitializeComponent();
           
            nssModel = base_nss;


            combo_idmedecin.DataContext = Menu.myBDD.tblMedecins.ToList();

            Affichage_Listlits_disponibles();

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            datagrid_admission.DataContext = nssModel.tblAdmissions.ToList();
            text_nsspatient.Text = nssModel.NSS.ToString();
        }



        //méthode d'ajout et d'affichage des admissions dans le DATAGRID. 
        private void bnajout_admission_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                //méthodes de validation de la saisie des ID_ADMISSION et DATE_D'ADMISSION
                tblAdmission.Validation_ID_Date_admission(text_idadmission.Text.ToString(), (DateTime?)text_dateadmission.SelectedDate);

                //méthodes de validation de la saisie de la date de chirurgie
                tblAdmission.Valid_Date_Chirurgie((bool)text_checkchirurgie.IsChecked, (DateTime?)text_datechirurgie.SelectedDate);

// -----------------------------------------------------------récupération des attributs de classe Admission afin de construire un objet Admission---------------------------------------------------------------------------------------
                int idadmission = int.Parse(text_idadmission.Text.ToString());
                DateTime? dateadmi = (DateTime?)text_dateadmission.SelectedDate;

                bool chirgieprog = (bool)text_checkchirurgie.IsChecked;
                DateTime? date_chirurgi = (DateTime?)text_datechirurgie.SelectedDate;

                DateTime? date_cong = (DateTime?)text_datecongée.SelectedDate;
                date_cong = null;

                bool if_tv = (bool)text_checktélévision.IsChecked;
                bool if_télé = (bool)text_checktéléphone.IsChecked;

                int nss_current = nssModel.NSS;

                tblMedecin medec1 = combo_idmedecin.SelectedItem as tblMedecin;
                int idmedecin = int.Parse(medec1.IDMédecin.ToString());

                //choix de lit, il faut faire appel au fonction de ChoixLIT() pour détrminer quel type de chambre devrait prendre les patients avec IDAssurance ==NULL 
                tblLit lit1 = ChoixLit();
                int numlit = int.Parse(lit1.Numérolit.ToString());


                //Appel au construction d'objet admission afin de l'ajouter plus tard

                tblAdmission admissionModel = new tblAdmission(idadmission, chirgieprog, dateadmi, date_chirurgi, date_cong, if_tv, if_télé, nss_current, numlit, idmedecin);

                //IMPORTANT : mise a jour apres chaque nouvelle «admission» ajouté la base de données : table «tblAdmission», et aussi aficher la liste des lits diponibles

                lit1.occupé = true;
                Menu.myBDD.tblAdmissions.Add(admissionModel);
                combo_numerolit.DataContext = null;
                combo_numerolit.DataContext = (from c in Menu.myBDD.tblLits.ToList() where c.occupé == false select c);

                // Appel la Méthode de calcul des frais de réseration de chambre --plus de détail consulté de corps de la métode en bas.
                id_facture_total.Text = FraisReservationLit().ToString() +"$";

                try
                {
                    Menu.myBDD.SaveChanges();

                    // mise a jour de la liste d'affichage des admissions
                    datagrid_admission.DataContext = null;
                    datagrid_admission.DataContext = Menu.myBDD.tblAdmissions.ToList();
                    MessageBox.Show("ajout effectué avec succes!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            // La validation des contraints proposées dans l'énoncé de TP ce fait via des méthodes d'exception ---consulté l'explorateur de solution pour plus de détails sur ces méthodes crées--
            catch (Valid_ID_admissionException)
            {
                MessageBox.Show("Veuillez SVP saisir le ID d'admission!.", "Attention", MessageBoxButton.OK,
                   MessageBoxImage.Information);
            }

            catch (Valid_Date_ChirurgieException)
            {
                MessageBox.Show("Veuillez SVP rentrer la date prévue pour la chirurgie.", "Attention", MessageBoxButton.OK,
                   MessageBoxImage.Information);
            }


            catch (Valid_programmation_chirurgieException)
            {
                MessageBox.Show("Veuillez SVP coché la case chirurgie programmé pour confirmer votre saisie!.", "Attention", MessageBoxButton.OK,
                   MessageBoxImage.Information);
            }


            catch (Valid_ID_admission_insertionException)
            {
                MessageBox.Show("Une admission avec le même ID existe déja dans la base de données, Veuillez choisir un autre ID SVP!.", "Attention", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }

            catch (Valid_Date_admissionException)
            {
                MessageBox.Show("Veuillez SVP choisir la date d'admission!", "Attention", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }

        }


       // Méthode d'afichage de lits disponibles de manière dynamique: c'est a dire au fure a mesure de leurs libération après un congé donné par un médecin : voir fenêtre Médecin pour plus de détails sur la liste des lits mise a jour.
        private void Affichage_Listlits_disponibles()
        {

            var lit_Model = (from s in Menu.myBDD.tblTypeLits.ToList()
                             join st in Menu.myBDD.tblLits.ToList()
                      on s.IDType equals st.IDType
                             where st.occupé == false
                             select s).ToList();
            id_listLits_SansFraisSup.DataContext = lit_Model.Distinct();
        }


        // Affichage les lits disponibles par type : selectionChanged Comobox des lits vacants (qui les affichage par type de lit) 
        private void id_listLits_SansFraisSup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            nssModel.IDAssurance.ToString();
            tblTypeLit type_Lit = id_listLits_SansFraisSup.SelectedItem as tblTypeLit;


            IEnumerable<tblLit> chambres = (from s in Menu.myBDD.tblTypeLits.ToList()
                                            join st in Menu.myBDD.tblLits.ToList()
                                         on type_Lit.IDType equals st.IDType
                                            where (st.occupé == false)
                                            select st).ToList();

          
            var distinct1 = chambres.Distinct();

            datagrid_lit_partype.DataContext = null;
            datagrid_lit_partype.DataContext = distinct1;

            combo_numerolit.DataContext = null;
            combo_numerolit.DataContext = distinct1;

        }

        // Méthode pour déterminer le lit a réserver dans le cas ou le patient n'a pas d'assurance privé.

        private tblLit ChoixLit()
        {
            tblLit lit_selectionné = combo_numerolit.SelectedItem as tblLit;

            if (nssModel.IDAssurance == null)

            {
                if (lit_selectionné.IDType == 61)
                {

                    return lit_selectionné;

                }
                else if (lit_selectionné.IDType == 62)
                {

                    return lit_selectionné;
                }
                else if (lit_selectionné.IDType == 63)
                {

                    return lit_selectionné;
                }


            }
            else
               if (lit_selectionné.IDType == 62)
            {


                return lit_selectionné;
            }
            if (lit_selectionné.IDType == 63)
            {

                return lit_selectionné;
            }

            return lit_selectionné;

        }

        //Méthode de calcul des frais de réservation de chambre dans le cas ou le patient qui n'a pas d'assurance privé opte pour une chambre privé ou semi-privé

        private double FraisReservationLit()
        {

            tblLit lit_selectionné = combo_numerolit.SelectedItem as tblLit;

            double fraisLit = 0;

            if (lit_selectionné.IDType == 62)
            {

                return fraisLit = 267 ;
            }
            if (lit_selectionné.IDType == 63)
            {

                return fraisLit = 571;
            }

            if (text_checktélévision.IsChecked == true)
            {

                fraisLit = fraisLit + 42.50;
            }
            if (text_checktéléphone.IsChecked == true)
            {

                fraisLit = fraisLit + 42.50;
            }

            return fraisLit;


        }









    }
}



