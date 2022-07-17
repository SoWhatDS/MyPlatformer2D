using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    internal class GameController : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private SpriteRenderer _backGround;
        [SerializeField] private SpriteAnimationConfig _spriteAnimationConfig;
        [SerializeField] private SpriteAnimationConfig _spriteAnimationConfigEnemy;
        [SerializeField] private CharacterView _characterView;
        [SerializeField] private MoveBackGround _backGroundMove;
        [SerializeField] private CannonView _cannonView;
        [SerializeField] private List<BallView> _bulletsPhysics;
        [SerializeField] private List<LevelObjectView> _coins;
        [SerializeField] private List<LevelObjectView> _deathZone;
        [SerializeField] private List<LevelObjectView> _winZones;
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private AIConfig _AIConfig;

        private SpriteAnimator _spriteAnimator;
        private SpriteAnimator _spriteAnimatorEnemy;
        private MainHeroPhysicsWalker _mainHeroPhysicsWalker;
        private AimingMuzzle _aimingMuzle;
        private BulletsPhysicsEmitter _bulletsPhysicsEmitter;

        private ParalaxManager _paralaxManager;
        private CoinsManager _coinManager;
        private LevelCompleteManager _levelCompleteManager;

        private SimpleAIPatrol _patrolAI;
        private SimpleAIPatrolModel _simpleAIPatrolModel;    

        private void Start()
        {
            _paralaxManager = new ParalaxManager(_mainCamera, _backGround.transform);
            _spriteAnimator = new SpriteAnimator(_spriteAnimationConfig);
            _spriteAnimatorEnemy = new SpriteAnimator(_spriteAnimationConfigEnemy);
            _mainHeroPhysicsWalker = new MainHeroPhysicsWalker(_characterView, _spriteAnimator, _enemyView);
            _backGroundMove = new MoveBackGround(_backGround.transform);
            _aimingMuzle = new AimingMuzzle(_cannonView.transform, _characterView.transform);
            _bulletsPhysicsEmitter = new BulletsPhysicsEmitter(_bulletsPhysics, _cannonView.MuzzleTransform);
            _coinManager = new CoinsManager(_characterView.GetComponent<LevelObjectView>(), _coins, _spriteAnimator);
            _levelCompleteManager = new LevelCompleteManager(_characterView.GetComponent<LevelObjectView>(), _deathZone, _winZones);
            _simpleAIPatrolModel = new SimpleAIPatrolModel(_AIConfig);
            _patrolAI = new SimpleAIPatrol(_enemyView, _simpleAIPatrolModel, _spriteAnimatorEnemy);
        }

        private void Update()
        {
            
                _paralaxManager.Update();
                _spriteAnimator.Update();
                _backGroundMove.Update();
                _aimingMuzle.Update();
                _bulletsPhysicsEmitter.Update();
                _spriteAnimatorEnemy.Update();            

        }

        private void FixedUpdate()
        {        
                _mainHeroPhysicsWalker.FixedUpdate();
                _patrolAI.FixedUpdate();            
        }

    }

}
