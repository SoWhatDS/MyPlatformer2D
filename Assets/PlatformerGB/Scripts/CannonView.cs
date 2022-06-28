using UnityEngine;

namespace Platformer2D
{
    public class CannonView : MonoBehaviour
    {
        [SerializeField]
        private Transform _muzzleTransform;

        public Transform MuzzleTransform => _muzzleTransform;
    }
}
