using Unity.Entities;
using Unity.Mathematics;

public struct ColliderData: IComponentData
{
    public ColliderType ColliderType;
    public float3 SphereCenter;
    public float SphereRadius;
    public float3 CapsuleStart;
    public float3 CapsuleEnd;
    public float CapsuleRadius;
    public float3 BoxCenter;
    public float3 BoxHalthExtents;
    public quaternion BoxOrientation;
    public bool initialTakeOff;
}
