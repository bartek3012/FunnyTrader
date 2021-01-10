using FunnyTrader.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunnyTrader.Menager
{
    class StocksToBuyMenager : BaseStockMenager<StockToBuy>
    {
        /// <summary>
        /// Klasa zarządzajaca akcjami do kupienia
        /// </summary>
        /// <param name="volkswagenPrice">Etykieta z ceną akcji</param>
        /// <param name="volkswagenChange">Etykieta z procentową zmianą ceny akcji</param>
        /// <param name="microsoftPrice">Etykieta z ceną akcji</param>
        /// <param name="microsoftChange">Etykieta z procentową zmianą ceny akcji</param>
        /// <param name="tauronPrice">Etykieta z ceną akcji</param>
        /// <param name="tauronChange">Etykieta z procentową zmianą ceny akcji</param>
        /// <param name="XaomiPrice">Etykieta z ceną akcji</param>
        /// <param name="XaomiChange">Etykieta z procentową zmianą ceny akcji</param>
        public StocksToBuyMenager(Label volkswagenPrice, Label volkswagenChange, Label microsoftPrice, Label microsoftChange,
            Label tauronPrice, Label tauronChange, Label XaomiPrice, Label XaomiChange)
        {
            AllStocks.Add(new StockToBuy(StockName.Volkswagen, volkswagenPrice, volkswagenChange));
            AllStocks.Add(new StockToBuy(StockName.Microsoft, microsoftPrice, microsoftChange));
            AllStocks.Add(new StockToBuy(StockName.Tauron, tauronPrice, tauronChange));
            AllStocks.Add(new StockToBuy(StockName.Xaomi, XaomiPrice, XaomiChange));
        }
        /// <summary>
        /// Zwrócenie ceny akcji po jej nazwie
        /// </summary>
        /// <param name="name">Nazwa akcji</param>
        public double GetPriceByEnumName(StockName name)
        {
           return GetItemByEnumName(name).Price;
        }
        /// <summary>
        /// Funkcja powodująca zmianę cen akcji o ustalony procent
        /// </summary>
        /// <param name="eventNews">Dodatkowe zmiany wartości zależne od wydarzeń</param>
        public void MakeChange(double []eventNews)
        {
            Random random = new Random(); //zmienna do generowania liczb losowych
            int i = 0; //iterator
            foreach (StockToBuy stock in AllStocks) //Iteracja po wszytskich rodzajach akcji
            {
                double drawnNumber = random.Next(0, 40); //Wylosowanie liczby od 0 do 39
                stock.ChangeByPercent(((drawnNumber-20)/10)+eventNews[i]); //tabela eventNews pasuje kolejnością do akcji, ponieważ do inicjalizacji tabeli użyte został typ enum StockName
                i++; //Inkrementacj powodująca przejście do kolejnego elementu tabeli
            }
        }
    }
}
