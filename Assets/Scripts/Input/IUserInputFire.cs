using System;

namespace GeekSpace.INPUT
{
    public interface IUserInputFire
    {
        event Action<float> AxisOnChange;
        void GetFire();
    }
}