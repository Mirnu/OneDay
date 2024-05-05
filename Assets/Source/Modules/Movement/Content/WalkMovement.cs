using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Movement 
{
    internal class WalkMovement : IInitializable
    {
        private IInputHandler _inputHandler;

        [Inject]
        public void Construct(IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        public void Initialize()
        {
            _inputHandler.KeyUp += delegate { Debug.Log("Hello World"); };
        }
    }
}
