﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gestion_des_patients
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Hospital_DataEntities3 : DbContext
    {
        public Hospital_DataEntities3()
            : base("name=Hospital_DataEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tblAdmission> tblAdmissions { get; set; }
        public virtual DbSet<tblAssurance> tblAssurances { get; set; }
        public virtual DbSet<tblDepartement> tblDepartements { get; set; }
        public virtual DbSet<tblLit> tblLits { get; set; }
        public virtual DbSet<tblMedecin> tblMedecins { get; set; }
        public virtual DbSet<tblPatient> tblPatients { get; set; }
        public virtual DbSet<tblTypeLit> tblTypeLits { get; set; }
    }
}
