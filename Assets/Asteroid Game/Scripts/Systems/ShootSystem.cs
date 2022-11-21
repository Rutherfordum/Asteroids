using Unity.Entities;

public partial class ShootSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((AbilitiesComponent abilities, in InputData inputData, in ShootData shootData) =>
        {
            if (!inputData.ShootAction) return;

            foreach (var ability in abilities.Abilities)
            {
                if (ability is IShootAbility shootAbility)
                    shootAbility.Execute();
            }

        }).WithoutBurst().Run();
    }
}