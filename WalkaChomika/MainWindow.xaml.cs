#region License
/*
 * Written in 2014 by Marcin Badurowicz <m dot badurowicz at pollub dot pl>
 *
 * To the extent possible under law, the author(s) have dedicated
 * all copyright and related and neighboring rights to this 
 * software to the public domain worldwide. This software is 
 * distributed without any warranty. 
 *
 * You should have received a copy of the CC0 Public Domain 
 * Dedication along with this software. If not, see 
 * <http://creativecommons.org/publicdomain/zero/1.0/>. 
 */
#endregion
using System.Diagnostics;
using System.Windows;

namespace WalkaChomika
{
    /// <summary>
    /// To jest klasa odpowiadająca głównemu okienku aplikacji
    /// </summary>
    public partial class MainWindow : Window
    {
        private object c;
        private object d;

        /// <summary>
        /// Konstruktor klasy głównego okienka aplikacji
        /// </summary>
        public MainWindow()
        {
            // to jest standardowa metoda ustawiająca komponenty
            InitializeComponent();

            // tutaj się dzieje nieistotna magia - przekierowywany jest strumień informacji testowych
            // do pola tekstowego w okienku aplikacji
            TraceListener debugListener = new Ktos.Common.TextBoxTraceListener(tbLog);
            Debug.Listeners.Add(debugListener);

            // tworzone są nowe instancje walczących zwierzątek
            this.c = new ChomikSzaman("Pimpuś", 10);         
            this.d = new Chomik("Lucjan");
        }

        /// <summary>
        /// Funkcja obsługująca naciśnięcie przycisku Następnej Tury
        /// </summary>
        /// <param name="sender">Obiekt, który uruchomił zdarzenie</param>
        /// <param name="e">Parametry zdarzenia</param>
        private void NextTurnClick(object sender, RoutedEventArgs e)
        {
            // jeśli c i d są zwierzętami
            if (c is Zwierzę && d is Zwierzę)
            {
                if (((Zwierzę)c).CzyŻyje() && ((Zwierzę)d).CzyŻyje())
                {
                    ((Zwierzę)c).Gryź((Zwierzę)d);
                    ((Zwierzę)d).Gryź((Zwierzę)c);

                    Debug.WriteLine(string.Format("Obiekt 1: {0}HP, Obiekt 2: {1}HP", ((Zwierzę)c).HP, ((Zwierzę)d).HP));
                }
                else
                    Debug.WriteLine("Obiekt 1: {0}, Obiekt 2: {1}", ((Zwierzę)c).CzyŻyje(), ((Zwierzę)d).CzyŻyje());
            }
            else
                Debug.WriteLine("Co najmniej jedno z zawodników nie jest zwierzęciem.");

            
        }
    }
}
