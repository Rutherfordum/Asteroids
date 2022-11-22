using Unity.Entities;

public interface ILifeTimeAbility : IAbility
{
    public float LifeTime { get; set; }
}