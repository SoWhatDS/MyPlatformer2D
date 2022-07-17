using UnityEngine;

namespace Platformer2D
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Transform _targetPlayer;
        [SerializeField] private SpriteRenderer _spriteRendererEnemy;
        [SerializeField] private float _animSpeedEnemy;
        [SerializeField] private float _enemyHP;

        public Rigidbody2D Rigidbody  => _rigidbody;

        public Transform TargetPlayer => _targetPlayer;

        public SpriteRenderer SpriteRendererEnemy  => _spriteRendererEnemy; 
        public float AnimSpeedEnemy => _animSpeedEnemy;

        public float EnemyHP { get => _enemyHP; set => _enemyHP = value; }
    }
}
