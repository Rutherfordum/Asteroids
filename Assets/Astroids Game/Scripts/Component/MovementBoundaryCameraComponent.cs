//Restriction of the ship's movement within
//the boundaries of the camera

using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class MovementBoundaryCameraComponent : MonoBehaviour, IConvertGameObjectToEntity
{
    private Vector3 _pointZero;
    private Vector3 _pointMax;

    private void Awake()
    {
        _pointMax = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        _pointZero = Camera.main.ScreenToWorldPoint(Vector3.zero);
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new ScreenData()
        {
            PointZero = _pointZero,
            PointMax = _pointMax
        });
    }
}

public struct ScreenData : IComponentData
{
    public float3 PointZero;
    public float3 PointMax;
}