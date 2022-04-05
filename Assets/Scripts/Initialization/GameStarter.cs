using UnityEngine;
namespace GeekSpace
{
    public sealed class GameStarter : MonoBehaviour
    {
        #region Fields
        private Controllers _controllers;
        [SerializeField] private GameData gameData;
        #endregion
        #region UnityMethods
        void Start()
        {
            _controllers = new Controllers();

            IGameStrategy result = gameData._GameType switch
            {
                GameType.SINGLE => new GameSinglInitialisation( new SinglGameFactory(_controllers,gameData)),
                GameType.MULTIPLAYER => new GameInitialisationMultiplayer(new MultiplayerGameFactory(_controllers,gameData), gameData),
                _ => new GameSinglInitialisation( new SinglGameFactory(_controllers,gameData)),
            };


            _controllers.Initialization();

        }
        private void Update()
        {
            if (Pause.gameIsPaused) return;
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime);
        }
        private void FixedUpdate()
        {
            var fixedDeltaTime = Time.fixedDeltaTime;
            _controllers.FixedExecute(fixedDeltaTime);
        }

        private void OnDestroy()
        {
            _controllers.Cleanup();
        }
        #endregion
    }
}