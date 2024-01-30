namespace MonsterKampf
{
    public class Greif : Monster
    {
        public Greif(float startHp, float startAp, float startDp, float startS) : base()
        {
            this.OwnStats.Race = ERace.Greif;
            this.OwnStats.HealthPoints = startHp * (float)1.0;
            this.OwnStats.AttackPoints = startAp * (float)1.2;
            this.OwnStats.DefensePoints = startDp * (float)1.0;
            this.OwnStats.Speed = startS * (float)1.2;
        }

        public Greif(SStats startStats) : base()
        {
            this.OwnStats.Race = ERace.Greif;
            this.OwnStats.HealthPoints = startStats.HealthPoints * (float)1.0;
            this.OwnStats.AttackPoints = startStats.HealthPoints * (float)1.2;
            this.OwnStats.DefensePoints = startStats.AttackPoints * (float)1.0;
            this.OwnStats.Speed = startStats.DefensePoints * (float)1.2;
        }
    }
}