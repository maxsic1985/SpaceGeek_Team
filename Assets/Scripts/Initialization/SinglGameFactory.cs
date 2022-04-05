using UnityEngine;
using GeekSpace.CONSTANT;
using GeekSpace.ENEMY;
using GeekSpace.EXTENSHION;
using GeekSpace.MODEL;
using GeekSpace.MOVE;
using GeekSpace.POOL;
namespace GeekSpace
{
    internal class SinglGameFactory : IAbstractGameFactory
    {
        private IInputInitialisation _inputInitialisation;

        Camera camera = Camera.main;
        System.Random random = new System.Random();
        private IPool gunBulletPool;
        private Player player;
        private Controllers _controllers;
        private readonly GameData _gameData;
        public SinglGameFactory(Controllers controllers,GameData gameData)
        {
            _controllers = controllers;
            _gameData = gameData;
        }

        public void CreateEnemy()
        {
            var enemyPoolAsteroid = EnemyPoolFactory.EnemyPoolCreate(EnemyType.Asteroid);
            var enemyAsteroidPoolOperator = new EnemyPoolOperator(enemyPoolAsteroid, MaximumsManager.ASTEROIDS_MAXIMUM, EnemyType.Asteroid,_gameData.AsteroidBurst);
            var timerSystemAsteroidSpawn = new TimerSystem(true, true, 15);
            IMoveble nullMove = new MoveNOTHING();
            var enemyAsteroidController = new EnemyController(timerSystemAsteroidSpawn, enemyPoolAsteroid, random, nullMove);
            var enemyPoolShip = EnemyPoolFactory.EnemyPoolCreate(EnemyType.Ship);
            var enemyShipPoolOperator = new EnemyPoolOperator(enemyPoolShip, MaximumsManager.SHIP_MAXIMUM, EnemyType.Ship,_gameData.ShipBurst);
            var timerSystemShipSpawn = new TimerSystem(true, true, 35);
            var timerSystemShipShooting = new TimerSystem(true, true, enemyShipPoolOperator.CurrentModel.WeaponModel.Cooldown);
            IMoveble shipMove = new MoveTransformEnemy(enemyShipPoolOperator.CurrentModel, player.PlayerProvider.gameObject);
            var enemyShipController = new EnemyController(timerSystemShipSpawn, enemyPoolShip, random, shipMove);
            IShootController enemyShootController = new EnemyShootController(timerSystemShipShooting, gunBulletPool, enemyShipPoolOperator.CurrentModel.Object.transform, enemyShipPoolOperator.CurrentModel.Object, EnemyParametrsManager.TARGET_LAYER,_gameData.PlayerFireClip);
            _controllers.Add(enemyAsteroidController);
            _controllers.Add(enemyShipController);
            _controllers.Add(enemyShootController);
        }

        public void CreatePlayer()
        {
            var startPosition = camera.GetCentrAccordingCamera();
            var startShipAngle = PlayerParametrsManager.SINGLE_SHIP_ANGLE;
            var inputController = new InputController(_inputInitialisation);

            var playerWeaponModel = WeaponModelFactory.WeaponModelCreate(WeaponType.ChainGunMk1);
            var playerModel = new PlayerModel(PathsManager.PLAYER_PREFAB, WeaponType.ChainGunMk1, playerWeaponModel, startPosition, startShipAngle, PlayerParametrsManager.PLAYER_HEALTH, PlayerParametrsManager.PLAYER_SPEED);
            IMoveble playerMove = new MoveTransform(playerModel, _inputInitialisation);

            player = new Player(playerMove, playerModel);
            var playerMoveController = new PlayerMoveController(player);
            gunBulletPool = BulletPoolFactory.BulletPoolCreate(WeaponType.ChainGunMk1);
            var bulletModel = new BulletModel(gunBulletPool, player.PlayerProvider.transform.position, 2);
            var bulletPoolOperator = new BulletPoolOperator(gunBulletPool, bulletModel, MaximumsManager.BULLETS_MAXIMUM);
            var playerReloadCooldown = player.PlayerProvider.PlayerModel.WeaponModel.Cooldown;
            var shootTimer = new TimerSystem(true, true, playerReloadCooldown);
            IShootController playerShootController = new ShootControllerWithAutoShoot(shootTimer, gunBulletPool, player.PlayerProvider.transform, player.PlayerProvider.gameObject, PlayerParametrsManager.TARGET_LAYER,_gameData.PlayerFireClip);

            _controllers.Add(inputController);
            _controllers.Add(playerMoveController);
            _controllers.Add(playerShootController);
        }

        public IInputInitialisation SetInputPlayerOne(IInputInitialisation inputInitialisation)
        {
            _inputInitialisation = inputInitialisation;

            return _inputInitialisation;
        }

    }
}