using GeekSpace.ACTION;
using GeekSpace.INPUT;
namespace GeekSpace
{
    public sealed class GameSinglInitialisation : IGameStrategy
    {
        private IAbstractGameFactory _gameFactory;
        #region ClassLifeCycles
        internal GameSinglInitialisation( IAbstractGameFactory fabric)
        {
            this._gameFactory = fabric;
            GameInit();
        }

        public void GameInit()
        {
            _gameFactory.SetInputPlayerOne(new InputInitializatioAxis());
            _gameFactory.CreatePlayer();
            _gameFactory.CreateEnemy();

            var DestroyController = new DestroyController();
            var beyondScreenActer = new BeyondScreenActer();
        }
        #endregion
    }

}