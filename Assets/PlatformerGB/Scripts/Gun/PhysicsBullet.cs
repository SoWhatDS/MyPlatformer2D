using UnityEngine;

namespace Platformer2D
{
    public class PhysicsBullet 
    {
        private BallView _viewBullet;

        public PhysicsBullet(BallView bulletView)
        {
            _viewBullet = bulletView;
            _viewBullet.SetVisible(false);
        }

        public void Throw(Vector3 position, Vector3 velocity)
        {
            _viewBullet.SetVisible(false);
            _viewBullet.BulletTransform.position = position;
            _viewBullet.Rigidbody.velocity = Vector2.zero;
            _viewBullet.Rigidbody.angularVelocity = 0;
            _viewBullet.Rigidbody.AddForce(velocity, ForceMode2D.Impulse);
            _viewBullet.SetVisible(true);
        }
    }
}
