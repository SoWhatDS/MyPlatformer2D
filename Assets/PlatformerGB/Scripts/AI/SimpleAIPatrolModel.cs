using UnityEngine;

namespace Platformer2D
{
    public class SimpleAIPatrolModel
    {
        private AIConfig _config;

        private Transform _target;

        private int _currentPoint;
        
        public SimpleAIPatrolModel(AIConfig config)
        {
            _config = config;
            _target = GetNextWayPoint();
            _config.IsPatrol = true;
        }

        private Transform GetNextWayPoint()
        {
            _currentPoint = (_currentPoint + 1) % _config.WayPoints.Length;
            return _config.WayPoints[_currentPoint];
        }

        public Vector2 CalculateVelocity(Vector2 fromPosition, Transform targetPlayer,EnemyView enemyView)
        {
            var distance = Vector2.Distance(_target.position, fromPosition);
            var distanceToPlayer = Vector2.Distance(fromPosition, targetPlayer.position);
            if (distance <= _config.MinDistanceToTarget && _config.IsPatrol == true)
            {
                _target = GetNextWayPoint();
               
            }
            else if (distanceToPlayer < 3)
            {
                _target = targetPlayer;
                _config.IsPatrol = false;
            }
            else if (distanceToPlayer >= 5 && _config.IsPatrol == false)
            {
                _config.IsPatrol = true;
                _target = GetNextWayPoint();               
            }
            var direction = ((Vector2)_target.position - fromPosition).normalized;

            if (direction.x > 0)
            {
                enemyView.SpriteRendererEnemy.flipX = true;
            }
            else
            {
                enemyView.SpriteRendererEnemy.flipX = false;
            }
            return _config.Speed * direction;
        }


    }
}
