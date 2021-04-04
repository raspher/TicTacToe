using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool MonitorTrybJednoosobowy;

        public MainWindow()
        {
            InitializeComponent();
            MonitorTrybJednoosobowy = (bool)PoleTrybJednoosobowy.IsChecked;
        }

        public void UIRefresh()
        {
            PoleTura.Content = Engine.tura;
            // Zmień stringi w wynikach

            if (PoleTrybJednoosobowy.IsChecked == true)
            {
                PoleGracz1.Content = "Gracz";
                PoleGracz2.Content = "Komputer";
            }
            else
            {
                PoleGracz1.Content = "Gracz 1";
                PoleGracz2.Content = "Gracz 2";
            }

            PoleGracz1Wynik.Content = Engine.wynikgracz1;
            PoleGracz2Wynik.Content = Engine.wynikgracz2;

            if (Engine.aktualnygracz == Engine.Gracz1)
            {
                PoleGracz1.Background = Brushes.LightSeaGreen;
                PoleGracz2.Background = null;
            } else
            {
                PoleGracz2.Background = Brushes.LightSeaGreen;
                PoleGracz1.Background = null;
            }

            if (Engine.plansza[0,0] != 0)
                Matrix1.Content = Engine.plansza[0, 0] == 1 ? "O" : "X";
            if (Engine.plansza[0, 1] != 0)
                Matrix2.Content = Engine.plansza[0, 1] == 1 ? "O" : "X";
            if (Engine.plansza[0, 2] != 0)
                Matrix3.Content = Engine.plansza[0, 2] == 1 ? "O" : "X";
            if (Engine.plansza[1, 0] != 0)
                Matrix4.Content = Engine.plansza[1, 0] == 1 ? "O" : "X";
            if (Engine.plansza[1, 1] != 0)
                Matrix5.Content = Engine.plansza[1, 1] == 1 ? "O" : "X";
            if (Engine.plansza[1, 2] != 0)
                Matrix6.Content = Engine.plansza[1, 2] == 1 ? "O" : "X";
            if (Engine.plansza[2, 0] != 0)
                Matrix7.Content = Engine.plansza[2, 0] == 1 ? "O" : "X";
            if (Engine.plansza[2, 1] != 0)
                Matrix8.Content = Engine.plansza[2, 1] == 1 ? "O" : "X";
            if (Engine.plansza[2, 2] != 0)
                Matrix9.Content = Engine.plansza[2, 2] == 1 ? "O" : "X";
        }

        private void Button_Click_Nowa_Gra(object sender, RoutedEventArgs e)
        {
            Engine.NowaGra();

            // zeruj wyniki, jeśli zmienił się tryb gry

            if (MonitorTrybJednoosobowy != PoleTrybJednoosobowy.IsChecked)
            {
                MonitorTrybJednoosobowy = (bool)PoleTrybJednoosobowy.IsChecked;
                Engine.ZmianaTrybu();
                PoleGracz1Wynik.Content = Engine.wynikgracz1;
                PoleGracz2Wynik.Content = Engine.wynikgracz2;
            }

            if (MonitorTrybJednoosobowy && Engine.Gracz2 == "O")
            {
                Engine.Bot();
            }

            Matrix1.Content = "";
            Matrix2.Content = "";
            Matrix3.Content = "";
            Matrix4.Content = "";
            Matrix5.Content = "";
            Matrix6.Content = "";
            Matrix7.Content = "";
            Matrix8.Content = "";
            Matrix9.Content = "";

            UIRefresh();
        }

        private void Button_Click_Historia(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Matrix1.Content.Equals("") && Engine.CzyWygrana() == 0)
            {
                Matrix1.Content = Engine.aktualnygracz;

                Engine.Wstaw(0, 0);
                if (MonitorTrybJednoosobowy && Engine.CzyWygrana() == 0)
                    Engine.Bot();
                UIRefresh();
            }  
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Matrix2.Content.Equals("") && Engine.CzyWygrana() == 0)
            {
                Matrix2.Content = Engine.aktualnygracz;

                Engine.Wstaw(0, 1);
                if (MonitorTrybJednoosobowy && Engine.CzyWygrana() == 0)
                    Engine.Bot();
                UIRefresh();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Matrix3.Content.Equals("") && Engine.CzyWygrana() == 0)
            {
                Matrix3.Content = Engine.aktualnygracz;

                Engine.Wstaw(0, 2);
                if (MonitorTrybJednoosobowy && Engine.CzyWygrana() == 0)
                    Engine.Bot();
                UIRefresh();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (Matrix4.Content.Equals("") && Engine.CzyWygrana() == 0)
            {
                Matrix4.Content = Engine.aktualnygracz;

                Engine.Wstaw(1, 0);
                if (MonitorTrybJednoosobowy && Engine.CzyWygrana() == 0)
                    Engine.Bot();
                UIRefresh();
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (Matrix5.Content.Equals("") && Engine.CzyWygrana() == 0)
            {
                Matrix5.Content = Engine.aktualnygracz;

                Engine.Wstaw(1, 1);
                if (MonitorTrybJednoosobowy && Engine.CzyWygrana() == 0)
                    Engine.Bot();
                UIRefresh();
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (Matrix6.Content.Equals("") && Engine.CzyWygrana() == 0)
            {
                Matrix6.Content = Engine.aktualnygracz;

                Engine.Wstaw(1, 2);
                if (MonitorTrybJednoosobowy && Engine.CzyWygrana() == 0)
                    Engine.Bot();
                UIRefresh();
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (Matrix7.Content.Equals("") && Engine.CzyWygrana() == 0)
            {
                Matrix7.Content = Engine.aktualnygracz;

                Engine.Wstaw(2, 0);
                if (MonitorTrybJednoosobowy && Engine.CzyWygrana() == 0)
                    Engine.Bot();
                UIRefresh();
            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (Matrix8.Content.Equals("") && Engine.CzyWygrana() == 0)
            {
                Matrix8.Content = Engine.aktualnygracz;

                Engine.Wstaw(2, 1);
                if (MonitorTrybJednoosobowy && Engine.CzyWygrana() == 0)
                    Engine.Bot();
                UIRefresh();
            }
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            if (Matrix9.Content.Equals("") && Engine.CzyWygrana() == 0)
            {
                Matrix9.Content = Engine.aktualnygracz;

                Engine.Wstaw(2, 2);
                if (MonitorTrybJednoosobowy && Engine.CzyWygrana() == 0)
                    Engine.Bot();
                UIRefresh();
            }
        }
    }
}
