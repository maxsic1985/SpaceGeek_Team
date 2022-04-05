using System.Collections.Generic;
using UnityEngine;
using GeekSpace.CONSTANT;
namespace GeekSpace.POOL
{
    internal sealed class ObjectPool : IPool
    {
        private readonly Stack<GameObject> _stack = new Stack<GameObject>();
        private readonly GameObject _prefab;
        private readonly Vector3 _parent;
        private readonly Transform _rootPool;

        public ObjectPool(GameObject prefab, Vector3 parent)
        {
            _prefab = prefab;
            _parent = parent;

            if (_rootPool == null)
            {
                _rootPool = new GameObject(NameManager.POOL_ENEMY).transform;
            }
        }

        public void Push(GameObject go)
        {
            _stack.Push(go);
            go.transform.position = _parent;
            go.transform.SetParent(_rootPool);
            go.SetActive(false);
        }

        public GameObject Pop(Vector3 position,Quaternion quaternion)
        {
            GameObject go;
            if (_stack.Count == 0)
            {
                go = Object.Instantiate(_prefab, _parent, quaternion);
            }
            else
            {
                go = _stack.Pop();
                go.transform.position = position;
                go.transform.rotation = quaternion;

            }
            go.SetActive(true);
            return go;
        }
    }
}