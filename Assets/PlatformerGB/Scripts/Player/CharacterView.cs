using UnityEngine;

namespace Platformer2D
{
    public sealed class CharacterView : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Rigidbody2D rigidbody;
        [SerializeField] private Collider2D collider;
        [SerializeField] private float _walkSpeed = 1.0f;
        [SerializeField] private float _jumpSpeed = 2.0f;
        [SerializeField] private float _animationsSpeed = 3.0f;
        [SerializeField] private float _acceleration = -10.0f;
        [SerializeField] private float _moveTresh = 0.1f;
        [SerializeField] private float _flyTresh = 0.4f;
        [SerializeField] private float _groundLevel = 0.5f;
        [SerializeField] private float _playerDamage = 10;

        public SpriteRenderer SpriteRenderer  => _spriteRenderer;

        public float WalkSpeed  => _walkSpeed;

        public float JumpSpeed  => _jumpSpeed;

        public float Acceleration  => _acceleration;

        public float MoveTresh  => _moveTresh;

        public float FlyTresh => _flyTresh;

        public float GroundLevel  => _groundLevel;

        public float AnimationsSpeed  => _animationsSpeed;

        public Rigidbody2D Rigidbody  => rigidbody;
        public Collider2D Collider  => collider;

        public float PlayerDamage  => _playerDamage; 
    }
}
