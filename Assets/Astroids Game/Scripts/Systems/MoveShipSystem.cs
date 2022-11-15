using Asteroid.Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UserInput.Components;

namespace Asteroid.Systems
{
    public partial class MoveShipSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach(
                (ref Rotation rotation, 
                ref Translation transform,
                ref InputMoveData inputData,
                ref MoveShipData moveData) =>
                {
                    if (!inputData.MoveAction)
                        return;

                    var pos = transform.Value;
                    pos += new float3(inputData.Move.x, 0, inputData.Move.y) * moveData.Speed;
                    transform.Value = pos;

                    quaternion targetRotation = quaternion.LookRotation(new float3(inputData.Move.x, 0, inputData.Move.y),math.up());
                    rotation.Value = math.slerp(rotation.Value, targetRotation, moveData.SpeedRotate);
                }).Run();

        }
    }
}