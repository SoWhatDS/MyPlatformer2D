using UnityEngine;

namespace Platformer2D
{
    public class SimpleAIPatrol : MonoBehaviour
    {
        private readonly EnemyView _enemyView;
        private readonly SimpleAIPatrolModel _patrolModel;
        public SimpleAIPatrol(EnemyView enemyView,SimpleAIPatrolModel patrolModel)
        {
            _enemyView = enemyView;
            _patrolModel = patrolModel;
        }

        public void FixedUpdate()
        {
            _enemyView.Rigidbody.velocity = _patrolModel.CalculateVelocity(_enemyView.transform.position,_enemyView.TargetPlayer)*Time.fixedDeltaTime;
        }
    }
}
