using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using WalkaChomika.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WalkaChomika.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private Zwierzę gracz1;

        public Zwierzę Gracz1
        {
            get { return gracz1; }
            set
            {
                if (this.gracz1 != value)
                {
                    gracz1 = value;
                    OnPropertyChanged("Gracz1");
                }
            }
        }

        private Zwierzę gracz2;

        public Zwierzę Gracz2
        {
            get { return gracz2; }
            set
            {
                if (this.gracz2 != value)
                {
                    gracz2 = value;
                    OnPropertyChanged("Gracz2");
                }
            }
        }

        private String statusMessage;

        public String StatusMessage
        {
            get { return statusMessage; }
            set
            {
                if (this.statusMessage != value)
                {
                    statusMessage = value;
                    OnPropertyChanged("StatusMessage");
                }
            }
        }

        private String gracz1Imię;

        public String Gracz1Imię
        {
            get { return gracz1Imię; }
            set
            {
                if (this.gracz1Imię != value)
                {
                    gracz1Imię = value;
                    OnPropertyChanged("Gracz1Imię");
                }
            }
        }

        private String gracz2Imię;

        public String Gracz2Imię
        {
            get { return gracz2Imię; }
            set
            {
                if (this.gracz2Imię != value)
                {
                    gracz2Imię = value;
                    OnPropertyChanged("Gracz2Imię");
                }
            }
        }

        public MainPage()
        {
            this.InitializeComponent();
            this.StatusMessage = "Rozpocznij grę";
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
#if WINDOWS_PHONE_APP
            await StatusBar.GetForCurrentView().HideAsync();
#endif
            this.DataContext = this;
        }

        private bool _lastGracz = false;

        /// <summary>
        /// Pokazywanie stanu gracza - czy żyje, czy nie, jakie ma statystyki
        /// </summary>
        private void PokażStan()
        {
            if (!gracz1.CzyŻyje() || !gracz2.CzyŻyje())
            {
                this.StatusMessage = gracz1.CzyŻyje() ? gracz1.Imię + " wygrał!" : gracz2.Imię + " wygrał!";
            }
            //else
            //{
            //    this.Gracz1HPTextBlock.Text = gracz1.HP + " HP";
            //    this.Gracz1ManaTextBlock.Text = gracz1.Mana + " Mana";

            //    this.Gracz2HPTextBlock.Text = gracz2.HP + " HP";
            //    this.Gracz2ManaTextBlock.Text = gracz2.Mana + " Mana";
            //}
        }

        /// <summary>
        /// Obsługa kolejnej tury - gracz atakuje gracz2, losując typ ataku w zależności od jego umiejętności
        /// </summary>
        /// <param name="gracz">Gracz atakujący</param>
        /// <param name="gracz2">Gracz atakowany</param>
        private void Tura(Zwierzę gracz, Zwierzę gracz2)
        {
            Random r = new Random();
            var w = r.Next(10);
            var zaatakował = false;

            if (gracz is ZwierzęMagiczne)
            {
                // 30% szans na atak magiczny
                if (w >= 7)
                {
                    (gracz as ZwierzęMagiczne).AtakujMagicznie(gracz2);
                    this.StatusMessage = string.Format("{0} zaatakował magicznie {1}!", gracz.Imię, gracz2.Imię);
                    zaatakował = true;
                }
            }

            if (gracz is ILatający)
            {
                // 20% szans na odlot
                if (w >= 8 && !zaatakował)
                {
                    (gracz as ILatający).Lataj();
                    this.StatusMessage = string.Format("{0} odleciał!", gracz.Imię);
                    zaatakował = true;
                }
            }

            // jeżeli nie zaatakował wcześniej w inny sposób, to po prostu gryzie
            if (!zaatakował)
            {
                gracz.Gryź(gracz2);
                this.StatusMessage = string.Format("{0} ugryzł {1}!", gracz.Imię, gracz2.Imię);
            }
        }

        private void NextTurnButton_Click(object sender, RoutedEventArgs e)
        {
            if (_lastGracz)
                Tura(gracz1, gracz2);
            else
                Tura(gracz2, gracz1);

            PokażStan();

            if (!gracz1.CzyŻyje() || !gracz2.CzyŻyje())
            {
                this.NextTurnButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                this.ResetGameButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }

            _lastGracz = !_lastGracz;
        }

        private void ResetGameButton_Click(object sender, RoutedEventArgs e)
        {
            ResetGame();
        }

        private void ResetGame()
        {
            this.Gracz1 = new ArmiaChomików(25, this.Gracz1Imię);
            this.Gracz2 = new Jednorożec(this.Gracz2Imię, 15);
            this.StatusMessage = String.Empty;

            this.NextTurnButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
            this.ResetGameButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

            //this.Gracz1ImięTextBlock.Text = gracz1.Imię;
            //this.Gracz2ImięTextBlock.Text = gracz2.Imię;

            this.PokażStan();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}