using UnityEngine;
using System;

namespace Platformer2D
{
    [Serializable]
    public struct AIConfig 
    {
        public float Speed;
        public float MinDistanceToTarget;
        public Transform[] WayPoints;
    }
}
