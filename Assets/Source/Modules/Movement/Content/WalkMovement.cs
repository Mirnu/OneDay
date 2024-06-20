using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using Zenject;

namespace Movement 
{
    internal class WalkMovement : IInitializable, IMovement, IDisposable
    {
        private IInputHandler _inputHandler;
        private Character _character;
        public float _speed = 8f;

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

        public void Dispose() => Disable();

        private void MoveHorizontal(float delta) =>
            _character.transform.Translate(Vector2.right * delta * Time.deltaTime * _speed);

        private void MoveVertical(float delta) =>
            _character.transform.Translate(Vector2.up * delta * Time.deltaTime * _speed);

        public void SetSpeed(float speed)
            => _speed = Mathf.Max(0, speed);
    }
}
