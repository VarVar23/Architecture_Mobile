using UnityEngine;

namespace Hero
{
    public class HeroAnimator : MonoBehaviour
    {
        private static readonly int Move = Animator.StringToHash("move");

        [SerializeField] private CharacterController _playerController;
        [SerializeField] private Animator _playerAnimator;

        private void Update()
        {
            _playerAnimator.SetFloat(Move, _playerController.velocity.magnitude, 0.1f, Time.deltaTime);
        }
    }
}

