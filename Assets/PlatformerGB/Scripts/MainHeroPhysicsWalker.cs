using UnityEngine;

namespace Platformer2D
{
    public class MainHeroPhysicsWalker : MonoBehaviour
    {
        private CharacterView _characterView;
        private SpriteAnimator _spriteAnimator;
        private ContactsPoller _contactsPoller;

        
        public MainHeroPhysicsWalker(CharacterView characterView,SpriteAnimator spriteAnimator)
        {
            _characterView = characterView;
            _spriteAnimator = spriteAnimator;
            _contactsPoller = new ContactsPoller(_characterView.Collider);
        }

        public void FixedUpdate()
        {
            var doJump = Input.GetAxis(ConstantForProject.Vertical) > 0;
            var xAxisInput = Input.GetAxis(ConstantForProject.Horizontal);
            _contactsPoller.Update();
            var isGoSideWay = Mathf.Abs(xAxisInput) > _characterView.MoveTresh;

            if (isGoSideWay)
            {
                _characterView.SpriteRenderer.flipX = xAxisInput < 0;
            }

            var newVelocityX = 0.0f;

            if (isGoSideWay && xAxisInput > 0 || !_contactsPoller.HasLeftContact && xAxisInput < 0 || !_contactsPoller.HasRightContact)
            {
                newVelocityX = Time.fixedDeltaTime * _characterView.WalkSpeed * (xAxisInput < 0 ? -1 : 1);
            }
            else
            {
                newVelocityX = 0.0f;
            }

            _characterView.Rigidbody.velocity = _characterView.Rigidbody.velocity.Change(x: newVelocityX);

            if (_contactsPoller.isGrounded && doJump && Mathf.Abs(_characterView.Rigidbody.velocity.y) <= _characterView.FlyTresh)
            {
                _characterView.Rigidbody.AddForce(Vector2.up * _characterView.JumpSpeed);
            }

            if (_contactsPoller.isGrounded)
            {
                _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, isGoSideWay ? Track.Run : Track.Idle, true, _characterView.AnimationsSpeed);
            }

            else if (_characterView.Rigidbody.velocity.y > _characterView.FlyTresh)
            {
                _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.Jump, true, _characterView.AnimationsSpeed);
            }
        }

        private bool CanMove(float xAxisInput, bool isGoSideWay)
        {            
            return isGoSideWay && xAxisInput > 0 || !_contactsPoller.HasRightContact && xAxisInput < 0 || !_contactsPoller.HasLeftContact;
        }

        private bool CanJump(bool doJump)
        {
            return _contactsPoller.isGrounded && doJump && _characterView.Rigidbody.velocity.y < _characterView.FlyTresh;
        }
    }
}
