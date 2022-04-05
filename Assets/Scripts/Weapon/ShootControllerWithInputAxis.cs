using UnityEngine;
using GeekSpace.INPUT;
using GeekSpace.POOL;
namespace GeekSpace
{
    internal class ShootControllerWithInputAxis : IExecute,IShootController
    {
        private TimerSystem _timerSystem;
        private IPool _enemyPool;
        private Transform _startPosition;
        IUserInputFire _getShoot;
        float _onClickFire;
        public ShootControllerWithInputAxis(TimerSystem timerSystem, IPool enemyPool,Transform startPosition,IUserInputFire getShoot)
        {
            _startPosition = startPosition;
            _timerSystem = timerSystem;
            _enemyPool = enemyPool;
            _getShoot = getShoot;
            _getShoot.AxisOnChange += GetInput;
        }



        private void GetInput(float value)
        {
            _onClickFire = value;
        }

        public void GetShoot()
        {
            if (_onClickFire > 0 && _timerSystem.CheckEvent())
            {
                _onClickFire = 0;
                var a = _enemyPool.Pop(_startPosition.position, _startPosition.rotation);
                a.GetComponent<Rigidbody2D>().AddForce(_startPosition.transform.up * 3);
                return;
            }
        }

        public void Execute(float deltaTime)
        {
            GetShoot();          
        }

    }
}