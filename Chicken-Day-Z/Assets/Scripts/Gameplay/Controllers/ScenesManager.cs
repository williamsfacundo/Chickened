using UnityEngine;

namespace ChickenDayZ.Gameplay.Controllers 
{
    public class ScenesManager : MonoBehaviour
    {

        [SerializeField] private Canvas _creditsCanvas;

        [SerializeField] private Canvas _gameOverCanvas;

        [SerializeField] private Canvas _mainMenuCanvas;

        [SerializeField] private Canvas _pauseCanvas;

        [SerializeField] private Canvas _settingsCanvas;

        [SerializeField] private Canvas _tutorialCanvas;

        [SerializeField] private Canvas _gameplayCanvas;

        void Awake()
        {
            InitialConfigurations();
        }

        void OnEnable()
        {
            GameplayResetter.OnGameplayReset += GameplayToEndGame;
        }

        void OnDisable()
        {
            GameplayResetter.OnGameplayReset -= GameplayToEndGame;
        }

        public void MainMenuToGameplay() 
        {
            ChangeCanvasState(_mainMenuCanvas, false);
            ChangeCanvasState(_gameplayCanvas, true);

            SetTimeScale(1f);
        }

        public void MainMenuToTutorial()
        {
            ChangeCanvasState(_mainMenuCanvas, false);
            ChangeCanvasState(_tutorialCanvas, true);            
        }

        public void MainMenuToSettings()
        {
            ChangeCanvasState(_mainMenuCanvas, false);
            ChangeCanvasState(_settingsCanvas, true);
        }
        public void MainMenuToCredits()
        {
            ChangeCanvasState(_mainMenuCanvas, false);
            ChangeCanvasState(_creditsCanvas, true);
        }

        public void SettingsToMainMenu()
        {
            ChangeCanvasState(_mainMenuCanvas, true);
            ChangeCanvasState(_settingsCanvas, false);
        }

        public void CreditsToMainMenu()
        {
            ChangeCanvasState(_mainMenuCanvas, true);
            ChangeCanvasState(_creditsCanvas, false);
        }

        public void TutorialToMainMenu()
        {
            ChangeCanvasState(_mainMenuCanvas, true);
            ChangeCanvasState(_tutorialCanvas, false);            
        }

        public void GameplayToEndGame() 
        {
            SetTimeScale(0f);
            ChangeCanvasState(_gameOverCanvas, true);
            ChangeCanvasState(_gameplayCanvas, false);
        }

        public void EndGameToGameplay() 
        {
            SetTimeScale(1f);
            ChangeCanvasState(_gameOverCanvas, false);
            ChangeCanvasState(_gameplayCanvas, true);
        }

        public void EndGameToMainMenu()
        {           
            ChangeCanvasState(_gameOverCanvas, false);
            ChangeCanvasState(_mainMenuCanvas, true);
        }

        public void ChangeFullScreen() 
        {
            Screen.fullScreen = !Screen.fullScreen;            
        }

        public void MainMenuToExit()
        {
            Application.Quit();
        }

        private void InitialConfigurations() 
        {
            ChangeCanvasState(_creditsCanvas, false);
            ChangeCanvasState(_gameOverCanvas, false);
            ChangeCanvasState(_mainMenuCanvas, true);
            ChangeCanvasState(_pauseCanvas, false);
            ChangeCanvasState(_settingsCanvas, false);
            ChangeCanvasState(_tutorialCanvas, false);
            ChangeCanvasState(_gameplayCanvas, false);

            Screen.fullScreen = true;

            SetTimeScale(0f);
        }

        private void ChangeCanvasState(Canvas canvas, bool isOn) 
        {
            canvas.gameObject.SetActive(isOn);
        }

        private void SetTimeScale(float value) 
        {
            Time.timeScale = value;
        }
    }
}