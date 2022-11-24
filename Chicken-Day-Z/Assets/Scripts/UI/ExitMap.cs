using UnityEngine;

namespace ChickenDayZ.UI 
{
    public class ExitMap : MonoBehaviour
    {
        [SerializeField] private KeyCode _closeMapKey;

        [SerializeField] private Canvas MapCanvas;

        [SerializeField] private Canvas GameplayCanvas;

        void Update()
        {
            CloseMapInput();                        
        }

        private void CloseMapInput() 
        {
            if (Input.GetKeyDown(_closeMapKey)) 
            {
                CloseMapAction();
            }
        }

        private void CloseMapAction() 
        {
            MapCanvas.gameObject.SetActive(false);

            Time.timeScale = 1f;

            GameplayCanvas.gameObject.SetActive(true);
        }
    }
}