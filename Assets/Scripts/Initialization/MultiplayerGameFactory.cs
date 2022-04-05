using UnityEngine;
using GeekSpace.CONSTANT;
using GeekSpace.ENEMY;
using GeekSpace.EXTENSHION;
using GeekSpace.INPUT;
using GeekSpace.MODEL;
using GeekSpace.MOVE;
using GeekSpace.POOL;
namespace GeekSpace
{
    internal class MultiplayerGameFactory : IAbstractGameFactoryMultyPlayer
    {
        private IInputInitialisation _inputInitialisation;
        private IInputInitialisation _inputInitialisationTwo;

        Camera camera = Camera.main;
        System.Random random = new System.Random();
        private IPool gunBulletPool;
        private IPool gunBulletPoolTwo;
        private Player player;
        private Player playerTwo;
        private Controllers _controllers;
        private readonly GameData _gameData;
        public MultiplayerGameFactory(Controllers controllers, GameData gameData)
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
            var timerSystemShipSpawn = new TimerSystem(true, true, 35);
            _controllers.Add(enemyAsteroidController);

        }
        public void CreatePlayer()
        {
            var startPositionOne = Extention.GetRightSideVector2AccordingCamera(Camera.main, 2);
            var startPositionTwo = Extention.GetLeftSideVector2AccordingCamera(Camera.main, 2);
            var playerOneAngle = PlayerParametrsManager.MULTI_SHIP_ANGLE_PLAYER1;
            var playerTwoAngle = PlayerParametrsManager.MULTI_SHIP_ANGLE_PLAYER2;

            var inputController = new InputController(_inputInitialisation);
            var inputControllerTwo = new InputController(_inputInitialisationTwo);

            var playerWeaponModelOne = WeaponModelFactory.WeaponModelCreate(WeaponType.ChainGunMk1);
            var playerModelOne = new PlayerModel(PathsManager.PLAYER_PREFAB, WeaponType.ChainGunMk1, playerWeaponModelOne, startPositionOne, playerOneAngle, PlayerParametrsManager.PLAYER_HEALTH, PlayerParametrsManager.PLAYER_SPEED);
            IMoveble playerMoveOne = new MoveTransform(playerModelOne, _inputInitialisation);

            var playerWeaponModelTwo = WeaponModelFactory.WeaponModelCreate(WeaponType.ChainGunMk1);
            var playerModelTwo = new PlayerModel(PathsManager.PLAYER_PREFAB_TWO, WeaponType.ChainGunMk1, playerWeaponModelTwo, startPositionTwo, playerTwoAngle, PlayerParametrsManager.PLAYER_HEALTH, PlayerParametrsManager.PLAYER_SPEED);
            IMoveble playerMoveTwo = new MoveTransform(playerModelTwo, _inputInitialisationTwo);

            player = new Player(playerMoveOne, playerModelOne);
            var playerMoveControllerOne = new PlayerMoveController(player);
            gunBulletPool = BulletPoolFactory.BulletPoolCreate(WeaponType.ChainGunMk1);
            var bulletModel = new BulletModel(gunBulletPool, player.PlayerProvider.transform.position, 2);
            var bulletPoolOperator = new BulletPoolOperator(gunBulletPool, bulletModel, MaximumsManager.BULLETS_MAXIMUM);
            var playerReloadCooldown = player.PlayerProvider.PlayerModel.WeaponModel.Cooldown;
            var shootTimer = new TimerSystem(true, true, playerReloadCooldown);
            IShootController playerShootControllerOne = new ShootControllerWithInputBtn(shootTimer, gunBulletPool, player.PlayerProvider.transform, _inputInitialisation as InputInitialisationBtns, _gameData.PlayerFireClip);

            playerTwo = new Player(playerMoveTwo, playerModelTwo);
            var playerMoveControllerTwo = new PlayerMoveController(playerTwo);
            gunBulletPoolTwo = BulletPoolFactory.BulletPoolCreate(WeaponType.ChainGunMk1);
            var bulletModelTwo = new BulletModel(gunBulletPoolTwo, playerTwo.PlayerProvider.transform.position, 2);
            var bulletPoolOperatorTwo = new BulletPoolOperator(gunBulletPoolTwo, bulletModel, MaximumsManager.BULLETS_MAXIMUM);
            var playerReloadCooldownTwo = playerTwo.PlayerProvider.PlayerModel.WeaponModel.Cooldown;
            var shootTimerTwo = new TimerSystem(true, true, playerReloadCooldownTwo);
            IShootController playerShootControllerTwo = new ShootControllerWithInputBtn(shootTimer, gunBulletPoolTwo, playerTwo.PlayerProvider.transform, _inputInitialisationTwo as InputInitialisationBtns, _gameData.PlayerFireClip);

            _controllers.Add(inputController);
            _controllers.Add(inputControllerTwo);

            _controllers.Add(playerMoveControllerOne);
            _controllers.Add(playerShootControllerOne);

            _controllers.Add(playerMoveControllerTwo);
            _controllers.Add(playerShootControllerTwo);
        }
        public IInputInitialisation SetInputPlayerOne(IInputInitialisation inputInitialisation)
        {
            _inputInitialisation = inputInitialisation;

            return _inputInitialisation;
        }
        public IInputInitialisation SetInputPlayerTwo(IInputInitialisation inputInitialisationTwo)
        {
            _inputInitialisationTwo = inputInitialisationTwo;

            return _inputInitialisationTwo;
        }
    }
}
