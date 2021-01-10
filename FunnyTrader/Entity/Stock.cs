using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace FunnyTrader.Entity
{
    class Stock
    {
        public StockName stockName { get; private set; } //zmienna przechowująca nazwe
        public string Country { get;  set; }
        /// <summary>
        /// Klasa przechowująca dane o akcji 
        /// </summary>
        /// <param name="name">Enum służączy jako nazwa/Id</param>
        /// <param name="value">Etykieta z wartością akcji</param>
        public Stock(StockName name)
        {
            stockName = name;
            setCountry();
        }
        /// <summary>
        /// W zależności od wpisanej formy, dobrany zostaje kraj z którego pochodzi
        /// </summary>
        private void setCountry()
        {
            switch (stockName)
            {
                case StockName.Volkswagen:
                    Country = "Niemcy";
                    break;
                case StockName.Microsoft:
                    Country = "USA";
                    break;
                case StockName.Tauron:
                    Country = "Polska";
                    break;
                case StockName.Xaomi:
                    Country = "Chiny";
                    break;
            }

        }

    }
}
