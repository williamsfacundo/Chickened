using UnityEngine;

namespace ChickenDayZ.GameplayItems 
{
    public class ExitGameKey : MonoBehaviour
    {
        private const KeyCode _exitKey = KeyCode.Escape;

        void Update()
        {
            ExitGameWhenExitButtonPressed();
        }

        private void ExitGameWhenExitButtonPressed()
        {
            if (Input.GetKeyDown(_exitKey))
            {
                Application.Quit();
            }
        }
    }
}