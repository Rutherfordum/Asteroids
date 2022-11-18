using Unity.Entities;
using UnityEngine;

public class MevmentBoundaryCameraComponent : MonoBehaviour, IConvertGameObjectToEntity
{
    private Vector3 _pointMax;
    private Vector3 _pointZero;

    void Awake()
    {
        _pointMax = GetScreenResolutionToWorldPoint().Item1;
        _pointZero = GetScreenResolutionToWorldPoint().Item2;
    }

    /// <summary>
    /// Get Screen Resolution To World Point 
    /// </summary>
    /// <returns> point1 is a max point world, point2 is a zero point world</returns>
    public (Vector3 point1, Vector3 point2) GetScreenResolutionToWorldPoint()
    {
        Vector3 point1 = new Vector3();
        Vector3 point2 = new Vector3();

        point1 = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));

        point2 = Camera.main.ScreenToWorldPoint(Vector3.zero);

        return (point1, point2);
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new ScreenData()
        {
            PointMax = _pointMax,
            PointZero = _pointZero
        });
    }
}
