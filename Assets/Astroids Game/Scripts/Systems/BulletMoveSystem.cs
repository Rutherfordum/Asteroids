using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial class BulletMoveSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Rotation rotation, ref Translation position, ref BulletData bulletData) =>
        {
            var pos = position.Value;
            pos += math.forward(rotation.Value) * bulletData.Speed;
            position.Value = pos;

        }).Run();
    }
}
