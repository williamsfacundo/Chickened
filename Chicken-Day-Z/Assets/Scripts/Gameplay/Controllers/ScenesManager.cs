using System;
using UnityEngine;
using TMPro;

using ChickenDayZ.Gameplay.MainObjects.Characters;

namespace ChickenDayZ.Gameplay.Controllers 
{
    public class ScenesManager : MonoBehaviour
    {
        [SerializeField] private Canvas _creditsCanvas1;

        [SerializeField] private Canvas _creditsCanvas2;

        [SerializeField] private Canvas _creditsCanvas3;

        [SerializeField] private Canvas _gameOverCanvas;

        [SerializeField] private Canvas _mainMenuCanvas;

        [SerializeField] private Canvas _pauseCanvas;

        [SerializeField] private Canvas _settingsCanvas;

        [SerializeField] private Canvas _tutorialCanvas1;

        [SerializeField] private Canvas _tutorialCanvas2;

        [SerializeField] private Canvas _tutorialCanvas3;

        [SerializeField] private Canvas _gameplayCanvas;

        [SerializeField] private TMP_Text _scoreText;

        [SerializeField] private Canvas _mapCanvas;
        
        [SerializeField] private KeyCode _pauseKey;

        [SerializeField] private KeyCode _openMapKey;

        public static Action OnGameplayToEndGame;

        private ChickenObject chicken;

        void Awake()
        {
            InitialConfigurations();

            chicken = FindObjectOfType<ChickenObject>();
        }

        void OnEnable()
        {
            GameplayResetter.OnGameplayReset += GameplayToEndGame;
        }

        void OnDisable()
        {
            GameplayResetter.OnGameplayReset -= GameplayToEndGame;
        }

        void Update()
        {
            PauseGame();

            OpenCloseMap();
        }

        public void MainMenuToTutorial3() 
        {
            ChangeCanvasState(_mainMenuCanvas, false);
            ChangeCanvasState(_tutorialCanvas3, true);

        }

        public void GameplayToMap() 
        {
            ChangeCanvasState(_mapCanvas, true);
            ChangeCanvasState(_gameplayCanvas, false);

            SetTimeScale(0f);
        }

        public void MapToGameplay()
        {
            ChangeCanvasState(_mapCanvas, false);
            ChangeCanvasState(_gameplayCanvas, true);            
            
            SetTimeScale(1f);
        }        

        public void MainMenuToTutorial()
        {
            ChangeCanvasState(_mainMenuCanvas, false);
            ChangeCanvasState(_tutorialCanvas1, true);            
        }

        public void Tutorial3ToGameplay() 
        {
            ChangeCanvasState(_tutorialCanvas3, false);
            ChangeCanvasState(_gameplayCanvas, true);

            SetTimeScale(1f);
        }

        public void MainMenuToSettings()
        {
            ChangeCanvasState(_mainMenuCanvas, false);
            ChangeCanvasState(_settingsCanvas, true);
        }
        public void MainMenuToCredits1()
        {
            ChangeCanvasState(_mainMenuCanvas, false);
            ChangeCanvasState(_creditsCanvas1, true);
        }

        public void SettingsToMainMenu()
        {
            ChangeCanvasState(_mainMenuCanvas, true);
            ChangeCanvasState(_settingsCanvas, false);
        }

        public void Credits1ToMainMenu()
        {
            ChangeCanvasState(_mainMenuCanvas, true);
            ChangeCanvasState(_creditsCanvas1, false);
        }

        public void Credits2ToMainMenu()
        {
            ChangeCanvasState(_mainMenuCanvas, true);
            ChangeCanvasState(_creditsCanvas2, false);
        }

        public void Credits3ToMainMenu()
        {
            ChangeCanvasState(_mainMenuCanvas, true);
            ChangeCanvasState(_creditsCanvas3, false);
        }

        public void Credits1ToCredits2()
        {
            ChangeCanvasState(_creditsCanvas2, true);
            ChangeCanvasState(_creditsCanvas1, false);
        }

