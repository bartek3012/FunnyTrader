using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunnyTrader.Entity
{
    class OwnStocks : Stock
    {
        public int Quantity { get; private set; } //ilość posiadanej akcji
        /// <summary>
        /// Klasa posiadanej akcji
        /// </summary>
        /// <param name="name">Nazwa akcji typu enum</param>
        /// <param name="amount">Ilośc posiadanej akcji</param>
        public OwnStocks(StockName name, int amount):base(name)
        {
            Quantity = amount;
        }
        /// <summary>
        /// Zwiększenie ilosci akcji
        /// </summary>
        /// <param name="value">Iloś akcji o którą zwiększamy</param>
        public void IncreeseQuantity(int value)
        {
            Quantity += value;
        }
        /// <summary>
        /// Zmniejszenie ilości akcji
        /// </summary>
        /// <param name="value">Ilość akcji o którą zmniejszamy</param>
        public void DecreeseQuantity(int value)
        {
            Quantity -= value;
        }
    }
}
