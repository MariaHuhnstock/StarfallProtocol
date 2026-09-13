using System.Collections.Generic;
using UnityEngine;

namespace StarfallProtocol.Pooling
{
    public class ObjectPool<T> where T : Component
    {
        private readonly T _prefab;
        private readonly Transform _parent;
        private readonly Queue<T> _inactiveObjects = new Queue<T>();

        public ObjectPool(T prefab, Transform parent = null, int initialSize = 0)
        {
            _prefab = prefab;
            _parent = parent;

            for (int i = 0; i < initialSize; i++)
            {
                T obj = CreateNewObject();
                ReturnToPool(obj);
            }
        }

        public T Get(Vector3 position, Quaternion rotation)
        {
            T obj = _inactiveObjects.Count > 0
                ? _inactiveObjects.Dequeue()
                : CreateNewObject();

            obj.transform.SetPositionAndRotation(position, rotation);
            obj.gameObject.SetActive(true);
            return obj;
        }

        public void ReturnToPool(T obj)
        {
            obj.gameObject.SetActive(false);
            _inactiveObjects.Enqueue(obj);
        }

        private T CreateNewObject()
        {
            T obj = Object.Instantiate(_prefab, _parent);
            obj.gameObject.SetActive(false);
            return obj;
        }
    }
}