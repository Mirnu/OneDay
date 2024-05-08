using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Movement 
{
    internal class WalkMovement : IInitializable
    {
        private IInputHandler _inputHandler;
        private Character _character;

        [Inject]
        public void Construct(IInputHandler inputHandler, Character character)
        {
            _inputHandler = inputHandler;
            _character = character;
        }

        public void Initialize()
        {
            _inputHandler.HorizontalAxis += MoveHorizontal;
            _inputHandler.VerticalAxis += MoveVertical;
        }

        private void MoveHorizontal(float delta) =>
            _character.transform.Translate(Vector2.right * delta);

        private void MoveVertical(float delta) =>
            _character.transform.Translate(Vector2.up * delta);
    }
}
