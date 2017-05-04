using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartotekaKontrahentow.Models
{
    public class ZbiorKonrahentowCSV : IZbiorKontrahentow
    {
        private const string filename = "zbior.csv";
        private IList<Kontrahent> zbior = new List<Kontrahent>();

        public void Dodaj(Kontrahent kontrahent)
        {
            if (kontrahent == null)
                return;

            Kontrahent pobrany = WyszukajPoId(kontrahent.IdKontrahenta);
            if (pobrany == null)
                zbior.Add(kontrahent);
        }

        public void Usun(Kontrahent kontrahent)
        {
            if (kontrahent == null)
                return;

            Kontrahent pobrany = WyszukajPoId(kontrahent.IdKontrahenta);
            if (pobrany is Kontrahent)
                zbior.Remove(pobrany);
        }

        public Kontrahent WyszukajPoId(Guid id)
        {
            return zbior
                .Where(k => k.IdKontrahenta == id)
                .FirstOrDefault();
        }

        public IEnumerable<Kontrahent> PobierzWszystkich()
        {
            return zbior.ToArray();
        }

        public void Zapisz()
        {
            var plik = new StreamWriter(filename, false);

            var zserializowany = new StringBuilder();
            foreach (var kontrahent in zbior)
            {
                zserializowany.AppendFormat("{0};", kontrahent.IdKontrahenta);
                zserializowany.AppendFormat("{0};", kontrahent.Imie);
                zserializowany.AppendFormat("{0};", kontrahent.Nazwisko);
                zserializowany.AppendFormat("{0};", kontrahent.NazwaFirmy);
                zserializowany.AppendFormat("{0};", kontrahent.Miejscowosc);
                zserializowany.AppendFormat("{0};", kontrahent.Ulica);
                zserializowany.AppendFormat("{0};", kontrahent.Numer);
                zserializowany.AppendFormat("{0};", kontrahent.KodPocztowy);
                zserializowany.AppendFormat("{0};", kontrahent.Telefon);
                zserializowany.AppendFormat("{0};", kontrahent.Email);
                plik.WriteLine(zserializowany.ToString());
                zserializowany.Clear();
            }

            plik.Close();
        }

        public void Wczytaj()
        {
            if (!File.Exists(filename))
                return;

            zbior.Clear();
            var plik = new StreamReader(filename);

            while(!plik.EndOfStream)
            {
                var linia = plik.ReadLine();
                var dane = linia.Split(';');
                if (dane.Count() >= 10)
                {
                    
                    Guid id;
                    if (Guid.TryParse(dane[0], out id))
                    {
                        Kontrahent kontrahent = new Kontrahent();
                        kontrahent.IdKontrahenta = id;
                        kontrahent.Imie = dane[1];
                        kontrahent.Nazwisko = dane[2];
                        kontrahent.NazwaFirmy = dane[3];
                        kontrahent.Miejscowosc = dane[4];
                        kontrahent.Ulica = dane[5];
                        kontrahent.Numer = dane[6];
                        kontrahent.KodPocztowy = dane[7];
                        kontrahent.Telefon = dane[8];
                        kontrahent.Email = dane[9];
                        zbior.Add(kontrahent);
                    }
                }
            }

            plik.Close();
        }
    }
}
