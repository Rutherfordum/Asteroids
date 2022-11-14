using Asteroid.Components;
using Unity.Entities;
using UnityEngine;
using UserInput.Components;

namespace Asteroid.Systems
{
    public class MoveShipSystem: ComponentSystem
    {
        private EntityQuery _entityQuery;

        protected override void OnCreate()
        {
            _entityQuery = GetEntityQuery(ComponentType.ReadOnly<InputMoveData>(),
                ComponentType.ReadOnly<MoveShipData>(), 
                ComponentType.ReadOnly<Transform>());
        }

        protected override void OnUpdate()
        {
            Entities.With(_entityQuery)
                .ForEach((Entity entity,Transform transform ,ref InputMoveData inputData, ref MoveShipData moveData) =>
                {
                    var pos = transform.position;
                    pos += new Vector3(inputData.Move.x,inputData.Move.y) * moveData.Speed;

                    transform.position = pos;
                    Quaternion rotation = Quaternion.LookRotation(new Vector3(inputData.Move.x, 0, inputData.Move.y));

                    transform.rotation =
                        Quaternion.Lerp(transform.rotation, rotation, moveData.SpeedRotate * Time.DeltaTime);

                });

        }
    }
}