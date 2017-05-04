using KartotekaKontrahentow.Helpers;
using KartotekaKontrahentow.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KartotekaKontrahentow.ViewModels
{
    public class KartotekaViewModel : ObservableObject
    {
        private IZbiorKontrahentow zbior;

        public ObservableCollection<Kontrahent> Kartoteka { get; private set; }

        private Kontrahent wybranyKontrahent;
        public Kontrahent WybranyKontrahent
        {
            get { return wybranyKontrahent; }
            set { wybranyKontrahent = value; OnPropertyChanged("WybranyKontrahent"); }
        }

        public ICommand ZapiszCommand { get; private set; }
        public ICommand DodajCommand { get; private set; }
        public ICommand UsunCommand { get; private set; }

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public KartotekaViewModel(IZbiorKontrahentow _zbior)
        {
            zbior = _zbior;
            zbior.Wczytaj();
            Kartoteka = new ObservableCollection<Kontrahent>(zbior.PobierzWszystkich());

            ZapiszCommand = new BasicCommand(onZapisz);
            DodajCommand = new BasicCommand(onDodaj);
            UsunCommand = new BasicCommand(onUsun);
        }

        private void onZapisz()
        {
            zbior.Zapisz();
            logger.Info(String.Format("{0} : {1}", DateTime.Now, "Zapisano kartotekę"));
        }

        private void onDodaj()
        {
            Kontrahent kontrahent = new Kontrahent() { IdKontrahenta = Guid.NewGuid(), Imie = "Podaj imię", Nazwisko = "Podaj nazwisko" };
            zbior.Dodaj(kontrahent);
            Kartoteka.Add(kontrahent);
            logger.Info(String.Format("{0} : {1} {2}", DateTime.Now, "Dodano kontrahenta ", kontrahent.IdKontrahenta));
            WybranyKontrahent = kontrahent;
        }

        private void onUsun()
        {
            zbior.Usun(WybranyKontrahent);
            Kartoteka.Remove(WybranyKontrahent);
            logger.Info(String.Format("{0} : {1} {2}", DateTime.Now, "Usunięto kontrahenta ", WybranyKontrahent.IdKontrahenta));
            WybranyKontrahent = null;
        }


    }
}
