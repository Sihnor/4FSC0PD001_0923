namespace MonsterKampf
{
    public enum ERace
    {
        Ork = 1,
        Troll = 2,
        Goblin = 3,
        Zwerg = 4,
        Greif
    }

    public struct SStats
    {
        public ERace m_Race;
        public float m_HealthPoints;
        public float m_AttackPoints;
        public float m_DefensePoints;
        public float m_Speed;
    }

    public abstract class Monster
    {
        public Monster()
        {
            Index++;
            this.MonsterIndex = Index;
        }

        public Monster(float _StartHP, float _StartAP, float _StartDP, float _StartS)
        {
            this.m_OwnStats.m_HealthPoints = _StartHP;
            this.m_OwnStats.m_AttackPoints = _StartAP;
            this.m_OwnStats.m_DefensePoints = _StartDP;
            this.m_OwnStats.m_Speed = _StartS;

            Index++;
            this.MonsterIndex = Index;
        }
        
        public Monster(SStats _StartStats)
        {
            this.m_OwnStats = _StartStats;
            
            Index++;
            this.MonsterIndex = Index;
        }
        
        protected SStats m_OwnStats;

        private static int Index = -1;

        private readonly int MonsterIndex = -1;
        
        public void Attack(Monster _Enemy)
        {
            float damage = this.m_OwnStats.m_AttackPoints - _Enemy.m_OwnStats.m_DefensePoints;
            if (damage < 0)
            {
                damage = 1;
            }

            _Enemy.DealDamage(damage);
        }

        public void DealDamage(float _Damage)
        {
            this.m_OwnStats.m_HealthPoints -= _Damage;
        }

        public ERace GetMonsterRace()
        {
            return this.m_OwnStats.m_Race;
        }

        public float GetSpeed()
        {
            return this.m_OwnStats.m_Speed;
        }

        public float GetHealth()
        {
            return this.m_OwnStats.m_HealthPoints;
        }

        public int GetIndex()
        {
            return this.MonsterIndex;
        }
        
        
    };
}

