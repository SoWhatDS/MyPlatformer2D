using System;
using UnityEngine;

namespace Platformer2D
{
    public class Quest : IQuest,IDisposable
    {
      
        private readonly QuestObjectView _view;
        private readonly IQuestModel _model;
        private bool _active;
     
       public bool IsCompleted { get;  set; }
       public event Action<IQuest> Completed;

        public Quest(QuestObjectView view,IQuestModel model)
        {
            _view = view;
            _model = model;
        }
  
        private void Complete()
        {
            if (!_active) 
                return;

            _active = false;           
            IsCompleted = true;
            _view.OnLevelObjectContact -= OnContact;
            _view.ProcessComplete();
            OnCompleted();
        }

        private void OnContact(CharacterView characterView)
        {
            var completed = _model.TryComplete(characterView.gameObject);
            if (completed)
                Complete();
        }

        private void OnCompleted()
        {
            Completed?.Invoke(this);
        }

        private void OnContact(LevelObjectView arg1, LevelObjectView arg2)
        {
            var completed = _model.TryComplete(arg2.gameObject);
            if (completed) Complete();
        }

        public void Reset()
        {
            if (_active) 
                return;
            _active = true;
            IsCompleted = false;
            _view.OnLevelObjectContact += OnContact;
            _view.ProcessActivate();
        }
        public void Dispose()
        {
            _view.OnLevelObjectContact -= OnContact;
        }
       
    }
}
