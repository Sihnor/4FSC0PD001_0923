namespace MonsterKampf
{
    public class Ork : Monster
    {

        public Ork(float startHp, float startAp, float startDp, float startS) : base()
        {
            this.OwnStats.Race = ERace.Ork;
            this.OwnStats.HealthPoints = startHp * (float)1.2;
            this.OwnStats.AttackPoints = startAp * (float)1.0;
            this.OwnStats.DefensePoints = startDp * (float)1.0;
            this.OwnStats.Speed = startS * (float)1.0;
        }

        public Ork(SStats startStats) : base()
        {
            this.OwnStats.Race = ERace.Ork;
            this.OwnStats.HealthPoints = startStats.HealthPoints * (float)1.2;
            this.OwnStats.AttackPoints = startStats.HealthPoints * (float)1.0;
            this.OwnStats.DefensePoints = startStats.AttackPoints * (float)1.0;
            this.OwnStats.Speed = startStats.DefensePoints * (float)1.0;
        }
    }
}