        public void Credits2ToCredits3()
        {
            ChangeCanvasState(_creditsCanvas3, true);
            ChangeCanvasState(_creditsCanvas2, false);
        }

        public void Credits2ToCredits1()
        {
            ChangeCanvasState(_creditsCanvas1, true);
            ChangeCanvasState(_creditsCanvas2, false);
        }

        public void Credits3ToCredits2()
        {
            ChangeCanvasState(_creditsCanvas2, true);
            ChangeCanvasState(_creditsCanvas3, false);
        }

        public void TutorialToMainMenu()
        {
            ChangeCanvasState(_mainMenuCanvas, true);
            ChangeCanvasState(_tutorialCanvas1, false);            
        }

        public void Tutorial1ToTutorial2()
        {
            ChangeCanvasState(_tutorialCanvas1, false);
            ChangeCanvasState(_tutorialCanvas2, true);
        }

        public void Tutorial2ToTutorial1()
        {
            ChangeCanvasState(_tutorialCanvas2, false);
            ChangeCanvasState(_tutorialCanvas1, true);
        }

        public void Tutorial2ToMainMenu()
        {
            ChangeCanvasState(_tutorialCanvas2, false);
            ChangeCanvasState(_mainMenuCanvas, true);
        }

        public void GameplayToEndGame() 
        {
            SetTimeScale(0f);
            ChangeCanvasState(_gameOverCanvas, true);
            ChangeCanvasState(_gameplayCanvas, false);

            OnGameplayToEndGame?.Invoke();

            _scoreText.text = chicken.ChickenScore.Score.ToString();

            chicken.ChickenScore.ResetScore();
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

        public void GameplayToPause()
        {
            SetTimeScale(0f);
            ChangeCanvasState(_pauseCanvas, true);
            ChangeCanvasState(_gameplayCanvas, false);
        }

        public void PauseToGameplay()
        {
            SetTimeScale(1f);
            ChangeCanvasState(_pauseCanvas, false);
            ChangeCanvasState(_gameplayCanvas, true);
        }

        public void PauseToGameplayWithRestart()
        {
            SetTimeScale(1f);

            GameplayResetter.OnGameplayReset -= GameplayToEndGame;

            GameplayResetter.ResetGameplay();

            GameplayResetter.OnGameplayReset += GameplayToEndGame;

            ChangeCanvasState(_pauseCanvas, false);
            ChangeCanvasState(_gameplayCanvas, true);

            chicken.ChickenScore.ResetScore();
        }

        public void PauseToMainMenu()
        {
            GameplayResetter.OnGameplayReset -= GameplayToEndGame;

            GameplayResetter.ResetGameplay();

            GameplayResetter.OnGameplayReset += GameplayToEndGame;

            ChangeCanvasState(_pauseCanvas, false);
            ChangeCanvasState(_mainMenuCanvas, true);

            chicken.ChickenScore.ResetScore();
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
            ChangeCanvasState(_creditsCanvas1, false);
            ChangeCanvasState(_creditsCanvas2, false);
            ChangeCanvasState(_creditsCanvas3, false);
            ChangeCanvasState(_gameOverCanvas, false);
            ChangeCanvasState(_mainMenuCanvas, true);
            ChangeCanvasState(_pauseCanvas, false);
            ChangeCanvasState(_settingsCanvas, false);
            ChangeCanvasState(_tutorialCanvas1, false);
            ChangeCanvasState(_tutorialCanvas2, false);
            ChangeCanvasState(_tutorialCanvas3, false);
            ChangeCanvasState(_gameplayCanvas, false);
            ChangeCanvasState(_mapCanvas, false);

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

        private void PauseGame() 
        {
            if (Input.GetKeyDown(_pauseKey) && _gameplayCanvas.gameObject.activeSelf) 
            {
                GameplayToPause();
            }
        }     

        private void OpenCloseMap() 
        {
            if (Input.GetKeyDown(_openMapKey) && _gameplayCanvas.gameObject.activeSelf) 
            {
                if (!_mapCanvas.gameObject.activeSelf) 
                {
                    GameplayToMap();
                }
            }
        }
    }
}