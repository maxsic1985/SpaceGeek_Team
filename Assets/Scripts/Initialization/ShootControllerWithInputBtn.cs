using UnityEngine;
using GeekSpace.EXTENSHION;
using GeekSpace.INPUT;
using GeekSpace.POOL;
namespace GeekSpace
{
    internal class ShootControllerWithInputBtn : IShootController,IExecute
    {
        private TimerSystem _timerSystem;
        private IPool _enemyPool;
        private Transform _startPosition;
        InputInitialisationBtns _getShoot;
        internal AudioClip _shootAudioClip;
        private Camera _camera;
        public ShootControllerWithInputBtn(TimerSystem timerSystem, IPool enemyPool, Transform startPosition, InputInitialisationBtns getShoot, AudioClip shootAudioClip)
        {
            _startPosition = startPosition;
            _timerSystem = timerSystem;
            _enemyPool = enemyPool;
            _getShoot = getShoot;
            _shootAudioClip = shootAudioClip;
            _camera = Camera.main;
        }


        public void GetShoot()
        {
            if (_timerSystem.CheckEvent())
            {
                Extention.GetOrAddComponent<AudioSource>(_camera.gameObject).PlayOneShot(_shootAudioClip);
                var a = _enemyPool.Pop(_startPosition.localPosition, _startPosition.localRotation);
                a.GetComponent<Rigidbody2D>().AddForce(_startPosition.transform.up * 3);
                return;
            }
        }

        public void Execute(float deltaTime)
        {
            if (_getShoot.GetFire())
             GetShoot();
        }

    }
}
