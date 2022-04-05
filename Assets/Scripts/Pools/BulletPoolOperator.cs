using UnityEngine;
using GeekSpace.PROVIDER;
using GeekSpace.MODEL;
namespace GeekSpace.POOL
{
    internal class BulletPoolOperator 
    {
        private IPool _pool;
        private BulletModel _bulletModel;
        private int _poolSize;

        internal BulletPoolOperator(IPool pool, BulletModel bulletModel, int poolSize)
        {
            _pool = pool;
            _bulletModel = bulletModel;
            _poolSize = poolSize;
            InitiatePool();
        }

        private void InitiatePool()
        {
            GameObject[] objects = new GameObject[_poolSize];

            for (int i = 0; i < _poolSize; i++)
            {
                objects[i] = _pool.Pop(_bulletModel.Position, Quaternion.identity);

                var BulletProvider = objects[i].GetComponent<BulletProviderBeh>();
                BulletProvider.BulletModel = _bulletModel;
            }
            for (int i = 0; i < _poolSize; i++)
            {
                _pool.Push(objects[i]);
            }

        }
    }
}