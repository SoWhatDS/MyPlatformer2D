using UnityEngine;

namespace Platformer2D
{
    public class ContactsPoller : MonoBehaviour
    {
        private const float _contactsTresh = 0.1f;

        private ContactPoint2D[] _contacts = new ContactPoint2D[10];        
        private Collider2D _collider;

        public bool isGrounded { get; private set;}
        public bool HasLeftContact { get; private set; }
        public bool HasRightContact { get; private set; }

        public ContactsPoller(Collider2D collider)
        {
            _collider = collider;
        }

        public void Update()
        {
            isGrounded = false;
            HasLeftContact = false;
            HasRightContact = false;

            var contactsPoint = _collider.GetContacts(_contacts);

            for (int i = 0; i < contactsPoint; i++)
            {
                var normal = _contacts[i].normal;
                var rigidbody = _contacts[i].rigidbody;

                if (normal.y > _contactsTresh)
                {
                    isGrounded = true;
                }
                if (normal.x > _contactsTresh && rigidbody == null)
                {
                    HasLeftContact = true;
                }
                if (normal.x < -_contactsTresh && rigidbody == null)
                {
                    HasRightContact = true;
                }
            }
            

        }
    }
}
