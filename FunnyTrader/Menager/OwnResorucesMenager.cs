using FunnyTrader.Entity;
using FunnyTrader.Menager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunnyTrader.Menager
{
    class OwnResorucesMenager : BaseStockMenager<OwnStocks>, IOwnResources
    {
        public Label MoneyLabel { get; set; }
        double moneyValue;

        /// <summary>
        /// Klasa przechowująca posiadające akcje i zosoby $
        /// </summary>
        /// <param name="money">Etykieta z ilością posiadanych $</param>
        public OwnResorucesMenager(Label money)
        {
            MoneyLabel = money;
            Double.TryParse(MoneyLabel.Text, out moneyValue);
        }
        /// <summary>
        /// Metoda do zakupu akcji
        /// </summary>
        /// <param name="value">Ilość akcji</param>
        /// <param name="name">Nazwa firmy któej kacje kupujemy</param>
        public void BuyStocks(int value, StockName name, double price)
        {
            if((price*value)>moneyValue) //Sprawdzenie czy użytkownik posiada pieniądze na daną ilość akcji
            {
                MessageBox.Show("Posiadasz zbyt mało $ aby zakupić podaną ilość akcji", "Brak wystarczających środków", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OwnStocks selected = GetItemByEnumName(name);
            if (selected == null)  //jeśli użytkownik nie posiada jeszcze akcji tego typu
            {
                AllStocks.Add(new OwnStocks(name, value)); //Dodanie akcji do listy
            }
            else //jeśli użytkownik posiada już akcje tego typu
            {
                selected.IncreeseQuantity(value); //Następuje zwiększenie wartości ilości tej akcji
            }
            moneyValue -= (price * value); //Obliczenie aktualnego stanu konta
            UpdateMoneyLabel(); //Aktualizacja tabeli
        }
        /// <summary>
        /// Motoda służąca do sprzedarzy akcji
        /// </summary>
        /// <param name="quantity">Ilość akcji do sprzedaży</param>
        /// <param name="name">Nazwa akcji do sprzedaży</param>
        /// <param name="price">Cena akcji do sprzedaży</param>
        public void SellStocks(int quantity, StockName name, double price)
        {
            OwnStocks stockToSell = AllStocks.LastOrDefault(p => p.stockName == name); //wyszukanie akcji po nazwie
            if(stockToSell == null) //jeśli nie znalieziona takie akcji
            {
                MessageBox.Show("Nie posiadasz takiej akcji", "Brak akcji w zasobach", MessageBoxButtons.OK, MessageBoxIcon.Information); //wyświetlenie błędu
                return; //zakończenie funkcji
            }
            if(quantity == stockToSell.Quantity) //jeśli sprzedano wszytskie akcji
            {
                AllStocks.Remove(stockToSell); //usuń pozycje z listy
            }
            else if(quantity < stockToSell.Quantity) //jeśli nie sprzedano wszystkich akcji danego rodzaju
            {
                stockToSell.DecreeseQuantity(quantity); //zmniejsz ilość akcji
            }
            else //przypadek gdy próbowano sprzedać więcej akcji niż gracz posiada
            {
                MessageBox.Show("Nie posiadasz wystarczającej ilości akcji", "Zbyt mało akcji w zasobach", MessageBoxButtons.OK, MessageBoxIcon.Information); //wyświetlenie błędu
                return; //zakończenie funkcji
            }
            moneyValue += (quantity * price); //dodanie pieniędzy
            UpdateMoneyLabel(); //Aktualizacja etykiety wyświetlanej ilości pieniędzy
        }
        /// <summary>
        /// Otrzymanie sumy wartości akcji i posiadanych pieniędzy
        /// </summary>
        /// <param name="stocksToBuy">Obiekt posiadajacy ceny akcji</param>
        /// <returns></returns>
        public double GetAllResorucesValue(StocksToBuyMenager stocksToBuy)
        {
            double allResourcesValue = moneyValue; //dodanie do wastości zasobów ilości posiadanych pieniędzy
            foreach(OwnStocks ownStock in AllStocks) //iteracja po wszytskich posiadanych akcjach
            {
                double stockPrice = stocksToBuy.GetPriceByEnumName(ownStock.stockName); //uzyskanie ceny danej akcji
                allResourcesValue += stockPrice * ownStock.Quantity; //dodanie do wartości zasobów ceny akcji 
            }
            return Math.Round(allResourcesValue, 2); //zwrócenie wartości zaokrąglonej do 2 miejsc po przecinku
        }
        /// <summary>
        /// Aktualizacja etykiety wyświetlającej ilość pieniędzy
        /// </summary>
        public void UpdateMoneyLabel()
        {
            MoneyLabel.Text = Math.Round(moneyValue,2).ToString();
        }
    }
}
