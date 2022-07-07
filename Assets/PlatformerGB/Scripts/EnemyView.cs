using UnityEngine;

namespace Platformer2D
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Transform _targetPlayer;

        public Rigidbody2D Rigidbody  => _rigidbody;

        public Transform TargetPlayer => _targetPlayer; 
    }
}
