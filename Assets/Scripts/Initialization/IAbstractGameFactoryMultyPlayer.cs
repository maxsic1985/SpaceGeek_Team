namespace GeekSpace
{
    internal interface IAbstractGameFactoryMultyPlayer:IAbstractGameFactory
    {
        IInputInitialisation SetInputPlayerTwo(IInputInitialisation inputInitialisation);
    }
}