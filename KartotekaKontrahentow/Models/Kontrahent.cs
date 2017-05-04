using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartotekaKontrahentow.Models
{
    public class Kontrahent
    {
        public Guid IdKontrahenta { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NazwaFirmy { get; set; }
        public string Miejscowosc { get; set; }
        public string Ulica { get; set; }
        public string Numer { get; set; }
        public string KodPocztowy { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }

        public Kontrahent()
        {
            IdKontrahenta = Guid.Empty;
            Imie = "";
            Nazwisko = "";
            NazwaFirmy = "";
            Miejscowosc = "";
            Ulica = "";
            Numer = "";
            KodPocztowy = "";
            Telefon = "";
            Email = "";
        }
    }
}
