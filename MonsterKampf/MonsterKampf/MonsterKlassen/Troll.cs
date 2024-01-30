namespace MonsterKampf
{
    public class Troll : Monster
    {

        public Troll(float startHp, float startAp, float startDp, float startS) : base()
        {
            this.OwnStats.Race = ERace.Troll;
            this.OwnStats.HealthPoints = startHp * (float)1.2;
            this.OwnStats.AttackPoints = startAp * (float)1.2;
            this.OwnStats.DefensePoints = startDp * (float)1.2;
            this.OwnStats.Speed = startS * (float) 0.8;
        }

        public Troll(SStats startStats) : base()
        {
            this.OwnStats.Race = ERace.Troll;
            this.OwnStats.HealthPoints = startStats.HealthPoints * (float)1.2;
            this.OwnStats.AttackPoints = startStats.HealthPoints * (float)1.2;
            this.OwnStats.DefensePoints = startStats.AttackPoints * (float)1.2;
            this.OwnStats.Speed = startStats.DefensePoints * (float)0.8;
        }
    }
}