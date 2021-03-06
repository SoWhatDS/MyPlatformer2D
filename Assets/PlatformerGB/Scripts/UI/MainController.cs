using UnityEngine;

namespace Platformer2D
{
    internal class MainController : BaseController
    {
        private readonly Transform _placeForUi;
        private readonly ProfilePlayer _profilePlayer;

        private MainMenuController _mainMenuController;
        private SettingsMenuController _settingsMenuController;
        private GameController _gameController;


        public MainController(Transform placeForUi, ProfilePlayer profilePlayer)
        {        
            _placeForUi = placeForUi;
            _profilePlayer = profilePlayer;

            profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
            OnChangeGameState(_profilePlayer.CurrentState.Value);
        }

        protected override void OnDispose()
        {
            DisposeControllers();
            _profilePlayer.CurrentState.UnSubscribeOnChange(OnChangeGameState);
        }


        private void OnChangeGameState(GameState state)
        {
            DisposeControllers();

            switch (state)
            {
                case GameState.Start:
                    _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                    break;
                case GameState.Settings:
                    _settingsMenuController = new SettingsMenuController(_placeForUi, _profilePlayer);
                    break;
                case GameState.Game:
                    _gameController = new GameController();
                    break;
            }
        }

        private void DisposeControllers()
        {
            _mainMenuController?.Dispose();
            _settingsMenuController?.Dispose();
           // _gameController?.Dispose();
        }
    }
}
