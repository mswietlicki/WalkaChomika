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
using System;

namespace WalkaChomika
{
    /// <summary>
    /// To jest klasa odpowiadająca głównemu okienku aplikacji
    /// </summary>
    public partial class MainWindow : Window
    {
        private Zwierzę gracz1;
        private Zwierzę gracz2;

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
            gracz1 = new ChomikSzaman("Pimpuś", 100);
            gracz2 = new Jednorożec("Rafał", 15);
        }

        /// <summary>
        /// Funkcja obsługująca naciśnięcie przycisku Następnej Tury
        /// </summary>
        /// <param name="sender">Obiekt, który uruchomił zdarzenie</param>
        /// <param name="e">Parametry zdarzenia</param>
        private void NextTurnClick(object sender, RoutedEventArgs e)
        {
            Tura(gracz1, gracz2);

            PokażStan();

            Tura(gracz2, gracz1);

            PokażStan();

        }

        private void PokażStan()
        {
            if (!gracz1.CzyŻyje() || !gracz2.CzyŻyje())
                Debug.WriteLine(gracz1.CzyŻyje() ? "Gracz 2" : "Gracz 1");
            else
            {
                Debug.WriteLine(string.Format("Obiekt 1: {0}", gracz1));
                Debug.WriteLine(string.Format("Obiekt 2: {0}", gracz2));
            }
        }

        private void Tura(Zwierzę gracz, Zwierzę gracz2)
        {
            Random r = new Random();
            var w = r.Next(10);
            var zaatakował = false;

            if (gracz is ZwierzęMagiczne)
            {
                if (w >= 7)
                {
                    (gracz as ZwierzęMagiczne).AtakujMagicznie(gracz2);
                    zaatakował = true;
                }
            }

            if (gracz is ILatający)
            {
                if (w >= 8)
                {
                    (gracz as ILatający).Lataj();
                    zaatakował = true;
                }
            }

            if (!zaatakował)
                gracz.Gryź(gracz2);
        }
    }
}
