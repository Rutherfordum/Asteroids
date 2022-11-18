using Unity.Entities;
using UnityEngine;

public partial class PlayerMoveSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Transform transform, in MoveData moveData, in InputData inputData) =>
        {
            if (!inputData.MoveAction) return;

            transform.position += new Vector3(inputData.MoveVector.x, 0, inputData.MoveVector.y) * moveData.Speed;

            Quaternion rot = Quaternion.LookRotation(new Vector3(inputData.MoveVector.x, 0, inputData.MoveVector.y));
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, moveData.TurningSpeed * Time.DeltaTime);

        }).WithoutBurst().Run();
    }
}