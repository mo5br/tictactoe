using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static char[] arr = { 'N', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; 
        static char[] arr2 = new char[10];
        static char PC = 'A';
        static int winner = 0;
        static int player = 0;
        static void Main(string[] args)
        {
            while (true)
            {
            int i = 0;
            int choice;
            Console.WriteLine("Choose: \n 1-X \n 2-O");
            do
            {

                player = Convert.ToInt32(Console.ReadLine());
                if (string.IsNullOrEmpty(Convert.ToString(player)) || player > 2 || player < 1)
        
                {
                    Console.WriteLine("Invalid Input, try again");
                }
            } while (string.IsNullOrEmpty(Convert.ToString(player)) || player > 2 || player <1);

            Console.Clear();
            while (true)
            {
                Board();
                Console.WriteLine("Choose a spot: ");
                do
                {

                    choice = Convert.ToInt32(Console.ReadLine());
                    if (string.IsNullOrEmpty(Convert.ToString(choice)) || choice > 9 || choice < 1)
                    {
                        Console.WriteLine("Invalid Input, try again");
                    }
                } while (string.IsNullOrEmpty(Convert.ToString(choice)) || choice > 9 || choice < 1);

             
                change(choice, player);
                winner1();
                Console.Clear();
                if (winner != 0 || Array.TrueForAll(arr2, y => y == 'N') == true)
                {
                    break;
                }
            }

                
            winner = 0;
            resetboard();
        }
            Console.ReadKey();
          
           
        }
                private static void Board()

        {

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);

            Console.WriteLine("     |     |      ");

        }

                private static void change(int choice, int player)
                {
                   
                    if (arr[choice] =='X' || arr[choice] == 'O')
                    {
                        Console.WriteLine("it's occupied");
                        Console.ReadKey();
                    }
                    else
                    {
                        if (player == 1)
                        {
                            arr[choice] = 'X';
                            checkandplay('O');
                        }
                        else
                        {
                            arr[choice] = 'O';
                            checkandplay('X');
                        }
                    }
                }

                private static void checkandplay(char PC)
                {
                    for (int i = 1; i <= 9; i++)
                    {
                        if (Char.IsDigit(arr[i]))
                        {
                            arr2[i] = (char)(i);

                        }
                        else
                        {
                            arr2[i] = 'N';
                        }
                    }
                    arr2[0] = 'N';
                    bool result = Array.TrueForAll(arr2, y => y == 'N');
                    if (result == false)
                    {
                        Random random = new Random();
                        int rr = random.Next(1, arr2.Length);
                        while (true)
                        {
                            if (arr2[rr] == 'N')
                            {
                                rr = random.Next(1, arr2.Length);
                            }
                            else
                            {
                                arr[rr] = PC;
                                break;
                            }
                        }


                    }
                }

                private static void winner1()
                {
                    if (arr[1] == arr[2] && arr[2] == arr[3] && arr[3] == 'X' || arr[4] == arr[5] && arr[5] == arr[6] && arr[6] == 'X' || arr[7] == arr[8] && arr[8] == arr[9] && arr[9] == 'X' || arr[1] == arr[4] && arr[4] == arr[7] && arr[7] == 'X' || arr[2] == arr[5] && arr[5] == arr[8] && arr[8] == 'X' || arr[3] == arr[6] && arr[6] == arr[9] && arr[9] == 'X' || arr[1] == arr[5] && arr[5] == arr[9] && arr[9] == 'X' || arr[3] == arr[5] && arr[5] == arr[7] && arr[7] == 'X')
                    {
                        
                            if (player == 1)
                            {
                                 winner = 1;
                                 Console.Clear();
                                 Board();
                                 Console.WriteLine("Winner is YOU");
                                 Console.ReadKey();
                            }
                            else
                            {
                                winner = 2;
                                Console.Clear();
                                Board();
                                Console.WriteLine("Winner is PC");
                                Console.ReadKey();
                            }
    
                        
                    }
                    else if (arr[1] == arr[2] && arr[2] == arr[3] && arr[3] == 'O' || arr[4] == arr[5] && arr[5] == arr[6] && arr[6] == 'O' || arr[7] == arr[8] && arr[8] == arr[9] && arr[9] == 'O' || arr[1] == arr[4] && arr[4] == arr[7] && arr[7] == 'O' || arr[2] == arr[5] && arr[5] == arr[8] && arr[8] == 'O' || arr[3] == arr[6] && arr[6] == arr[9] && arr[9] == 'O' || arr[1] == arr[5] && arr[5] == arr[9] && arr[9] == 'O' || arr[3] == arr[5] && arr[5] == arr[7] && arr[7] == 'O')
                    {

                        if (player == 2)
                        {
                            winner = 1;
                            Console.Clear();
                            Board();
                            Console.WriteLine("Winner is YOU");
                            Console.ReadKey();
                        }
                        else 
                        {
                            winner = 2;
                            Console.Clear();
                            Board();
                            Console.WriteLine("Winner is PC");
                          
                            Console.ReadKey();
                        }

                    }
                    else if (Array.TrueForAll(arr2, y => y == 'N') == true)
                    {
                        Console.Clear();
                        Board();
                        Console.WriteLine("It is TIE");
                        Console.ReadKey();
                    }


                  



                }

                private static void resetboard()
                {
                    arr[1] = '1';
                    arr[2] = '2';
                    arr[3] = '3';
                    arr[4] = '4';
                    arr[5] = '5';
                    arr[6] = '6';
                    arr[7] = '7';
                    arr[8] = '8';
                    arr[9] = '9';

                }

  
    }




    
}