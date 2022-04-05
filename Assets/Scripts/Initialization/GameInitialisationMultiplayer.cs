using GeekSpace.ACTION;
using GeekSpace.INPUT;
namespace GeekSpace
{
    internal class GameInitialisationMultiplayer : IGameStrategy
    {
       
        private GameData _gameData;
        private readonly IAbstractGameFactoryMultyPlayer _fabric;
        public GameInitialisationMultiplayer(IAbstractGameFactoryMultyPlayer fabric, GameData gameData)
        {
            this._gameData = gameData;
            this._fabric = fabric;
            GameInit();
        }
        public void GameInit()
        {
            var inputPlayerOne = new InputInitialisationBtns((_gameData.LEFT, _gameData.RIGHT, _gameData.UP, _gameData.DOWN,_gameData.FIRE));
            var inputPlayerTwo = new InputInitialisationBtns((_gameData.AltLEFT, _gameData.AltRIGHT, _gameData.AltUP, _gameData.AltDOWN,_gameData.AltFIRE));
            _fabric.SetInputPlayerOne(inputPlayerOne);
            _fabric.SetInputPlayerTwo(inputPlayerTwo);
            _fabric.CreatePlayer();
            _fabric.CreateEnemy();
            var beyondScreenActer = new BeyondScreenActer();
        }
    }
}