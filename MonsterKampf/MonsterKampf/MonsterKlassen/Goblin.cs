namespace MonsterKampf
{
    public class Goblin: Monster
    {

        public Goblin(float startHp, float startAp, float startDp, float startS) : base()
        {
            this.OwnStats.Race = ERace.Goblin;
            this.OwnStats.HealthPoints = startHp * (float)0.8;
            this.OwnStats.AttackPoints = startAp * (float)0.8;
            this.OwnStats.DefensePoints = startDp * (float)0.8;
            this.OwnStats.Speed = startS * (float)1.2;            
        }

        public Goblin(SStats startStats) : base()
        {
            this.OwnStats.Race = ERace.Goblin;
            this.OwnStats.HealthPoints = startStats.HealthPoints * (float)0.8;
            this.OwnStats.AttackPoints = startStats.HealthPoints * (float)0.8;
            this.OwnStats.DefensePoints = startStats.AttackPoints * (float)0.8;  
            this.OwnStats.Speed = startStats.DefensePoints * (float)1.2;
        }
    }
}