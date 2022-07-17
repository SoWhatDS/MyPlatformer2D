using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Platformer2D
{
    public class MainMenuView : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button _buttonStart;
        [SerializeField] private Button _buttonSettings;


        public void Init(UnityAction startGame, UnityAction openSettings)
        {
            _buttonStart.onClick.AddListener(startGame);
            _buttonSettings.onClick.AddListener(openSettings);
        }

        public void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonSettings.onClick.RemoveAllListeners();
        }
    }
}
