using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KartotekaKontrahentow.Models;

namespace KartotekaKontrahentow.Test
{
    [TestClass]
    public class ZbiorKontrahentowTest
    {
        [TestMethod]
        public void ZbiorKontrahentowCSVTest()
        {
            IZbiorKontrahentow zbior = new ZbiorKonrahentowCSV();
            Kontrahent kontrahent = new Kontrahent() { Imie = "Jan", Nazwisko = "Kowalski", IdKontrahenta = Guid.NewGuid() };

            zbior.Dodaj(kontrahent);
            zbior.Zapisz();
            zbior.Wczytaj();
            Assert.IsInstanceOfType(zbior.WyszukajPoId(kontrahent.IdKontrahenta), typeof(Kontrahent));
            
            zbior.Usun(kontrahent);
            zbior.Zapisz();
            zbior.Wczytaj();
            Assert.IsNull(zbior.WyszukajPoId(kontrahent.IdKontrahenta));
        }
    }
}
