using Asteroid.ComponentData;
using Asteroid.Components;
using Asteroid.Interfaces;
using Unity.Entities;

namespace Asteroid.Systems
{
    public partial class LifeTimeSystem: SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((AbilitiesComponent abilities, in LifeTimeData lifeTime) =>
            {
                foreach (var ability in abilities.Abilities)
                    if(ability is ILifeTimeAbility lifeTimeAbility)
                        lifeTimeAbility.Execute();

            }).WithoutBurst().Run();
        }
    }
}