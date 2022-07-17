using UnityEngine;

namespace Platformer2D
{
    public class SimpleAIPatrol 
    {
        private readonly EnemyView _enemyView;
        private readonly SimpleAIPatrolModel _patrolModel;
        private SpriteAnimator _spriteAnimatorEnemy;
      
        public SimpleAIPatrol(EnemyView enemyView, SimpleAIPatrolModel patrolModel, SpriteAnimator spriteAnimatorEnemy)
        {
            _enemyView = enemyView;
            _patrolModel = patrolModel;
            _spriteAnimatorEnemy = spriteAnimatorEnemy;
            
        }

        public void FixedUpdate()
        {            
            _enemyView.Rigidbody.velocity = _patrolModel.CalculateVelocity(_enemyView.transform.position, _enemyView.TargetPlayer,_enemyView) *Time.fixedDeltaTime;

            var distanceToPlayer = Vector2.Distance(_enemyView.transform.position, _enemyView.TargetPlayer.position);
            if (distanceToPlayer > 3)
            {
                _spriteAnimatorEnemy.StartAnimation(_enemyView.SpriteRendererEnemy, Track.Run, true, _enemyView.AnimSpeedEnemy, true);
            }
            else if (distanceToPlayer < 1)
            {
                _spriteAnimatorEnemy.StartAnimation(_enemyView.SpriteRendererEnemy, Track.Attack1, true, _enemyView.AnimSpeedEnemy, true);
            }
        }
       

}
}
