using FunnyTrader.Entity;
using FunnyTrader.Menager;
using FunnyTrader.News;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunnyTrader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private const int START = 83; //Stała określająca 
        private StocksToBuyMenager stocksToBuy; //Obiekt klasy obsługującej akcje do kupienia
        private OwnResorucesMenager ownResoruces; //Obiekt kalsy obsługujący własne akcje
        private EventMenager newsEvent; //Obiekt klasy zarządzajacy zdarzeniami
        private int counter = START; //Licznik do zakończenia gry
        private void MainForm_Load(object sender, EventArgs e)
        {
            //Tworzenie obiektu akcji do kupienia i przypisanie im etykiet zmian ceny i wartości akcji
            stocksToBuy = new StocksToBuyMenager(labelVolkswagenValue, labelVolkswagenChange, labelMicrosoftValue, labelMicrosoftChange,
                labelTauronValue, labelTauronChange, labelXaomiValue, labelXaomiChange);

            ownResoruces = new OwnResorucesMenager(labelOwnMoneyValue); //Tworzenie obiektu i przekazanie referencji na etykiete z ilością monet
            newsEvent = new EventMenager(timerCounter); //Tworzenie obiektu i przekazanie timera 
            timerCounter.Start(); //Start zegara
        }

        /// <summary>
        /// Metoda odświeżająca dane w tabeli
        /// </summary>
        private void RefreshDataGrid()
        {
            //Przypisanie danych do tabeli
            dataGridStocks.DataSource = typeof(List<OwnStocks>);
            dataGridStocks.DataSource = ownResoruces.AllStocks;
            //Podpisy kolumn
            dataGridStocks.Columns[0].HeaderCell.Value = "Ilość"; 
            dataGridStocks.Columns[1].HeaderCell.Value = "Firma";
            dataGridStocks.Columns[2].HeaderCell.Value = "Kraj";
        }

        /// <summary>
        /// Po kliknięciu na pole textBoxy mają usuwać posiadaną zawartość (podpowiedzi)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_Click(object sender, EventArgs e)
        {
            (sender as TextBox).Text = "";
        }

        /// <summary>
        /// Zdarzenie kliknięcia w przycisk do kupna akcji
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBuy_Click(object sender, EventArgs e)
        {
            int quntity; //ilość akcji do zakupu
            if ((sender as Button) == buttonBuyVolkswagen) //Sprawdzenie którą akcję użytkownik kupuje
            {
                if (Int32.TryParse(textBoxVolkswagenQuantity.Text, out quntity) == false) //Próba konwersji ilości akcji do zakupu
                {
                    MessageBox.Show("W miejscu na ilość akcji podano błędną wartość", "Błędna wartość", MessageBoxButtons.OK, MessageBoxIcon.Warning); //jeśli wartość nie jest prawidłowa wyświetlenie komunikatu
                    return; //przerwanie funkcji, ponieważ ilość akcji jest błędna
                }
                ownResoruces.BuyStocks(quntity, StockName.Volkswagen, stocksToBuy.GetPriceByEnumName(StockName.Volkswagen)); //Wywołanie metody kupna akcji
                textBoxVolkswagenQuantity.Text = "(ilość)"; //Przywrócenie domyślnego tekstu w polu na wpisnaie ilosci akcji
            }
            else if ((sender as Button) == buttonBuyMicrosoft) //Sprawdzenie którą akcję użytkownik kupuje
            {
                if (Int32.TryParse(textBoxMicrosoftQuantity.Text, out quntity) == false) //Próba konwersji ilości akcji do zakupu
                {
                    MessageBox.Show("W miejscu na ilość akcji podano błędną wartość", "Błędna wartość", MessageBoxButtons.OK, MessageBoxIcon.Warning); //jeśli wartość nie jest prawidłowa wyświetlenie komunikatu
                    return; //przerwanie funkcji, ponieważ ilość akcji jest błędna
                }
                ownResoruces.BuyStocks(quntity, StockName.Microsoft, stocksToBuy.GetPriceByEnumName(StockName.Microsoft)); //Wywołanie metody kupna akcji
                textBoxMicrosoftQuantity.Text = "(ilość)"; //Przywrócenie domyślnego tekstu w polu na wpisnaie ilosci akcji
            }
            else if ((sender as Button) == buttonBuyTauron) //Sprawdzenie którą akcję użytkownik kupuje
            {
                if (Int32.TryParse(textBoxTauronQuantity.Text, out quntity) == false) //Próba konwersji ilości akcji do zakupu
                {
                    MessageBox.Show("W miejscu na ilość akcji podano błędną wartość", "Błędna wartość", MessageBoxButtons.OK, MessageBoxIcon.Warning); //jeśli wartość nie jest prawidłowa wyświetlenie komunikatu
                    return; //przerwanie funkcji, ponieważ ilość akcji jest błędna
                }
                ownResoruces.BuyStocks(quntity, StockName.Tauron, stocksToBuy.GetPriceByEnumName(StockName.Tauron)); //Wywołanie metody kupna akcji
                textBoxTauronQuantity.Text = "(ilość)"; //Przywrócenie domyślnego tekstu w polu na wpisnaie ilosci akcji
            }
            else if ((sender as Button) == buttonBuyXaomi) //Sprawdzenie którą akcję użytkownik kupuje
            {
                if (Int32.TryParse(textBoxXaomiQuantity.Text, out quntity) == false) //Próba konwersji ilości akcji do zakupu
                {
                    MessageBox.Show("W miejscu na ilość akcji podano błędną wartość", "Błędna wartość", MessageBoxButtons.OK, MessageBoxIcon.Warning); //jeśli wartość nie jest prawidłowa wyświetlenie komunikatu
                    return; //przerwanie funkcji, ponieważ ilość akcji jest błędna
                }
                ownResoruces.BuyStocks(quntity, StockName.Xaomi, stocksToBuy.GetPriceByEnumName(StockName.Xaomi)); //Wywołanie metody kupna akcji
                textBoxXaomiQuantity.Text = "(ilość)"; //Przywrócenie domyślnego tekstu w polu na wpisnaie ilosci akcji
            }
            RefreshDataGrid(); //Odświeżenie tabeli
        }

        /// <summary>
        /// Metoda wywołana co sekunde (tik zegara)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerCounter_Tick(object sender, EventArgs e)
        {
            counter--; //Zmniejszenie licznika odliczającego do końca gry
            labelSecondToEnd.Text = counter.ToString(); //Aktualizacja etykiety z tym licznikiem
            if(counter == 0) //Gdy zegar jest zero, następuje koniec gry
            {
                timerCounter.Stop(); //Zatrzymanie zegara
                var answer = MessageBox.Show($"Koniec gry, Twój wynik to {labelAllResourceValue.Text}. Czy chcesz zagrać ponownie", "Koniec gry", MessageBoxButtons.YesNo, MessageBoxIcon.Question); //Wiadomość z wynikiem i pytaniem czy grasz ponownie

                if(answer == DialogResult.No) //Jeśli nie grasz ponownie
                {
                    this.Close(); //Zamknij aplikację
                }
                else
                {
                    Application.Restart(); //Jeśli chcesz zagrać ponownie następuje restart
                }
            }
            else if(counter > START - 4) //Przez pierwsze 4 sekundy nie następujeą zdarzenia losowe
            {
                stocksToBuy.MakeChange(new double[] { 0, 0, 0, 0}); //Zmiana kosztów akcji, bez dodatkowej ingarencji ze zdarzeń
            }
            else
            {
            stocksToBuy.MakeChange(newsEvent.MakeEvent()); //Do każdych kolejnych sekund gry następuje zminan akcji, biorąca pod uwagę zdarzenie losowe
            }
            labelAllResourceValue.Text = ownResoruces.GetAllResorucesValue(stocksToBuy).ToString(); //Wyświetlenie na etykiecie wartości pieniędzy + suma wartości akcji
        }
        /// <summary>
        /// Przycisk sprzedarzy akcji której nazwa wpisana jest w checkboxe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSell_Click(object sender, EventArgs e)
        {
            int quantityToSell; //ilość akcji
            if ((Int32.TryParse(textBoxSellQuantity.Text, out quantityToSell) == false)) //Sprawdzenie czy ilość akcji jest liczbą, jeśli nie przerwanie funkcji i wysłanie komunikatu
            {
                MessageBox.Show("Nie podano poprawnie liczby", "Błędna wartość", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            StockName name; //zmienna na nazwę akcji
            if (ownResoruces.GetEnumNameByString(textBoxFindByName.Text, out name) == false) //jeśli podany string nie pasuje do enum, zakończ funkcje
            {
                return;
            }
; 
            ownResoruces.SellStocks(quantityToSell, name, stocksToBuy.GetPriceByEnumName(name)); //Dokonanie sprzedaży akcji
            RefreshDataGrid(); //Odświeżenie tablei
        }
        /// <summary>
        /// Zdarzenie kliknięcia w pole dataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridStocks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Blok try/catch ma na celu uniknięcie wyrzucenia wyjątku jesli użytkownik kliknie w nazwy kolumn tabeli
            try
            {
                int index = e.RowIndex; //Indeks kilkniętego wiersza
                DataGridViewRow selectedRow = dataGridStocks.Rows[index]; //Pobranie danych z wybranego wiersza
                //Pzypisanie wierszy do odpowiednich textBoxów
                textBoxFindByName.Text = selectedRow.Cells[1].Value.ToString();
                textBoxFintByCountry.Text = selectedRow.Cells[2].Value.ToString();
                textBoxSellQuantity.Text = selectedRow.Cells[0].Value.ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Brak możliwości zaznaczenia pola");
            }

        }
        /// <summary>
        /// Funkcja do znajdywania kupionej akcji przez nazwę
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFindByName_Click(object sender, EventArgs e)
        {
            OwnStocks result;
            if (ownResoruces.GetItemByStringName(textBoxFindByName.Text, out result) == true) //jeśli otrzymano item
            {
                FillNameCountryQuantityText(result); //Wypełnienie textBoxów danymi wyszukanej akcji
            }
        }
        /// <summary>
        /// Metoda słożąca do uzupełnienie TextBoxów danymi posiadanej akcji
        /// </summary>
        /// <param name="ownStocks">Posiadana akcja do pobrania dancyh</param>
        private void FillNameCountryQuantityText(OwnStocks ownStocks)
        {
            textBoxFindByName.Text = ownStocks.stockName.ToString(); //Pole nazwą firmy
            textBoxFintByCountry.Text = ownStocks.Country; //Pole z krajem
            textBoxSellQuantity.Text = ownStocks.Quantity.ToString(); //Pole z ilością akcji
        }
        /// <summary>
        /// Znajdywanie akcji poprzez kraj
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFindByCountry_Click(object sender, EventArgs e)
        {
            OwnStocks result;
            if (ownResoruces.GetItemByNational(textBoxFintByCountry.Text, out result) == true) //Jeśli konwersja jest prawidłowa
            {
                FillNameCountryQuantityText(result); //Wyzupełnij dane znalezioną akcją
            }
        }
    }
}
