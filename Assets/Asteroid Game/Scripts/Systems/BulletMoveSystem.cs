using Unity.Entities;
using UnityEngine;

public partial class BulletMoveSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((
            Transform transform,
            AbilitiesComponent abilities,
            in BulletData bulletData,
            in MoveData moveData) =>
        {
            transform.Translate(Vector3.forward * (Time.DeltaTime * moveData.Speed) * 100);
        }).WithoutBurst().Run();
    }
}