using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    [CreateAssetMenu(fileName = nameof(QuestItemsConfig),menuName = "Quests/QuestItemsConfig")]
    public class QuestItemsConfig : ScriptableObject
    {
        [SerializeField] private int _questId;
        [SerializeField] List<int> _questItemIdCollection;

        public int QuestId => _questId;
        public List<int> QuestItemIdCollection => _questItemIdCollection;
    }
}
