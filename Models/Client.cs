using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM_SPA_Template.Models
{
    class Client
    {
        public string Name { get; set; }
        public string DniNif { get; set; }
        public string Code { get; set; }
        public bool Profesional { get; set; }
        public int Discount { get; set; } // Descuento en porcentaje
        public DateTime RegistrationDate { get; set; } // Fecha de alta
        public double TotalAnualSells { get; set; } // Ventas totales anuales

        // Constructor
        public Client(string name, string dniNif, string code, bool profesional, int discount, DateTime registrationDate, double anualTotalSells)
        {
            Name = name;
            DniNif = dniNif;
            Code = code;
            Profesional = profesional;
            Discount = discount;
            RegistrationDate = registrationDate;
            TotalAnualSells = anualTotalSells;
        }
        public Client() { }

    }
}
