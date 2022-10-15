using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private T _prefab;
    private Transform _container;
    private List<T> _gameObjects = new List<T>();
    
    public ObjectPool(T prefab, int capacity, Transform container)
    {
        _prefab = prefab;
        _container = container;
        

        for (int i = 0; i < capacity; i++)
        {
            var newObject = Object.Instantiate(prefab, _container);
            newObject.gameObject.SetActive((false));
            _gameObjects.Add((newObject));
        }
    }

    public bool TryGetObject<T>(out T result) where T : class
    {
        result = _gameObjects.FirstOrDefault(p => p.gameObject.activeInHierarchy == false) as T;

        if (result == null)
            result = ExpandPool() as T;

        return result != null;
    }

    private T ExpandPool()
    {
        var newObject = Object.Instantiate(_prefab, _container);
        newObject.gameObject.SetActive(false);
        _gameObjects.Add(newObject);
        return newObject;
    }
}