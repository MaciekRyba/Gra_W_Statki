using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{


    class Program
    {
        const int rows = 10;
        const int columns = 10;
        public string[,] playerHits = new string[columns,rows];
        string[,] computerHits = new string[columns, rows];

        string [,] playerBoard = new string[columns, rows];
        string[,] computerBoard = new string[columns, rows];


        List<Ships> shipsList = new List<Ships>();
        
        int numberOfWinningShoots = 21;

        public void game()
        {
            int turn = 1;
            int computerShoots = 0;
            int playerShoots = 0;
            Random rnd = new Random();

            do
            {
                int x1 = 0;
                int y1 = 0;
                bool ifEndTurn = false;
                bool result = false;

                do
                {
                    if (turn == 1)
                    {
                        do
                        {

                            Console.WriteLine("\tPodaj numer kolumny");
                            result = int.TryParse(Console.ReadLine(), out x1);

                            if (result)
                                result = Enumerable.Range(1, 10).Contains(x1);

                            if (!result)
                            {
                                Console.WriteLine("\tPodano zły numer kolumny\n");
                            }

                        } while (result != true);
                    }

                    if (turn == 0)
                        x1 = rnd.Next(1, 11);


                    if (turn == 1)
                    {
                        do
                        {
                            Console.WriteLine("\tPodaj numer wiersza");
                            result = int.TryParse(Console.ReadLine(), out y1);

                            if (result)
                                result = Enumerable.Range(1, 10).Contains(y1);

                            if (!result)
                            {
                                Console.WriteLine("\tPodano zły numer kolumny\n");
                            }

                        } while (result != true);
                    }

                    if (turn == 0)
                        y1 = rnd.Next(1, 11);

                    if (turn == 1)
                    {
                        if (playerHits[x1 - 1, y1 - 1] != "PP" && playerHits[x1 - 1, y1 - 1] != "XX")
                        {
                            string ship = computerBoard[x1 - 1, y1 - 1];

                            if (ship == "00")
                            {
                                playerHits[x1 - 1, y1 - 1] = "PP";
                                Console.Clear();
                                Console.WriteLine("PUDŁO!");
                            }
                            else
                            {
                                computerBoard[x1 - 1, y1 - 1] = "XX";
                                playerHits[x1 - 1, y1 - 1] = "XX";


                                bool exist = false;
                                foreach (string item in computerBoard)
                                {
                                    if (item.Equals(ship))
                                    {
                                        exist = true;
                                    }
                                }

                                if (exist)
                                {
                                    Console.Clear();
                                    Console.WriteLine("TRAFIONY");
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("TRAFIONY ZATOPIONY");
                                }
                                playerShoots +=1;

                            }
                            turn -= 1;
                            ifEndTurn = true;
                        }
                        else
                        {
                            Console.WriteLine("Strzelałeś już w dany punkt, podaj współrzędne ponownie\n");
                            ifEndTurn = false;
                        }
                    }
                    else
                    {
                        if (computerHits[x1 - 1, y1 - 1] != "PP" && computerHits[x1 - 1, y1 - 1] != "XX")
                        {
                            string ship = playerBoard[x1 - 1, y1 - 1];

                            if (ship == "00")
                            {
                                computerHits[x1 - 1, y1 - 1] = "PP";
                                Console.Clear();
                                Console.WriteLine("KOMPUTER SPUDŁOWAŁ!");
                            }
                            else
                            {
                                playerBoard[x1 - 1, y1 - 1] = "XX";
                                computerHits[x1 - 1, y1 - 1] = "XX";

                                bool exist = false;
                                foreach (string item in playerBoard)
                                {
                                    if (item.Equals(ship))
                                    {
                                        exist = true;
                                    }
                                }

                                    if (exist)
                                {
                                    Console.Clear();
                                    Console.WriteLine("TWÓJ STATEK ZOSTAŁ TRAFIONY");
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("TWÓJ STATEK ZOSTAŁ ZATOPIONY");
                                }
                                computerShoots +=1;

                            }
                            turn += 1;
                            ifEndTurn = true;
                        }
                        else
                        {
                            ifEndTurn = false;
                        }

                    }
                } while (ifEndTurn == false);

                Console.WriteLine("Twoja plansza: ");
                drawBoard(playerBoard);
                Console.WriteLine("\t\n");
                Console.WriteLine("Plansza do zatapiania statków: ");
                drawBoard(playerHits);
                Console.WriteLine("\t\n");
                Console.WriteLine("Plansza KOMPUTERA: ");
                drawBoard(computerBoard);
                Console.WriteLine("player:{0}\n",playerShoots);
                Console.WriteLine("computer:{0}\n", computerShoots);

                Console.WriteLine("\tWcisnij dowolny przycisk, aby kontynuowac ture !\n");
                Console.ReadKey();

            } while (computerShoots < numberOfWinningShoots && playerShoots < numberOfWinningShoots);

            if(computerShoots == numberOfWinningShoots)
            {
                Console.WriteLine("\tKOMPUTER WYGRAŁ MECZ!!");
            }else
                Console.WriteLine("\tGRATULACJE, WYGRALES ROZGRYWKE!!!!!");
        }



        public void AddShipsToBoard(string user)
        {
            

            foreach(Ships ship in shipsList)
            {
                for (int i = ship.quantity - 1; i >= 0; i--)
                {
                    
                    if (user == "player")
                    {
                        Console.Clear();
                        drawBoard(playerBoard);
                        Console.WriteLine("\t {0} - pozostało do dodania {1} statków\n", ship.name, i + 1);
                    }

                    bool result = false;
                    int x1 = 0;
                    int y1 = 0;
                    bool ifAdd = false;
                    Random rnd = new Random();


                    if (ship.slength == 1)
                    {
                        do
                        {
                            if (user == "player") { 
                                do
                                {

                                    Console.WriteLine("\tPodaj numer kolumny");
                                    result = int.TryParse(Console.ReadLine(), out x1);

                                    if (result)
                                        result = Enumerable.Range(1, 10).Contains(x1);

                                    if (!result)
                                    {
                                        Console.WriteLine("\tPodano zły numer kolumny\n");
                                    }

                                } while (result != true);
                            }

                            if (user == "cp")
                                x1 = rnd.Next(1, 11);


                            if (user == "player")
                            {
                                do
                                {
                                    Console.WriteLine("\tPodaj numer wiersza");
                                    result = int.TryParse(Console.ReadLine(), out y1);

                                    if (result)
                                        result = Enumerable.Range(1, 10).Contains(y1);

                                    if (!result)
                                    {
                                        Console.WriteLine("\tPodano zły numer kolumny\n");
                                    }

                                } while (result != true);
                            }
                            
                            if (user == "cp")
                                y1 = rnd.Next(1, 11);


                            if (user == "player")
                            {
                                if (playerBoard[x1 - 1, y1 - 1] == "00")
                                {
                                    ifAdd = true;
                                    playerBoard[x1 - 1, y1 - 1] = ship.symbol+(i+1).ToString();
                                }
                                else
                                {
                                    ifAdd = false;
                                    Console.WriteLine("Podana komórka jest już zajęta");
                                }
                            }
                            else {
                                if (computerBoard[x1 - 1, y1 - 1] == "00")
                                {
                                    ifAdd = true;
                                    computerBoard[x1 - 1, y1 - 1] = ship.symbol+(i + 1).ToString();
                                }
                                else
                                {
                                    ifAdd = false;
                                }

                            }

                        } while (ifAdd != true);
                    }
                    else
                    {

                        int[] K1 = new int[2];
                        int[] K2 = new int[2];

                        for (int ln = 0; ln < ship.slength; ln++)
                        {

                            do
                            {
                                if (user == "player")
                                {
                                    do
                                    {

                                        Console.WriteLine("\tPodaj numer kolumny");
                                        result = int.TryParse(Console.ReadLine(), out x1);

                                        if (result)
                                            result = Enumerable.Range(1, 10).Contains(x1);

                                        if (!result)
                                        {
                                            Console.WriteLine("\tPodano zły numer kolumny\n");
                                        }

                                    } while (result != true);
                                }
                                if (user == "cp")
                                    x1 = rnd.Next(1, 11);


                                if (user == "player")
                                {
                                    do
                                    {
                                        Console.WriteLine("\tPodaj numer wiersza");
                                        result = int.TryParse(Console.ReadLine(), out y1);

                                        if (result)
                                            result = Enumerable.Range(1, 10).Contains(y1);

                                        if (!result)
                                        {
                                            Console.WriteLine("\tPodano zły numer kolumny\n");
                                        }

                                    } while (result != true);
                                }

                                if (user == "cp")
                                    y1 = rnd.Next(1, 11);

                                if (user == "player")
                                {
                                    if (playerBoard[x1 - 1, y1 - 1] == "00")
                                    {


                                        if (ln == 0)
                                        {
                                            K1[0] = x1;
                                            K1[1] = y1;
                                            playerBoard[x1 - 1, y1 - 1] = ship.symbol + (i + 1).ToString();
                                            ifAdd = true;
                                            Console.Clear();
                                            drawBoard(playerBoard);
                                        }
                                        else if (ln == 1)
                                        {
                                            if (CheckIfNear(K1[0], K1[1], x1, y1))
                                            {
                                                K2[0] = x1;
                                                K2[1] = y1;
                                                playerBoard[x1 - 1, y1 - 1] = ship.symbol + (i + 1).ToString();
                                                ifAdd = true;
                                                Console.Clear();
                                                drawBoard(playerBoard);
                                            }
                                            else
                                            {
                                                Console.WriteLine("\tPodany punkt nie zostanie poprawnie przypisany,");
                                                Console.WriteLine("\tnależy ponownie wprowadzić koordynaty");
                                                ifAdd = false;
                                            }
                                        }
                                        else
                                        {
                                            if (CheckIfNear(K1[0], K1[1], x1, y1))
                                            {
                                                K1[0] = x1;
                                                K1[1] = y1;
                                                playerBoard[x1 - 1, y1 - 1] = ship.symbol + (i + 1).ToString();
                                                ifAdd = true;
                                                Console.Clear();
                                                drawBoard(playerBoard);
                                            }
                                            else
                                            {
                                                if (CheckIfNear(K2[0], K2[1], x1, y1))
                                                {
                                                    K2[0] = x1;
                                                    K2[1] = y1;
                                                    playerBoard[x1 - 1, y1 - 1] = ship.symbol + (i + 1).ToString();
                                                    ifAdd = true;
                                                    Console.Clear();
                                                    drawBoard(playerBoard);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\tPodany punkt nie zostanie poprawnie przypisany,");
                                                    Console.WriteLine("\tnależy ponownie wprowadzić koordynaty");
                                                    ifAdd = false;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        ifAdd = false;
                                        Console.WriteLine("\tPodana komórka jest już zajęta");
                                    }
                                }
                                else
                                {
                                    if (computerBoard[x1 - 1, y1 - 1] == "00")
                                    {


                                        if (ln == 0)
                                        {
                                            K1[0] = x1;
                                            K1[1] = y1;
                                            computerBoard[x1 - 1, y1 - 1] = ship.symbol + (i + 1).ToString();
                                            ifAdd = true;
                                        }
                                        else if (ln == 1)
                                        {
                                            if (CheckIfNear(K1[0], K1[1], x1, y1))
                                            {
                                                K2[0] = x1;
                                                K2[1] = y1;
                                                computerBoard[x1 - 1, y1 - 1] = ship.symbol + (i + 1).ToString();
                                                ifAdd = true;
                                            }
                                            else
                                            {
                                                ifAdd = false;
                                            }
                                        }
                                        else
                                        {
                                            if (CheckIfNear(K1[0], K1[1], x1, y1))
                                            {
                                                K1[0] = x1;
                                                K1[1] = y1;
                                                computerBoard[x1 - 1, y1 - 1] = ship.symbol + (i + 1).ToString();
                                                ifAdd = true;
                                            }
                                            else
                                            {
                                                if (CheckIfNear(K2[0], K2[1], x1, y1))
                                                {
                                                    K2[0] = x1;
                                                    K2[1] = y1;
                                                    computerBoard[x1 - 1, y1 - 1] = ship.symbol + (i + 1).ToString();
                                                    ifAdd = true;
                                                }
                                                else
                                                {
                                                    ifAdd = false;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        ifAdd = false;
                                    }

                                }

                            } while (ifAdd != true);


                        }
                    }  
                }
            }
        }

        public bool CheckIfNear(int x1,int y1,int x2, int y2 )
        {
            bool checkX = false;
            bool checkY = false;

            if (x1 == x2)
                checkX = true;
            else {
                if (x1 - x2 == 1 || x2 - x1 == 1) 
                    checkX = true;
                else
                    checkX = false;                
            }

            if (y1 == y2)
                checkY = true;
            else
            {
                if (y1 - y2 == 1 || y2 - y1 == 1)
                    checkY = true;
                else
                    checkY = false;
            }

            if (checkX && checkY)
                return true;
            else
                return false;
        }

        public void CleanBoards()
        {
            shipsList.Add(new Ships("jednomasztowiec", 1, 5, "S"));
            shipsList.Add(new Ships("dwumasztowiec", 2, 3, "T"));
            shipsList.Add(new Ships("trójmasztowiec", 3, 2, "D"));
            shipsList.Add(new Ships("czteromasztoweic", 4, 1, "F"));

            for (int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    playerHits[i,j] = "00";
                    computerHits[i, j] = "00";
                    playerBoard[i, j] = "00";
                    computerBoard[i, j] = "00";
                }
            }
        }

        public void drawBoard(string[,] board)
        {
            Console.WriteLine(" | 1| 2| 3| 4| 5| 6| 7| 8| 9| 10|");

            for(int  i= 0; i < rows; i++)
            {
                Console.Write("{0}|",(i+1));
                for (int j = 0;j < columns; j++)
                {
                    if(j==columns-1)
                        Console.WriteLine("{0}|", board[j,i]);
                    else
                        Console.Write("{0}|", board[j, i]);
                }
            }
            
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\tBattle Ship Game\r");
            Console.WriteLine("\t----------------\n");
            Program BattleShip = new Program();
            string option = "";
            do
            {

                Console.WriteLine("\ts - start");
                Console.WriteLine("\te - exit");
                option = Console.ReadLine();

                switch (option)
                {
                    case "s":
                        Console.Clear();
                        BattleShip.CleanBoards();
                        BattleShip.AddShipsToBoard("player");
                        BattleShip.AddShipsToBoard("cp");
                        Console.Clear();
                        Console.WriteLine("Twoja plansza: ");
                        BattleShip.drawBoard(BattleShip.playerBoard);
                        Console.WriteLine("\t\n");
                        Console.WriteLine("Plansza do zatapiania statków: ");
                        BattleShip.drawBoard(BattleShip.playerHits);
                        Console.WriteLine("\t\n");
                        Console.WriteLine("Plansza KOMPUTERA: ");
                        BattleShip.drawBoard(BattleShip.computerBoard);
                        Console.WriteLine("\t Rozpocznij grę\n");
                        BattleShip.game();
                        Console.WriteLine("\tNacisnij dowolny przycisk, zeby przejsc do menu\n");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }

            } while (option != "e");
        }
    }
}
