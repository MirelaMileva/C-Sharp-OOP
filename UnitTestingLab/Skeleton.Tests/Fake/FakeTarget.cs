namespace Skeleton.Tests.Fake
{
    public class FakeTarget : ITarget
    {
        public const int DefaultExperience = 100;
        public int GiveExperience() => DefaultExperience;

        public bool IsDead() => true;

        public void TakeAttack(int damage)
        {
           
        }
    }
}
