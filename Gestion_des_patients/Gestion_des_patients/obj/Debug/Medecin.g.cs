﻿#pragma checksum "..\..\Medecin.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "26ADB09D79B5F4B999BA0970CF2210F814C3BC8E5DDE643025467206D19D9F07"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Gestion_des_patients;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Gestion_des_patients {
    
    
    /// <summary>
    /// Medecin
    /// </summary>
    public partial class Medecin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\Medecin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagrid_admis_conge;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Medecin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn idadmission1;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Medecin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn iddateconge;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Medecin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker text_datecongdonne;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Medecin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bn_dateconge;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\Medecin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bn_liste_admis_enCour;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Medecin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combo_ID_cong;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Medecin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox statut_lit;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\Medecin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox list_lits_disponible;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\Medecin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagrid_lits_libere;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\Medecin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button affichag_lits_dispo;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\Medecin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label statutlit;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Gestion_des_patients;component/medecin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Medecin.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\Medecin.xaml"
            ((Gestion_des_patients.Medecin)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.datagrid_admis_conge = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.idadmission1 = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 4:
            this.iddateconge = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 5:
            this.text_datecongdonne = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.bn_dateconge = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\Medecin.xaml"
            this.bn_dateconge.Click += new System.Windows.RoutedEventHandler(this.bn_dateconge_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.bn_liste_admis_enCour = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\Medecin.xaml"
            this.bn_liste_admis_enCour.Click += new System.Windows.RoutedEventHandler(this.bn_liste_admis_enCour_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.combo_ID_cong = ((System.Windows.Controls.ComboBox)(target));
            
            #line 31 "..\..\Medecin.xaml"
            this.combo_ID_cong.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.combo_ID_cong_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.statut_lit = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.list_lits_disponible = ((System.Windows.Controls.ComboBox)(target));
            
            #line 39 "..\..\Medecin.xaml"
            this.list_lits_disponible.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.list_lits_disponible_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.datagrid_lits_libere = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 12:
            this.affichag_lits_dispo = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\Medecin.xaml"
            this.affichag_lits_dispo.Click += new System.Windows.RoutedEventHandler(this.affichag_lits_dispo_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.statutlit = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

