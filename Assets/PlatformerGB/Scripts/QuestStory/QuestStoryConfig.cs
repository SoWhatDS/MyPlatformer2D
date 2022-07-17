using UnityEngine;

namespace Platformer2D
{
    [CreateAssetMenu(fileName = nameof(QuestStoryConfig), menuName = "Quests/QuestStoryConfig")]
    public class QuestStoryConfig : ScriptableObject
    {
        [SerializeField] private QuestConfig[] _quests;
        [SerializeField] private QuestStorytype _questStoryType;

        public QuestConfig[] Quests => _quests;
        public QuestStorytype QuestStoryType => _questStoryType;
    }

    public enum QuestStorytype
    { 
        Common,
        Resettable
    }
}
