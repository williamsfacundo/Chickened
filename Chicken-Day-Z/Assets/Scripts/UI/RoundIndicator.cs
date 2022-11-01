using UnityEngine;
using TMPro;

using ChickenDayZ.Gameplay.Characters.Zombie;

namespace ChickenDayZ.UI 
{
    public class RoundIndicator : MonoBehaviour
    {
        /*[SerializeField] private TMP_Text _showRoundText;

        private ZombiesSpawner _zombiesSpawner;

        private void Awake()
        {
            _zombiesSpawner = FindObjectOfType<ZombiesSpawner>();

            if (_zombiesSpawner == null) 
            {
                Debug.LogError("Zombie spawner couldnt be found!");
            }
        }

        void Start()
        {
            UpdateRoundText();
        }

        void OnEnable()
        {
            _zombiesSpawner.OnRoundChanged += UpdateRoundText;
        }

        void OnDisable()
        {
            _zombiesSpawner.OnRoundChanged -= UpdateRoundText;
        }

        private void UpdateRoundText() 
        {
            _showRoundText.text = "Round " + _zombiesSpawner.Round;
        }*/
    }
}