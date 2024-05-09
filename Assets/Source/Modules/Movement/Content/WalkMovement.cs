using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Movement 
{
    internal class WalkMovement : IInitializable, IMovement
    {
        private IInputHandler _inputHandler;
        private Character _character;

        [Inject]
        public void Construct(IInputHandler inputHandler, Character character)
        {
            _inputHandler = inputHandler;
            _character = character;
        }

        public void Initialize() => Enable();

        public void Enable()
        {
            _inputHandler.HorizontalAxis += MoveHorizontal;
            _inputHandler.VerticalAxis += MoveVertical;
        }

        public void Disable()
        {
            _inputHandler.HorizontalAxis -= MoveHorizontal;
            _inputHandler.VerticalAxis -= MoveVertical;
        }

        private void MoveHorizontal(float delta) =>
            _character.transform.Translate(Vector2.right * delta);

        private void MoveVertical(float delta) =>
            _character.transform.Translate(Vector2.up * delta * Time.deltaTime);
    }
}
