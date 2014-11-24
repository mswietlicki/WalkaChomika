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
using Ktos.Common;
namespace WalkaChomika
{
    public partial class MainWindow : Window
    {
        private readonly Zwierzę _pimpus;
        private readonly Zwierzę _lucjan;

        public MainWindow()
        {
            InitializeComponent();

            TraceListener debugListener = new TextBoxTraceListener(tbLog);
            Debug.Listeners.Add(debugListener);

            _pimpus = new ChomikSzaman("Pimpuś", 10);
            _lucjan = new Chomik("Lucjan");
        }

        private void NextTurnClick(object sender, RoutedEventArgs e)
        {
            if (_pimpus.CzyŻyje() && _lucjan.CzyŻyje())
            {
                _pimpus.Gryź(_lucjan);
                _lucjan.Gryź(_pimpus);

                Debug.WriteLine("Obiekt 1: {0}HP, Obiekt 2: {1}HP", _pimpus.HP, _lucjan.HP);
            }

            if (!_pimpus.CzyŻyje() || !_lucjan.CzyŻyje())
                Debug.WriteLine("Obiekt 1: {0}, Obiekt 2: {1}", _pimpus.CzyŻyje(), _lucjan.CzyŻyje());
        }
    }
}
