using Asteroid.ComponentData;
using Unity.Entities;
using UnityEngine;

namespace Asteroid.Systems
{
    public partial class PlayerMoveSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((Transform transform, in InputData inputData, in MoveData moveData) =>
            {
                if (!inputData.MoveAction)
                    return;

                var pos = transform.position;
                pos += new Vector3(inputData.Move.x, 0, inputData.Move.y) * moveData.Speed;

                transform.position = pos;
                Quaternion rotation = Quaternion.LookRotation(new Vector3(inputData.Move.x, 0, inputData.Move.y));

                transform.rotation =
                    Quaternion.Lerp(transform.rotation, rotation, moveData.TurningSpeed * Time.DeltaTime);
            }).WithoutBurst().Run();
        }
    }
}
