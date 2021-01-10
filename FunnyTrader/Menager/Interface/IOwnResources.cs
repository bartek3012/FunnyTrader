using FunnyTrader.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunnyTrader.Menager.Interface
{
    interface IOwnResources
    {
        Label MoneyLabel { get; set; } //Etykieta przechowująca liczbę dolarów gracza
        void BuyStocks(int value, StockName name, double price); //Metoda do kupowania akcji
        void SellStocks(int quantity, StockName name, double price); //Motoda do sprzedawani akcji
        void UpdateMoneyLabel(); //Aktualizacja etykiety

    }
}
