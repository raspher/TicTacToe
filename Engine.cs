using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    static class Engine
    {
        public static string Gracz1, Gracz2, aktualnygracz = "O";
        static Random random = new Random();
        public static int tura = 0, wynikgracz1 = 0, wynikgracz2 = 0;
        public static int[,] plansza = new int[3, 3];


        public static void NowaGra()
        {
            // Losuj znaki
            if (random.Next() % 2 == 0)
            {
                Gracz1 = "X";
                Gracz2 = "O";
            }
            else
            {
                Gracz1 = "O";
                Gracz2 = "X";
            }

            // czyść planszę
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    plansza[i, j] = 0;

            // zeruj tury
            tura = 0;
            aktualnygracz = "O";
        }

        public static void ZmianaTrybu()
        {
            wynikgracz1 = 0;
            wynikgracz2 = 0;
        }

        public static void Wstaw(int x, int y)
        {
            if (plansza[x, y] != 0)
                return;
            plansza[x, y] = aktualnygracz == "O" ? 1 : -1;
            var wynik = CzyWygrana();
            if (wynik == 0)
                NastepnaTura();
            else
            {
                if (wynik == 1)
                    _ = Gracz1 == "O" ? wynikgracz1++ : wynikgracz2++;
                if (wynik == -1)
                    _ = Gracz1 == "X" ? wynikgracz1++ : wynikgracz2++;
            }

            Console.WriteLine("\nStan planszy:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($" {plansza[i, j]} ");
                }
                Console.Write("\n");
            }
        }

        private static void NastepnaTura()
        {
            aktualnygracz = aktualnygracz == "O" ? "X" : "O";
            tura++;
        }

        public static int CzyWygrana()
        {
            int przekatna1 = 0, przekatna2 = 0;
            for (int i = 0; i < 3; i++)
            {
                int wiersz = 0, kolumna = 0;
                for (int j = 0; j < 3; j++)
                {
                    // zbieranie danych
                    wiersz += plansza[i, j];
                    kolumna += plansza[j, i];
                    if (i == j)
                        przekatna1 += plansza[i, j];
                    if (i + j == 2)
                        przekatna2 += plansza[i, j];
                }

                if (kolumna == 3 || wiersz == 3)
                    return 1; // O
                if (kolumna == -3 || wiersz == -3)
                    return -1;  // X
            }
            if (przekatna1 == 3 || przekatna2 == 3)
                return 1; // O
            if (przekatna1 == -3 || przekatna2 == -3)
                return -1; // X

            return 0; // brak wygranej
        }

        public static int Bot() // ma zwracać int - kwadrat do zaznaczenia
        {
            var cele = Skaner();
            int min = 0, max = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (cele[i, j] < min)
                        min = cele[i, j];
                    if (cele[i, j] > max)
                        max = cele[i, j];
                }
            }

            var moje = aktualnygracz == "O" ? 1 : -1;

            // atakuj - jeśli wygrana
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (moje == 1 && max == 2)
                    {
                        if (cele[i, j] == max)
                        {
                            Wstaw(i, j);
                            return i * 3 + j;
                        }
                    }
                    if (moje == -1 && min == -2)
                    {
                        if (cele[i, j] == min)
                        {
                            Wstaw(i, j);
                            return i * 3 + j;
                        }
                    }
                }
            }

            // Blokuj
            for (int i = 0; i < 3; i++)
            {
                // blokuj pewne wygrane
                for (int j = 0; j < 3; j++)
                {
                    if (moje == -1 && max == 2)
                    {
                        if (cele[i, j] == max)
                        {
                            Wstaw(i, j);
                            return i * 3 + j;
                        }
                    }
                    if (moje == 1 && min == -2)
                    {
                        if (cele[i, j] == min)
                        {
                            Wstaw(i, j);
                            return i * 3 + j;
                        }
                    }
                }
                // byle gdzie
                for (int j = 0; j < 3; j++)
                {
                    if (moje == -1 && max == 1)
                    {
                        if (cele[i, j] == max)
                        {
                            Wstaw(i, j);
                            return i * 3 + j;
                        }
                    }
                    if (moje == 1 && min == -1)
                    {
                        if (cele[i, j] == min)
                        {
                            Wstaw(i, j);
                            return i * 3 + j;
                        }
                    }
                }

            }

            // random
            while (true)
            {
                try
                {
                    int i = random.Next() % 3, j = random.Next() % 3;
                    Wstaw(i,j);
                    return i * 3 + j;
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        private static int[,] Skaner()
        {
            int przekatna1 = 0, przekatna2 = 0;
            int[,] target = new int[3, 3];

            for (int i = 0; i < 3; i++)
            {
                int wiersz = 0, kolumna = 0;

                // zbieranie danych - kolumny i wiersze
                for (int j = 0; j < 3; j++)
                {
                    // zbieranie danych
                    wiersz += plansza[i, j];
                    kolumna += plansza[j, i];
                    if (i == j)
                    {
                        przekatna1 += plansza[i, j];
                    }
                    if (i + j == 2)
                    {
                        przekatna2 += plansza[i, j];
                    }
                }

                // uzupełnianie danych w target, namierzamy tylko puste miejsca
                for (int j = 0; j < 3; j++)
                {
                    // szukaj pustego miejsca i wpisz w nie odpowiednie wartości
                    if (plansza[i, j] == 0)
                        if (Math.Abs(target[i, j]) < Math.Abs(wiersz))
                            target[i, j] = wiersz;
                    if (plansza[j, i] == 0)
                        if (Math.Abs(target[j, i]) < Math.Abs(kolumna))
                            target[j, i] = kolumna;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == j)
                    {
                        if (plansza[i, j] == 0)
                            if (Math.Abs(target[i, j]) <= Math.Abs(przekatna1))
                                target[i, j] = przekatna1;
                    }
                    if (i + j == 2)
                    {
                        if (plansza[i, j] == 0)
                            if (Math.Abs(target[i, j]) <= Math.Abs(przekatna2))
                                target[i, j] = przekatna2;
                    }
                }
            }

            Console.WriteLine("\nPotencjalne cele:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($" {target[i, j]} ");
                }
                Console.Write("\n");
            }

            return target;
        }
    }
}
