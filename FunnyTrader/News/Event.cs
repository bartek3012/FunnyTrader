using FunnyTrader.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyTrader.News
{
   public class Event
    {
        public readonly string title;
        public readonly string textNews;
        public readonly string secondPartPath;
        public double []ChangePrice { get;private set; } //Wartości zmian kursu spowodowanych wydarzeniami
        /// <summary>
        /// Klasa przechowująca wydarzenia losowe, wpływające wa kursy akcji
        /// </summary>
        /// <param name="titleNews">Tytuł newsu</param>
        /// <param name="_textNews">Teskt newsu</param>
        /// <param name="pathPart">Nazwa grafiki z rozszerzeniem</param>
        public Event(string titleNews, string _textNews, string pathPart)
        {
            title = titleNews;
            textNews = _textNews;
            secondPartPath = pathPart;
            ChangePrice = new double[] { 0, 0, 0, 0 };
        }
        /// <summary>
        /// Nadanie wartości zmian akcji
        /// </summary>
        /// <param name="stockName">Nazwa akcji</param>
        /// <param name="value">Wartość zmiany</param>
        public void SetChangePrice(StockName stockName, double value)
        {
            ChangePrice[(int)stockName] = value;
        }
    }
}
