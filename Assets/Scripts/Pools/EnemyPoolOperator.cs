using UnityEngine;
using GeekSpace.ENEMY;
using GeekSpace.MODEL;
using GeekSpace.PROVIDER;
namespace GeekSpace.POOL
{
    internal sealed class EnemyPoolOperator 
    {
        private readonly IPool _pool;
        private readonly int _poolSize;
        private readonly EnemyType _enemyType;
        private readonly AudioClip _audioClip;

        internal EnemyModel CurrentModel { get; private set; }

        internal EnemyPoolOperator(IPool pool, int poolSize, EnemyType enemyType, AudioClip audioClip)    
        {
            _pool = pool;
            _poolSize = poolSize;
            _enemyType = enemyType;
            _audioClip = audioClip;
            InitiatePool();
        }

        private void InitiatePool()
        {
            GameObject[] objects = new GameObject[_poolSize];

            for (int i = 0; i < _poolSize; i++)
            {
                var enemyModel = EnemyModelFactory.EnemyModelCreate(_pool, _enemyType,_audioClip);

                objects[i] = _pool.Pop(enemyModel.Position, Quaternion.identity);

                var EnemyProvider = objects[i].GetComponent<EnemyProviderBeh>();
                EnemyProvider.EnemyModel = enemyModel;
                CurrentModel = enemyModel;
            }
            for (int i = 0; i < _poolSize; i++)
            {
                _pool.Push(objects[i]);
            }

        }
        

    }

}
