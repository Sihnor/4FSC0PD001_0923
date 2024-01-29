namespace MonsterKampf
{
    public class Goblin: Monster
    {

        public Goblin(float _StartHP, float _StartAP, float _StartDP, float _StartS) : base()
        {
            this.m_OwnStats.m_Race = ERace.Goblin;
            this.m_OwnStats.m_HealthPoints = _StartHP * (float)0.8;
            this.m_OwnStats.m_AttackPoints = _StartAP * (float)0.8;
            this.m_OwnStats.m_DefensePoints = _StartDP * (float)0.8;
            this.m_OwnStats.m_Speed = _StartS * (float)1.2;            
        }

        public Goblin(SStats _StartStats) : base(_StartStats)
        {
            this.m_OwnStats.m_Race = ERace.Goblin;
            this.m_OwnStats.m_HealthPoints = _StartStats.m_HealthPoints * (float)0.8;
            this.m_OwnStats.m_AttackPoints = _StartStats.m_HealthPoints * (float)0.8;
            this.m_OwnStats.m_DefensePoints = _StartStats.m_AttackPoints * (float)0.8;  
            this.m_OwnStats.m_Speed = _StartStats.m_DefensePoints * (float)1.2;
        }
    }
}