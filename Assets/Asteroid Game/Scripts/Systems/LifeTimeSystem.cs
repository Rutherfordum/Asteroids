using Unity.Entities;

public partial class LifeTimeSystem : SystemBase
{
    private EntityManager _entityManager;
    protected override void OnCreate()
    {
        _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
    }

    protected override void OnUpdate()
    {
        Entities.ForEach((AbilitiesComponent abilities, Entity entity ,ref LifeTimeData lifeTimeData) =>
        {
            foreach (var ability in abilities.Abilities)
            {
                if (ability is ILifeTimeAbility lifeTimeAbility)
                {
                    if (lifeTimeData.LifeTime <= 0)
                    {
                       // _entityManager.DestroyEntity(entity);
                        lifeTimeAbility.Execute();
                    }
                }
            }

            lifeTimeData.LifeTime -= Time.DeltaTime;

        }).WithStructuralChanges().WithoutBurst().Run();
    }
}
