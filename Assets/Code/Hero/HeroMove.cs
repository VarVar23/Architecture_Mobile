using CameraLogic;
using Infrastucture;
using Input;
using UnityEngine;

namespace Hero
{
    public class HeroMove : MonoBehaviour
    {
        public CharacterController Controller;
        public float MovementSpeed;

        private IInputService _inputService;
        private Transform _camera;

        private void Awake()
        {
            _inputService = Game.InputService;
        }

        private void Start()
        {
            _camera = Camera.main.transform;
            CameraFollow();
        }

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;

            if(_inputService.Axis.sqrMagnitude > Constants.Epsilon)
            {
                movementVector = _camera.TransformDirection(_inputService.Axis);
                movementVector.y = 0;
                movementVector.Normalize();

                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;

            Controller.Move(MovementSpeed * movementVector * Time.deltaTime);
        }

        private void CameraFollow() =>
            _camera.GetComponent<CameraFollow>().Follow(gameObject);
    }
}