using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM_SPA_Template.Models
{
    class Factura
    {
        public Client Client { get; set; } // Client associated with the invoice
        public DateTime Date { get; set; } // Date of the invoice
        public string InvoiceNumber { get; set; } // Invoice number
        public double Pvp { get; set; } // Price before discount and tax
        public double DiscountedPrice { get; private set; } // Price with discount applied
        public double FinalPrice { get; private set; } // Final price with tax
        public bool Paid { get; set; } // Whether the invoice has been paid

        // Constructor
        public Factura (Client client, DateTime date, string invoiceNumber, double pvp, double vat, bool paid)
        {
            Client = client;
            Date = date;
            InvoiceNumber = invoiceNumber;
            Pvp = pvp;
            Paid = paid;

            // Apply discount based on the client
            DiscountedPrice = ApplyDiscount();

            // Calculate the final price with VAT
            FinalPrice = CalculateFinalPrice(vat);
        }
        private double ApplyDiscount()
        {
            return Pvp - (Pvp * Client.Discount / 100.0);
        }

        // Method to calculate the final price with VAT
        private double CalculateFinalPrice(double vat)
        {
            return DiscountedPrice + (DiscountedPrice * vat / 100.0);
        }

    }
}
