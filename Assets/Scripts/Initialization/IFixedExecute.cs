
namespace GeekSpace
{
    public interface IFixedExecute : IController
    {
        void FixedExecute(float fixedDeltaTime);
    }
}