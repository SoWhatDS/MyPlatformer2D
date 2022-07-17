using UnityEngine;

namespace Platformer2D
{
    public class SwitchQuestModel : IQuestModel
    {
        public bool TryComplete(GameObject activator)
        {
            return activator.GetComponent<CharacterView>();
        }
       
    }
}
