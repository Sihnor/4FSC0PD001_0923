using System;


namespace MonsterKampf
{

    enum EGameState
    {
        StartMonsterCreate,
        EndMonsterCreate,
        MonsterInvalid,
        StartGame,
        RunningGame,
        EndGame,
        MonsterWon,
        SameRace,
        
    }
    public class Game
    {
        private uint MonsterIndex = 0;
        private const uint CreateXMonster = 2;
        private MonsterKampf.Monster[] MonsterArray;
        private EGameState GameState;
        private bool FirstMonsterStarts = false;

        public Game()
        {
            this.GameState = EGameState.StartMonsterCreate;
            this.MonsterArray = new Monster[CreateXMonster];
        }
        
        /// <summary>
        /// Creates a Monster with the given Stats
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void CreateMonster()
        {
            SStats tempStats;
            
            Console.Clear();
            Console.WriteLine($"Bitte geben Sie die Rasse das {this.MonsterIndex + 1} Monsters ein:");
            Console.WriteLine("[1] Ork");
            Console.WriteLine("[2] Troll");
            Console.WriteLine("[3] Goblin");
            Console.WriteLine("[4] Zwerg");
            Console.WriteLine("[5] Greif");
            Console.Write("Eingabe: ");
            string input = Console.ReadLine();
            this.CheckIfValid(input, out tempStats.Race);

            AskForStat("Lebenspunkte (HP)", out tempStats.HealthPoints);
            AskForStat("Angriffspunkte (AP)", out tempStats.AttackPoints);
            AskForStat("Verteidigungspunkte (DP)", out tempStats.DefensePoints);
            AskForStat("Geschwindigkeit (S)", out tempStats.Speed);

            switch (tempStats.Race)
            {
                case ERace.Ork:
                    this.MonsterArray[this.MonsterIndex] = new Ork(tempStats);
                    break;
                case ERace.Troll:
                    this.MonsterArray[this.MonsterIndex] = new Troll(tempStats);
                    break;
                case ERace.Goblin:
                    this.MonsterArray[this.MonsterIndex] = new Goblin(tempStats);
                    break;
                case ERace.Zwerg:
                    this.MonsterArray[this.MonsterIndex] = new Zwerg(tempStats);
                    break;
                case ERace.Greif:
                    this.MonsterArray[this.MonsterIndex] = new Greif(tempStats);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (this.MonsterIndex + 1 < CreateXMonster)
            {
                this.MonsterIndex++;    
            }
            else
            {
                this.GameState = EGameState.EndMonsterCreate;
            }
            
            Console.Clear();
        }

        /// <summary>
        /// Checks if the given Input is valid for the Race
        /// </summary>
        /// <param name="_Input">The Input to check</param>
        /// <param name="_ToWrite">The Enum to write the Input to</param>
        private void CheckIfValid(string _Input, out ERace _ToWrite)
        {
            if (!Enum.IsDefined(typeof(ERace), int.Parse(_Input)))
            {
                this.GameState = EGameState.MonsterInvalid;
                //throw new Exception("Die eingegebene Rasse ist nicht verfuegbar!");
            }

            ERace.TryParse(_Input, out _ToWrite);
        }

        /// <summary>
        /// Asks for a Stat and writes it to the given Stat
        /// </summary>
        /// <param name="_Attribute">Das Attribute welches abgefragt wird.</param>
        /// <param name="_Stat">Der float Wert der gespeichert wird für den besetzten stat.</param>
        private void AskForStat(string _Attribute, out float _Stat)
        {
            Console.Write($"Bitte geben Sie die {_Attribute} des {this.MonsterIndex + 1}. ein: ");
            float.TryParse(Console.ReadLine(), out _Stat);
        }

        /// <summary>
        /// Starts the Game
        /// </summary>
        private void StartGame()
        {
            // First GameMode
            if (CreateXMonster == 2)
            {
                if (this.MonsterArray[0].GetMonsterRace() == this.MonsterArray[1].GetMonsterRace())
                {
                    this.GameState = EGameState.SameRace;
                }
                else
                {
                    this.GameState = EGameState.RunningGame;
                }

                this.FirstMonsterStarts = (this.MonsterArray[0].GetSpeed() >= this.MonsterArray[1].GetSpeed());
            }
        }

        /// <summary>
        /// Manage the GameLoop
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void GameLoop()
        {
            while (this.GameState != EGameState.EndGame)
            {
                switch (this.GameState)
                {
                    case EGameState.StartMonsterCreate:
                        this.CreateMonster();
                        break;
                    case EGameState.EndMonsterCreate:
                        this.GameState = EGameState.StartGame;
                        break;
                    case EGameState.MonsterInvalid:
                        this.EndGame();
                        break;
                    case EGameState.StartGame:
                        this.StartGame();
                        break;
                    case EGameState.RunningGame:
                        this.NextAttack();
                        break;
                    case EGameState.EndGame:
                        this.EndGame();
                        break;
                    case EGameState.SameRace:
                        this.EndGame();
                        break;
                    case EGameState.MonsterWon:
                        this.EndGame();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Manages the next Attack
        /// </summary>
        private void NextAttack()
        {
            // First Monster Attacks
            if (this.FirstMonsterStarts)
            {
                this.MonsterArray[0].Attack(this.MonsterArray[1]);
            }
            // Second Monster Attacks
            else
            {
                this.MonsterArray[1].Attack(this.MonsterArray[0]);
            }

            if (this.CheckIfWon())
            {
                this.GameState = EGameState.MonsterWon;
                return;
            }
            
            // Switch to next Monster Attack
            this.FirstMonsterStarts = !this.FirstMonsterStarts;
        }

        /// <summary>
        /// Checks if a Monster has won
        /// </summary>
        /// <returns>If one of the Monster won</returns>
        private bool CheckIfWon()
        {
            int monsterAlive = 0;
            foreach (Monster monster in this.MonsterArray)
            {
                if (monster.GetHealth() >= 1) monsterAlive++;
                if (monsterAlive > 1)
                {
                    return false;
                }
            }

            return true;
            
            // return this.m_MonsterArray[0].GetHealth() <= 0 || this.m_MonsterArray[1].GetHealth() <= 0;
        }

        /// <summary>
        /// Gets the Index of the won Monster
        /// </summary>
        /// <returns>Return the Monster Number</returns>
        private int GetTheWonMonster()
        {
            foreach (Monster monster in this.MonsterArray)
            {
                if (monster.GetHealth() > 0)
                {
                    return monster.GetIndex() + 1;
                }
            }

            return -1;
        }
        
        /// <summary>
        /// Manage the End of the Game
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void EndGame()
        {
            switch (this.GameState)
            {
                case EGameState.MonsterInvalid:
                    Console.WriteLine("Es gibt keine zugehoerige Klasse!");
                    break;
                case EGameState.MonsterWon:
                    Console.WriteLine("Es hat ein Monster gewonnen!");
                    Console.WriteLine($"Das {this.GetTheWonMonster()}.te Monster hat gewonnen.");
                    break;
                case EGameState.SameRace:
                    Console.WriteLine("Es wurde die gleiche Rasse als Gegner gewaehlt!");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            this.GameState = EGameState.EndGame;
        }
    }
}