using UnityEngine;

namespace Platformer2D
{

    internal sealed class Root : MonoBehaviour
    {

        [SerializeField] private GameState _initialState = GameState.Start;
        [SerializeField] private Transform _placeForUi;
        private MainController _mainController;
    
        private void Start()
        {           
            var profilePlayer = new ProfilePlayer(10,_initialState);
            _mainController = new MainController(_placeForUi, profilePlayer);
          
        }

        private void OnDestroy()
        {
            _mainController.Dispose();
        }
    }
}

