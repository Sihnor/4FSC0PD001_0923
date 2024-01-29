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
        private uint m_Rounds;
        private uint m_MonsterIndex = 0;
        private uint m_CreateXMonster = 2;
        private MonsterKampf.Monster[] m_MonsterArray;
        private EGameState m_GameState;
        private bool m_FirstMonsterStarts = false;

        public Game()
        {
            this.m_GameState = EGameState.StartMonsterCreate;
            this.m_MonsterArray = new Monster[m_CreateXMonster];
        }
        
        private void CreateMonster()
        {
            SStats tempStats;
            
            Console.Clear();
            Console.WriteLine($"Bitte geben Sie die Rasse das {this.m_MonsterIndex + 1} Monsters ein:");
            Console.WriteLine("[1] Ork");
            Console.WriteLine("[2] Troll");
            Console.WriteLine("[3] Goblin");
            Console.WriteLine("[4] Zwerg");
            Console.WriteLine("[5] Greif");
            Console.Write("Eingabe: ");
            string input = Console.ReadLine();
            this.CheckIfValid(input, out tempStats.m_Race);

            AskForStat("Lebenspunkte (HP)", out tempStats.m_HealthPoints);
            AskForStat("Angriffspunkte (AP)", out tempStats.m_AttackPoints);
            AskForStat("Verteidigungspunkte (DP)", out tempStats.m_DefensePoints);
            AskForStat("Geschwindigkeit (S)", out tempStats.m_Speed);

            switch (tempStats.m_Race)
            {
                case ERace.Ork:
                    this.m_MonsterArray[this.m_MonsterIndex] = new Ork(tempStats);
                    break;
                case ERace.Troll:
                    this.m_MonsterArray[this.m_MonsterIndex] = new Troll(tempStats);
                    break;
                case ERace.Goblin:
                    this.m_MonsterArray[this.m_MonsterIndex] = new Goblin(tempStats);
                    break;
                case ERace.Zwerg:
                    this.m_MonsterArray[this.m_MonsterIndex] = new Zwerg(tempStats);
                    break;
                case ERace.Greif:
                    this.m_MonsterArray[this.m_MonsterIndex] = new Greif(tempStats);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (this.m_MonsterIndex + 1 < this.m_CreateXMonster)
            {
                this.m_MonsterIndex++;    
            }
            else
            {
                this.m_GameState = EGameState.EndMonsterCreate;
            }
            
            Console.Clear();
        }

        private void CheckIfValid(string _Input, out ERace _ToWrite)
        {
            if (!Enum.IsDefined(typeof(ERace), int.Parse(_Input)))
            {
                this.m_GameState = EGameState.MonsterInvalid;
                //throw new Exception("Die eingegebene Rasse ist nicht verfuegbar!");
            }

            ERace.TryParse(_Input, out _ToWrite);
        }

        private void AskForStat(string _Attribute, out float _Stat)
        {
            Console.Write($"Bitte geben Sie die {_Attribute} des {this.m_MonsterIndex + 1}. ein: ");
            float.TryParse(Console.ReadLine(), out _Stat);
        }

        private void StartGame()
        {
            // First GameMode
            if (this.m_CreateXMonster == 2)
            {
                if (this.m_MonsterArray[0].GetMonsterRace() == this.m_MonsterArray[1].GetMonsterRace())
                {
                    this.m_GameState = EGameState.SameRace;
                }
                else
                {
                    this.m_GameState = EGameState.RunningGame;
                }

                this.m_FirstMonsterStarts = (this.m_MonsterArray[0].GetSpeed() >= this.m_MonsterArray[1].GetSpeed());
            }
        }

        public void GameLoop()
        {
            while (this.m_GameState != EGameState.EndGame)
            {
                switch (this.m_GameState)
                {
                    case EGameState.StartMonsterCreate:
                        this.CreateMonster();
                        break;
                    case EGameState.EndMonsterCreate:
                        this.m_GameState = EGameState.StartGame;
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

        private void NextAttack()
        {
            // First Monster Attacks
            if (m_FirstMonsterStarts)
            {
                this.m_MonsterArray[0].Attack(this.m_MonsterArray[1]);
            }
            // Second Monster Attacks
            else
            {
                this.m_MonsterArray[1].Attack(this.m_MonsterArray[0]);
            }

            if (this.CheckIfWon())
            {
                this.m_GameState = EGameState.MonsterWon;
                return;
            }
            
            // Switch to next Monster Attack
            this.m_FirstMonsterStarts = !this.m_FirstMonsterStarts;
        }

        private bool CheckIfWon()
        {
            int monsterAlive = 0;
            foreach (Monster monster in this.m_MonsterArray)
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

        private int GetTheWonMonster()
        {
            foreach (Monster monster in this.m_MonsterArray)
            {
                if (monster.GetHealth() > 0)
                {
                    return monster.GetIndex() + 1;
                }
            }

            return -1;
        }
        
        private void EndGame()
        {
            switch (this.m_GameState)
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
            
            this.m_GameState = EGameState.EndGame;
        }
    }
}