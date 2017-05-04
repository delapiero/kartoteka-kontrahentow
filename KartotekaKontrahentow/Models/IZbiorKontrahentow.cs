using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartotekaKontrahentow.Models
{
    public interface IZbiorKontrahentow
    {
        void Dodaj(Kontrahent kontrahent);
        void Usun(Kontrahent kontrahent);
        void Zapisz();
        void Wczytaj();
        Kontrahent WyszukajPoId(Guid id);
        IEnumerable<Kontrahent> PobierzWszystkich();
    }
}
