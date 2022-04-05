using UnityEngine;

namespace GeekSpace
{
    public interface IExecute : IController
    {
        void Execute(float deltaTime);
    }
}