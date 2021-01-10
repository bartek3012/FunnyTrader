using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunnyTrader.Entity
{
    class StockToBuy : Stock
    {
        private Label labelPercentChange;
        private Label labelPrice;
        public double PercentChange { get; private set; }
        public double Price { get; private set; }
        /// <summary>
        /// Klasa akcji do kupienia
        /// </summary>
        /// <param name="name">Nazwa akcji typu enum</param>
        /// <param name="_labelPrice">Letkieta z ceną akcji</param>
        /// <param name="labelchange">Etykieta z procentową zmianą ceny akcji</param>
        public StockToBuy(StockName name, Label _labelPrice, Label labelchange):base(name)
        {
            labelPercentChange = labelchange;
            labelPrice = _labelPrice;
            double change; //Zmienna do uzyskania wartości z etykiety
            Double.TryParse(labelPercentChange.Text,out change);
            PercentChange = change;//Użyta dodatkowa zmienna, ponieważ property nie można użyć ze słowem kluczowym "ref"
            double price; //Zmienna do uzyskania wartości z etykiety
            Double.TryParse(labelPrice.Text, out price); //Użyta dodatkowa zmienna, ponieważ property nie można użyć ze słowem kluczowym "ref"
            Price = price; //Przypisanie pomocniczej zmiennej do właściwej
        }
        /// <summary>
        /// Zmiana procentowej ceny akcji
        /// </summary>
        /// <param name="percent">Wartość zmiany ceny akcji</param>
        public void ChangeByPercent(double percent)
        {
            PercentChange = percent; //przypisanie zmiany
            labelPercentChange.Text = $"{Math.Round(percent,2)} %"; //Aktualizacja etykiety
            if(percent<0) //Jeśli zminan jest dodatnia czcionka etykiety ma kolor zielony, natomiast w przypadku ujemnej wartości czerwony
            {
                labelPercentChange.ForeColor = Color.Red;
            }
            else
            {
                labelPercentChange.ForeColor = Color.Green;
            }
            Price = Price + (Price * PercentChange/100); //Obliczenie ceny
            labelPrice.Text = Math.Round(Price, 2).ToString(); //Aktualizacja etykiety z ceną 
        }
    }
}
