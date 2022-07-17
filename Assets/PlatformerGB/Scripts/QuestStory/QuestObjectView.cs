using System;
using UnityEngine;

namespace Platformer2D
{
    public class QuestObjectView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Color _completeColor;
        [SerializeField] private int _id;

        public int Id  => _id;
        private Color _defaultColor;
        public Action<CharacterView> OnLevelObjectContact;

        private void Awake()
        {
            _defaultColor = _spriteRenderer.color;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var levelObject = collision.gameObject.GetComponent<CharacterView>();
            OnLevelObjectContact?.Invoke(levelObject);
        }

        public void ProcessComplete()
        {
            _spriteRenderer.color = _completeColor;
        }

        public void ProcessActivate()
        {
            _spriteRenderer.color = _defaultColor;
        }
    }
}
