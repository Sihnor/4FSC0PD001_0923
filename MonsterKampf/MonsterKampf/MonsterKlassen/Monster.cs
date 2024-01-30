namespace MonsterKampf
{
    public enum ERace
    {
        Ork = 1,
        Troll = 2,
        Goblin = 3,
        Zwerg = 4,
        Greif = 5
    }

    public struct SStats
    {
        public ERace Race;
        public float HealthPoints;
        public float AttackPoints;
        public float DefensePoints;
        public float Speed;
    }

    public abstract class Monster
    {
        public Monster()
        {
            Index++;
            this.MonsterIndex = Index;
        }

        public Monster(float startHp, float startAp, float startDp, float startS)
        {
            this.OwnStats.HealthPoints = startHp;
            this.OwnStats.AttackPoints = startAp;
            this.OwnStats.DefensePoints = startDp;
            this.OwnStats.Speed = startS;

            Index++;
            this.MonsterIndex = Index;
        }
        
        public Monster(SStats startStats)
        {
            this.OwnStats = startStats;
            
            Index++;
            this.MonsterIndex = Index;
        }
        
        protected SStats OwnStats;

        private static int Index = -1;

        private readonly int MonsterIndex = -1;
        
        /// <summary>
        /// Attack the enemy with the own attack points
        /// </summary>
        /// <param name="enemy"></param>
        public void Attack(Monster enemy)
        {
            float damage = this.OwnStats.AttackPoints - enemy.OwnStats.DefensePoints;
            if (damage < 0)
            {
                damage = 1;
            }

            enemy.DealDamage(damage);
        }

        /// <summary>
        /// Deal damage to the own health points
        /// </summary>
        /// <param name="damage"></param>
        private void DealDamage(float damage)
        {
            this.OwnStats.HealthPoints -= damage;
        }

        /// <summary>
        /// Get the Monster Race
        /// </summary>
        /// <returns>The Mosnter Race</returns>
        public ERace GetMonsterRace()
        {
            return this.OwnStats.Race;
        }

        /// <summary>
        /// Get the Monster Speed Points
        /// </summary>
        /// <returns></returns>
        public float GetSpeed()
        {
            return this.OwnStats.Speed;
        }

        /// <summary>
        /// Get the Monster Health Points
        /// </summary>
        /// <returns></returns>
        public float GetHealth()
        {
            return this.OwnStats.HealthPoints;
        }

        /// <summary>
        /// Get the Monster Index in the Monster List
        /// </summary>
        /// <returns></returns>
        public int GetIndex()
        {
            return this.MonsterIndex;
        }
        
        
    };
}

