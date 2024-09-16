using UnityEngine;

namespace Input
{
    public interface IInputService
    {
        public Vector2 Axis { get; }
        public bool IsAttackButtonUp();
    }
}