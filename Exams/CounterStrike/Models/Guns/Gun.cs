namespace CounterStrike.Models.Guns
{
    using System;

    using Models.Guns.Contracts;
    using Utilities.Messages;

    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsCount;
        protected Gun(string name, int bulletsCount)
        {
            this.Name = name;
            this.BulletsCount = bulletsCount;
        }
        public string Name 
        { 
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }

                this.name = value;
            }
        }

        public int BulletsCount 
        { 
            get
            {
                return this.bulletsCount;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunBulletsCount);
                }

                this.bulletsCount = value;
            }
        }

        public abstract int Fire();
    }
}
