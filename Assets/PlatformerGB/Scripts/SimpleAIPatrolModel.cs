using UnityEngine;

namespace Platformer2D
{
    public class SimpleAIPatrolModel 
    {
        private readonly AIConfig _config;

        private Transform _target;

        private int _currentPoint;       

        public SimpleAIPatrolModel(AIConfig config)
        {
            _config = config;
            _target = GetNextWayPoint();
        }

        private Transform GetNextWayPoint()
        {
            _currentPoint = (_currentPoint + 1) % _config.WayPoints.Length;
            return _config.WayPoints[_currentPoint];
        }

        public Vector2 CalculateVelocity(Vector2 fromPosition,Transform targetPlayer)
        {
            var distance = Vector2.Distance(_target.position, fromPosition);
            var distanceToPlayer = Vector2.Distance(fromPosition, targetPlayer.position);
            if (distance <= _config.MinDistanceToTarget && distanceToPlayer > 1)
            {
                _target = GetNextWayPoint();
            }
            else if (distanceToPlayer < 1)
            {
                _target = targetPlayer;
            }
            var direction = ((Vector2)_target.position - fromPosition).normalized;

            return _config.Speed * direction;
        }
    }
}
