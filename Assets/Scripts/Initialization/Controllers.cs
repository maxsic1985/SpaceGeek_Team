using System.Collections.Generic;
namespace GeekSpace
{
    public class Controllers :IController
    {
        #region Fields
        private readonly List<IInitialisation> _initializeControllers;
        private readonly List<IExecute> _executeControllers;
        private readonly List<IFixedExecute> _fixedExecuteControllers;
        private readonly List<ICleanUp> _cleanupControllers;

        #endregion
        #region ClassLifeCycles
        public Controllers()
        {
            _initializeControllers = new List<IInitialisation>();
            _executeControllers = new List<IExecute>();
            _fixedExecuteControllers = new List<IFixedExecute>();
            _cleanupControllers = new List<ICleanUp>();
        }

        public Controllers Add(IController _controller)
        {
            if (_controller is IInitialisation initializeController)
                _initializeControllers.Add(initializeController);

            if (_controller is IExecute executeController)
                _executeControllers.Add(executeController);

            if (_controller is IFixedExecute fixedExecuteController)
                _fixedExecuteControllers.Add(fixedExecuteController);

            if (_controller is ICleanUp cleanUpController)
                _cleanupControllers.Add(cleanUpController);

            return this;
        }

        #endregion
        #region Methods
        public void Initialization()
        {
            for (var i = 0; i < _initializeControllers.Count; ++i)
            {
                _initializeControllers[i].Initialization();
            }
        }

        public void Execute(float deltaTime)
        {
            for (var index = 0; index < _executeControllers.Count; ++index)
            {
                _executeControllers[index].Execute(deltaTime);
            }
        }

        public void FixedExecute(float fixedDeltaTime)
        {
            for (var index = 0; index < _fixedExecuteControllers.Count; ++index)
            {
                _fixedExecuteControllers[index].FixedExecute(fixedDeltaTime);
            }
        }

        public void Cleanup()
        {
            for (var index = 0; index < _cleanupControllers.Count; ++index)
            {
                _cleanupControllers[index].Cleanup();
            }
        }
        #endregion
    }
}