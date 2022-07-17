using UnityEngine;

namespace Platformer2D
{
    [CreateAssetMenu(fileName = nameof(QuestConfig), menuName = "Quests/QuestConfig")]
    public class QuestConfig : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private QuestType _questType;

        public QuestType QuestType  => _questType; 
        public int Id  => _id; 
    }

    public enum QuestType
    {
        Switch
    }
}
