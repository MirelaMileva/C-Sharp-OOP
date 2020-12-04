namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        public Rifle(string name, int bulletsCount) 
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            //TODO What about 9 bullets
            if (this.BulletsCount <= 10)
            {
                return 0;
            }

            this.BulletsCount -= 10;

            return 10;
        }
    }
}