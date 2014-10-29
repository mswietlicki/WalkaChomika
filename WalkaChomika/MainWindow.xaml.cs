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
using System.Windows;

namespace WalkaChomika
{
    /// <summary>
    /// To jest klasa odpowiadająca głównemu okienku aplikacji
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// To jest funkcja, która uruchamia się w momencie kliknięcia przycisku przez użytkownika
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // tworzymy obiekt klasy Zwierzę, czyli konkretną zmienną
            // i nadajemy jej atrybuty od razu
            Zwierzę chomik = new Zwierzę()
            {
                Imię = "Pucuś",
                HP = 10,
                Mana = 0,
                Damage = 1
            };

            // tworzymy nowy obiekt klasy Zwierzę, a potem nadajemy mu po
            // kolei wartości jego atrybutów dostając się do każdego po kolei
            Zwierzę pies = new Zwierzę();
            pies.Imię = "Dino";
            pies.HP = 100;
            pies.Mana = 0;
            pies.Damage = 10;
            
            // robimy sobie zmienną do zliczania ugryzień
            int i = 0;

            // dopóki chomik żyje
            while (chomik.CzyŻyje())
            {
                // pies gryzie chomika - gryzienie zmniejsza ilość HP obiektu chomik
                pies.Gryź(chomik);

                // liczymy ugryzienia
                i++;
            }

            // kiedy chomik umarł, pokazujemy liczbę i w kontrolce o nazwie "kawalekTekstu"
            kawalekTekstu.Text = i.ToString();

            // i wywołujemy funkcję Test() na klasie MainWindow
            // powinno się używać this.Test(), ale bez tego też zadziała
            Test();
        }

        void Test()
        {
            // zmieniamy wartość przezroczystosci kontrolki o nazwie "kawalekTekstu" na 50%
            kawalekTekstu.Opacity = 0.5;
        }
    }
}
