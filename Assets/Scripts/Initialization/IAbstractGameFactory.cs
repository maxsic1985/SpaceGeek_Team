
namespace GeekSpace
{
    internal interface IAbstractGameFactory
    {
        IInputInitialisation SetInputPlayerOne(IInputInitialisation inputInitialisation);
        void CreatePlayer();
        void CreateEnemy();

    }
}