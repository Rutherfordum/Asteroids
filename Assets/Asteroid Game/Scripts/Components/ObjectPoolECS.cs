using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class ObjectPoolECS
{
    private GameObject _prefab;
    private Queue<GameObject> _pools = new Queue<GameObject>();
    private EntityManager _entityManager;
    private Entity _entity;

    public ObjectPoolECS(GameObject prefab, Entity entity)
    {
        _prefab = prefab;
        _entity = entity;
    }

    public void LoadToScene(int count)
    {
        _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        for (int i = 0; i < count; i++)
        {
            GameObject bullet = MonoBehaviour.Instantiate(_prefab);
            bullet.SetActive(false);
            _entityManager.SetEnabled(_entity, false);
            _pools.Enqueue(bullet);
        }
    }

    public void Get(Vector3 position, Quaternion rotation)
    {
        if (_pools.Count == 0)
            for (int i = 0; i < 5; i++)
            {
                GameObject obj = MonoBehaviour.Instantiate(_prefab);
                obj.SetActive(false);
                _entityManager.SetEnabled(_entity, false);
                _pools.Enqueue(obj);
            }

        GameObject bullet = _pools.Dequeue();
        bullet.transform.SetPositionAndRotation(position, rotation);
        bullet.SetActive(true);
        _entityManager.SetEnabled(_entity, true);
    }

    public void Set(GameObject obj)
    {
        obj.SetActive(false);
        _pools.Enqueue(obj);
        _entityManager.SetEnabled(_entity, false);
    }
}
