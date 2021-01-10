using FunnyTrader.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunnyTrader.News
{
    class EventMenager
    {
        public List<Event> Events { get; set; }
        private Event presentEvent;
        private Timer timer;
        private int counter = 0;
        private Random random = new Random();
        /// <summary>
        /// Klasa zarządzająca zdarzeniali losowymi
        /// </summary>
        /// <param name="timerCounter">Główny timer programu</param>
        public EventMenager(Timer timerCounter)
        {
            timer = timerCounter;
            Initializa();
        }
        /// <summary>
        /// Inicjalizacja listy zdarzeń
        /// </summary>
        private void Initializa()
        {
            Events = new List<Event>();
            Events.Add(new Event("Wyprzedaże na Aliexpress!", "Kolejne wyprzedaże z okazji chińskiego nowego roku. Eksperci twierdzą, że przychody w tym roku pobiją wszelkie rekordy.", "Aliexpress.png")); //Ddanie obiektu zdarzenia do listy
            Events[0].SetChangePrice(StockName.Xaomi, 3); //Ustawienie wpływu wydarzenia na cene akcji
            //Analogicznie dalsze ddoawanie elementów
            Events.Add(new Event("Najman jedzie bronić Jasnej Góry", "Jak okazało sie na miejscu nikogo nie było. Najman komentuje sprawę słowamu: \"Przecież tu nikogo nie ma. Nikt nie atakuje Jasnej Góry. Co wy pie...cie za głupoty!\"", "Najman.jpg"));
            Events[1].SetChangePrice(StockName.Tauron, -1);
            Events.Add(new Event("Ataki na maszty 5G", "Poraz kolejny doszło do ataków na maszty sieci 5G w Polsce. Ataki zostały zorganizowane przez grupę antyszczepionkowców. Jak się jednak okazało nie były to maszty sieci 5G, ani nawet maszty telekomunikacyjne. Zniszczony został słup wysokiego napięcia", "5G.jpg"));
            Events[2].SetChangePrice(StockName.Tauron, -3);
            Events.Add(new Event("Innowacja w Chinach", "Chiński rząd wprowadził przymus umieszczenia szpitali położniczych we wszytskich chińskich fabrykach. Ma to na celu przyśpieszenie adaptacji do pracy młodego pracownika o 75%.", "ChineseKid.jpg"));
            Events[3].SetChangePrice(StockName.Xaomi, 2);
            Events.Add(new Event("Nowy przysmak w Chinach", "Nietoperze, te zwierzęta ostatnio królują w chińskiej kuchni. Coraz częsciej podawane są rónież w wersji Al dente.", "Corona.jpg"));
            Events[4].SetChangePrice(StockName.Xaomi, -2);
            Events[4].SetChangePrice(StockName.Microsoft, -4);
            Events[4].SetChangePrice(StockName.Tauron, -4);
            Events[4].SetChangePrice(StockName.Volkswagen, -4);
            Events.Add(new Event("Sukces .Net 5", "Sukces .Net 5 i C# 9! Eksperci już teraz twierdzą, że C# stanie się językiem 2021 roku. To nie koniec nowości. Do 2021 na każdym komputerze z systemem Windows ma być fabrycznie zainstalowany Visual Studio!", "DotNet.png"));
            Events[5].SetChangePrice(StockName.Microsoft, 3);
            Events.Add(new Event("Absolwenci Pwr na topie!", "Absolwenci Politechniki Wrocławskiej wypadli najlepiej w badanich opinii pracodawców. Oczywiści brane pod uwagę były jedynie osoby, które nie wyemigrowały po studiach do Niemiec", "Pwr.jpg"));
            Events[6].SetChangePrice(StockName.Tauron, 3);
            Events[6].SetChangePrice(StockName.Volkswagen, 3);
            Events.Add(new Event("Udogodnienia do przedsiębiorców!", "Polski rząd podnosi podatki dla przedsiębiorców, dzięki temu nie będą oni musieli zastanawiać się na co przeznaczyć dodatkowe środki, a ciężar tej decyzji weźnie na siebie państwo", "Tax.jpg"));
            Events[7].SetChangePrice(StockName.Tauron, -2);
        }
        /// <summary>
        /// Osługa zdarzeń
        /// </summary>
        /// <returns></returns>
        public double[] MakeEvent()
        {
            counter++; //Inkrementacja licznika
            if(counter == 1) //Jeśli wartość równa się jeden 
            {
                int numberEvent = random.Next(0, (Events.Count)); //wylosowanie zdarzenia
                presentEvent = Events[numberEvent]; //Pispisanie wylosowango zdarzenia do zmiennej na obecny obiekt
                FormNews formNews = new FormNews(presentEvent, timer); //Stworzeni okna do wyświetlenia zdarzenia
                Events.Remove(presentEvent); //Usunięcie zdarzenia z listy posostałych zdarzeń
                formNews.Show();
                return new double[] { 0, 0, 0, 0 }; //Póki co zdarzenie nie powoduje zmian
            }
            else if(counter == 2 || counter == 3) //W 2 i 3 sekundzie zdarzenie nie powoduje zmian
            {
                return new double[] { 0, 0, 0, 0 }; //Póki co zdarzenie nie powoduje zmian
            }
            else if(counter != 10) //Jeśli mamy od 3 do 9 sekundy zdarzenie wpływa na ceny danych akcji
            {
                return presentEvent.ChangePrice;//Zwrócenie tablicy z oddziaływaniem zdarzenia na cene akcji
            }
            else //W dziesiątej sekundzie zerowany jest licznik, aby w kolejnej iteracji wylosować kolejne zdarzenie
            {
                counter = 0;
                return presentEvent.ChangePrice;//Zwrócenie tablicy z oddziaływaniem zdarzenia na cene akcji
            }
        }

    }
}
