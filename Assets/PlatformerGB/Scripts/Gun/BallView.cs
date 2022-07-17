using UnityEngine;

namespace Platformer2D
{
    public class BallView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _bulletSpriterenderer;
        [SerializeField] private Transform _bulletTransform;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private Rigidbody2D _rigidbody;

        public SpriteRenderer BulletSpriterenderer  => _bulletSpriterenderer;

        public Transform BulletTransform  => _bulletTransform;

        public Collider2D Collider  => _collider;

        public Rigidbody2D Rigidbody  => _rigidbody;

        // public TrailRenderer Trail  => _trail; 

        public void SetVisible(bool visible)
        {
            _bulletSpriterenderer.enabled = visible;
        }
    }
}
