using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tictatoe
{
    public enum GameState
    {
        Menu,
        Starting,
        Playing,
        Gameover
    }

    public class Game
    {
        public int PlayerTurn { get; set; }
        public GameState CurrentState { get; set; }
        public char[,] Board { get; set; }
        public bool CurrentPlayer { get; set; }
        
    }

    public enum GameOverState
    {
        GameOn,
        Player1,
        Player2,
        Tie
    }

    class Program
    {
        const int LEFTMARGIN = 4, COLSIZE = 10, ROWSIZE = 4;
        static int tmp;
        const int TOPMARGIN = 2;
        const int FPSTIME = 33;
        public static Game CurrentGame;
        static char tmpPlayer;

        static Thread _inputThread;


        public static void InitializeGame()
        {
            CurrentGame = new Game();
            CurrentGame.Board = new char[3, 3];
            CurrentGame.CurrentState = GameState.Menu;
            CurrentGame.PlayerTurn = 0;
            _inputThread = new Thread(GetInput);
            _inputThread.Start();

        }

        public static void Main(string[] args)
        {
            InitializeGame();
            char prueba;
            while (CurrentGame.CurrentState != GameState.Gameover)
            {
                switch (CurrentGame.CurrentState)
                {
                    case GameState.Menu:
                        ShowMenu();
                        break;
                    case GameState.Starting:
                        ShowFrame(true);
                        break;
                    case GameState.Playing:
                        ShowFrame(false);
                        ShowBoard();
                        CurrentGame.CurrentState = GameState.Gameover;
                        switch (CheckGameOver())
                        {
                            case GameOverState.Player1:
                                Console.WriteLine("Ha ganado el jugador 1!");
                                break;
                            case GameOverState.Player2:
                                Console.WriteLine("Ha ganado el jugador 2!");
                                break;
                            case GameOverState.Tie:
                                Console.WriteLine("Empate!");
                                break;
                            default:
                                CurrentGame.CurrentState = GameState.Playing;
                                break;
                        }
                        break;

                }
                Thread.Sleep(FPSTIME);
            }
            FinalizeGame();
            Console.ReadKey();
        }

        static void ShowFrame(bool isStarting)
        {
            Console.Clear();
            //Console.WriteLine("#################");
            Console.WriteLine("  7  |  8  |  9  ");

            Console.WriteLine("     |     |     ");

            Console.WriteLine("_____|_____|_____");

            Console.WriteLine("  4  |  5  |  6  ");

            Console.WriteLine("     |     |     ");

            Console.WriteLine("_____|_____|_____");

            Console.WriteLine("  1  |  2  |  3  ");

            Console.WriteLine("     |     |     ");

            Console.WriteLine("     |     |     ");
           // Console.WriteLine("#################");
            //Console.WriteLine($"\n{(isStarting ? "Presione una tecla para empezar con el jugador 1." : ("Le toca al jugador " + CurrentGame.CurrentPlayer ? "dos. : "uno. ")))}");
            Console.Write("Seleccione una casilla [1-9]");
        }

        static void ShowBoard()
        {
            int _counter = 0;
            foreach (char currentPiece in CurrentGame.Board)
            {
                Console.SetCursorPosition(_counter % 3 * LEFTMARGIN, _counter / 3 * TOPMARGIN);
                Console.Write(currentPiece);

                _counter++;
            }
        }
        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Hola! vamo a jugar tic tac toe...");
            Console.Write("\nSeleccione una opción:");
            Console.WriteLine("\n\t1: Jugar");
            Console.WriteLine("\t2: Salir");
            Console.WriteLine("\n\tSeleccione: ");
        }

        //Retorna el ganador del Juego(Comportamientos).
        static GameOverState CheckGameOver()
        {
            
            tmpPlayer = '\0';
            for (tmp = 0; tmp < 3; tmp++)
            {
                if (CurrentGame.Board[tmp, 0] != '\0' && CurrentGame.Board[tmp, 0] == CurrentGame.Board[tmp, 1] && CurrentGame.Board[tmp, 0] == CurrentGame.Board[tmp, 2])
                    tmpPlayer = CurrentGame.Board[tmp, 0];
                if (CurrentGame.Board[0, tmp] != '\0' && CurrentGame.Board[0, tmp] == CurrentGame.Board[1, tmp] && CurrentGame.Board[0, tmp] == CurrentGame.Board[2, tmp])
                    tmpPlayer = CurrentGame.Board[0, tmp];
            }
            if (CurrentGame.Board[0, 0] != '\0' && CurrentGame.Board[0, 0] == CurrentGame.Board[1, 1] && CurrentGame.Board[0, 0] == CurrentGame.Board[2, 2])
                tmpPlayer = CurrentGame.Board[0, 0];
            if (CurrentGame.Board[0, 2] != '\0' && CurrentGame.Board[0, 2] == CurrentGame.Board[1, 1] && CurrentGame.Board[0, 2] == CurrentGame.Board[2, 0])
                tmpPlayer = CurrentGame.Board[0, 2];

            if (tmpPlayer != '\0')
                return tmpPlayer == 'X' ? GameOverState.Player1 : GameOverState.Player2;
            //Caso de empate.
            if (CurrentGame.PlayerTurn == CurrentGame.Board.Length)
                return GameOverState.Tie;
            //Juego sigue hasta llenar el tablero o Gane un Jugador. 
            return GameOverState.GameOn;
        }


        static void GetInput()
        {
            //El input hace el trabajo de capturar para luego actualizar el comportamientos.
            string _currentInput;
            int i, j;
            while (true)
            {
                switch (CurrentGame.CurrentState)
                {
                    case GameState.Menu:
                        _currentInput = Console.ReadKey().KeyChar.ToString();
                        _currentInput = Console.ReadKey().KeyChar.ToString();
                        CurrentGame.CurrentState = _currentInput == "1" ? GameState.Starting : GameState.Gameover;
                        break;
                    case GameState.Starting:
                        _currentInput = Console.ReadKey().KeyChar.ToString();
                        CurrentGame.CurrentState = GameState.Playing;
                        break;
                    case GameState.Playing:
                        _currentInput = Console.ReadKey().KeyChar.ToString();
                        tmp = Convert.ToInt32(_currentInput);

                        if (tmp < 1 || tmp > 9)
                            continue;

                        i = 3 - ((tmp - 1) / 3) - 1;
                        j = (tmp - 1) % 3;

                        if (CurrentGame.Board[i, j] != '\0')
                            continue;

                        CurrentGame.PlayerTurn++;

                        CurrentGame.Board[i, j] = CurrentGame.CurrentPlayer ? 'O' : 'x';
                        CurrentGame.CurrentPlayer = !CurrentGame.CurrentPlayer;
                        break;
                }
            }
        }

        static void FinalizeGame()
        {
            _inputThread.Abort();
            _inputThread.Join();
        }


    }
}



