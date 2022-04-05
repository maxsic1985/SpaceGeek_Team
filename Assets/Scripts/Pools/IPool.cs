using UnityEngine;

namespace GeekSpace.POOL
{
    public interface IPool
    {
        public GameObject Pop(Vector3 position, Quaternion quaternion);
        public void Push(GameObject go);
    }
}

