﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;

namespace Gestion_des_patients
{
    [Serializable]
    internal class Valid_Date_ChirurgieException : Exception
    {
        public Valid_Date_ChirurgieException()
        {
        }

        public Valid_Date_ChirurgieException(string message) : base(message)
        {
        }

        public Valid_Date_ChirurgieException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected Valid_Date_ChirurgieException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}