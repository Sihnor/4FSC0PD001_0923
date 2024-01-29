namespace MonsterKampf
{
    public class Troll : Monster
    {

        public Troll(float _StartHP, float _StartAP, float _StartDP, float _StartS) : base()
        {
            this.m_OwnStats.m_Race = ERace.Troll;
            this.m_OwnStats.m_HealthPoints = _StartHP * (float)1.2;
            this.m_OwnStats.m_AttackPoints = _StartAP * (float)1.2;
            this.m_OwnStats.m_DefensePoints = _StartDP * (float)1.2;
            this.m_OwnStats.m_Speed = _StartS * (float) 0.8;
        }

        public Troll(SStats _StartStats) : base(_StartStats)
        {
            this.m_OwnStats.m_Race = ERace.Troll;
            this.m_OwnStats.m_HealthPoints = _StartStats.m_HealthPoints * (float)1.2;
            this.m_OwnStats.m_AttackPoints = _StartStats.m_HealthPoints * (float)1.2;
            this.m_OwnStats.m_DefensePoints = _StartStats.m_AttackPoints * (float)1.2;
            this.m_OwnStats.m_Speed = _StartStats.m_DefensePoints * (float)0.8;
        }
    }
}