namespace Asteroid.Interfaces
{
    public interface IMoveAbility : IAbility
    {
        public float Speed { get; set; }
        public float TurningSpeed { get; set; }

    }
}
