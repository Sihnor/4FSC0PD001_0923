namespace MonsterKampf
{
    public class Greif : Monster
    {
        public Greif(float _StartHP, float _StartAP, float _StartDP, float _StartS) : base()
        {
            this.m_OwnStats.m_Race = ERace.Greif;
            this.m_OwnStats.m_HealthPoints = _StartHP * (float)1.0;
            this.m_OwnStats.m_AttackPoints = _StartAP * (float)1.2;
            this.m_OwnStats.m_DefensePoints = _StartDP * (float)1.0;
            this.m_OwnStats.m_Speed = _StartS * (float)1.2;
        }

        public Greif(SStats _StartStats) : base(_StartStats)
        {
            this.m_OwnStats.m_Race = ERace.Greif;
            this.m_OwnStats.m_HealthPoints = _StartStats.m_HealthPoints * (float)1.0;
            this.m_OwnStats.m_AttackPoints = _StartStats.m_HealthPoints * (float)1.2;
            this.m_OwnStats.m_DefensePoints = _StartStats.m_AttackPoints * (float)1.0;
            this.m_OwnStats.m_Speed = _StartStats.m_DefensePoints * (float)1.2;
        }
    }
}