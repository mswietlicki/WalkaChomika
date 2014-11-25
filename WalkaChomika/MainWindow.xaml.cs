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
using System;
using System.Diagnostics;
using System.Windows;
using WalkaChomika.Models;

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

        private bool _lastGracz = false;

        /// <summary>
        /// Funkcja obsługująca naciśnięcie przycisku Następnej Tury
        /// </summary>
        /// <param name="sender">Obiekt, który uruchomił zdarzenie</param>
        /// <param name="e">Parametry zdarzenia</param>
        private void NextTurnClick(object sender, RoutedEventArgs e)
        {
            if (_lastGracz)
                Tura(gracz1, gracz2);
            else
                Tura(gracz2, gracz1);

            PokażStan();

            if (!gracz1.CzyŻyje() || !gracz2.CzyŻyje())
            {
                btnNextTurn.IsEnabled = false;
            }

            _lastGracz = !_lastGracz;
        }

        private void PokażStan()
        {
            if (!gracz1.CzyŻyje() || !gracz2.CzyŻyje())
            {
                Debug.WriteLine(gracz1.CzyŻyje() ? gracz1.Imię + " wygrał!" : gracz2.Imię + " wygrał!");
            }
            else
            {
                Debug.WriteLine(string.Format("Gracz 1: {0}", gracz1));
                Debug.WriteLine(string.Format("Gracz 2: {0}", gracz2));
            }

            scroll.ScrollToBottom();
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
                    Debug.WriteLine(string.Format("{0} zaatakował magicznie {1}!", gracz.Imię, gracz2.Imię));
                    zaatakował = true;
                }
            }

            if (gracz is ILatający)
            {
                if (w >= 8 && !zaatakował)
                {
                    (gracz as ILatający).Lataj();
                    Debug.WriteLine(string.Format("{0} odleciał!", gracz.Imię));
                    zaatakował = true;
                }
            }

            if (!zaatakował)
            {
                gracz.Gryź(gracz2);
                Debug.WriteLine(string.Format("{0} ugryzł {1}!", gracz.Imię, gracz2.Imię));
            }
        }
    }
}
