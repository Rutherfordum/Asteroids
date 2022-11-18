using Asteroid.ComponentData;
using Unity.Entities;
using UnityEngine;

namespace Asteroid.Systems
{
    public partial class BulletMoveSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((
                Transform transform,
                in BulletData bulletData,
                in MoveData moveData) =>
            {
                transform.Translate(Vector3.forward * (Time.DeltaTime * moveData.Speed) * 100);
            }).WithoutBurst().Run();
        }
    }
}