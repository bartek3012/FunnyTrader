using FunnyTrader.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunnyTrader.Menager
{/// <summary>
/// Klasa akstrakcyjna zarządzająca akcjami
/// </summary>
/// <typeparam name="T">Parametr klasy Stock lub inny po niej dziewziczącej czyli: OwnStock i StockToBuy</typeparam>
   abstract class BaseStockMenager<T> where T: Stock
    {
        public List<T> AllStocks { get; set; } //Lista przechowująca akcje
        /// <summary>
        /// Metoda zarządzająca akcjami i posiadajace ich listę
        /// </summary>
        public BaseStockMenager()
        {
            AllStocks = new List<T>();
        }
        /// <summary>
        /// Zwrócenie akcji przez enum
        /// </summary>
        /// <param name="enumName"></param>
        /// <returns></returns>
        public T GetItemByEnumName(StockName enumName)
        {
            return AllStocks.FirstOrDefault(p => p.stockName == enumName);
        }
        /// <summary>
        /// Uzyskanie nazwy typu enum ze stringa
        /// </summary>
        /// <param name="nameToConvert">Nazwa do znalezienia stringa</param>
        /// <param name="enumName">Zmienna typu enum do przypisania wartości po konwersji</param>
        /// <returns></returns>
        public bool GetEnumNameByString(string nameToConvert, out StockName enumName)
        {
            //Poprawnie do typu enum zostaną skonwertowane również liczby czego chcemy uniknąć, w tym celu dodano warunek, który mówi, że konwersja jest poprawna,
            //gdy wartości string nie można skonwertowac do inta 
            int checkIfNumber; 
            if(Enum.TryParse(nameToConvert, out enumName) == false || Int32.TryParse(nameToConvert, out checkIfNumber) == true)
            {
                MessageBox.Show("Podano nieprawidłową nazwę akcji", "Błędna nazwa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        /// <summary>
        /// Przypisanie akcji, w przypadku błędznego przypisania zwracana jest wartość false
        /// </summary>
        /// <param name="name">Nazwa akcji do wyszukania</param>
        /// <param name="result"><Referencja akcji do zwrócenia/param>
        /// <returns></returns>
        public bool GetItemByStringName(string name,out T result)
        {
            bool isCorrect;
            StockName stockName;
            isCorrect = Enum.TryParse(name, out stockName); //Sprawdzenie czy konwersja na typ enum zakończyła sie powodzeniem
            if(isCorrect == true) //jeśli tak
            {
                result = AllStocks.FirstOrDefault(p => p.stockName == stockName); //Wyszukanie obiektu o uzyskanej nazwie enum
                if(result == null) //jeśli nie znaleziono akcji o takiej nazwie
                {
                    MessageBox.Show("Brak akcji wyszukiwanego typu", "Błędna wartość", MessageBoxButtons.OK, MessageBoxIcon.Warning); //wyświetlenie błędu
                    return false;
                }
                return true;
            }
            else //jeśli konwersja do enum zakończyła się niepowodzeniem
            {
                result = null;
                MessageBox.Show("Podana wartość nie pasuje do żadnej nazwy akcji", "Błędna wartość", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        /// <summary>
        /// Zwrócenie narodowości za pomocą nazwy typu string
        /// </summary>
        /// <param name="national">Wyszukiwana narodwość</param>
        /// <param name="result">Akcja do przypisania</param>
        /// <returns></returns>
        public bool GetItemByNational(string national, out T result)
        {
            result = AllStocks.FirstOrDefault(p => p.Country == national); //Próba zanlezienia narodowości
            if(result == null)
            {
                MessageBox.Show("Podano błędną narodowość", "Błędna wartość", MessageBoxButtons.OK, MessageBoxIcon.Warning); //jeśli nie znaleziono, wyświetlony jest błąd
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
