using Asteroid.ComponentData;
using Asteroid.Components;
using Asteroid.Interfaces;
using Unity.Entities;

namespace Asteroid.Systems
{
    public partial class PlayerShootSystem : SystemBase
    {
        private IShootAbility _shootAbility;

        protected override void OnUpdate()
        {
            Entities.ForEach((AbilitiesComponent abilities, in InputData inputData, in ShootData shootData) =>
            {
                if (!inputData.ShootAction) return;

                if (_shootAbility == null)
                    foreach (var ability in abilities.Abilities)
                        if (ability is IShootAbility shootAbility)
                            _shootAbility = shootAbility;

                _shootAbility?.Execute();

            }).WithoutBurst().Run();
        }
    }
}
