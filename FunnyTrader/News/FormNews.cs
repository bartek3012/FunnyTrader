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

namespace FunnyTrader.News
{
    public partial class FormNews : Form
    {
       private Timer timerCounter;
        /// <summary>
        /// Konstruktor klasy okna nowego zdarzenia
        /// </summary>
        /// <param name="eventNews">Zdarzenie do wyświetlenia</param>
        /// <param name="timer">Główny czas programu</param>
       public FormNews(Event eventNews,Timer timer)
        {
            timerCounter = timer;//
            timerCounter.Stop(); //Zatrzymanie zegara programu
            InitializeComponent();
            labelTitle.Text = eventNews.title; //Uzupełnienie etykiety z tytułem artykułu
            labelNewsText.Text = eventNews.textNews; //Usupełnienie treści artykułu
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, eventNews.secondPartPath); //Ścieżka do odczytu pliku na podstawie ściążeki bazowej i nazwy pliku
            Image imageNews = Image.FromFile(path); //Otworzenie obrazka
            pictureBoxNews.Image = imageNews; //Wyświetlenie go w pictureBoxe
        }
       /// <summary>
       /// Zdarzenie kliknięcia w przycisk zamykający okna
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            timerCounter.Start(); //Wznowienie zegara
            this.Close(); //Zamknięcie okna
        }
    }
}
