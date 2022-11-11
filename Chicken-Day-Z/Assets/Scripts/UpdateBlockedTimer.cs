using UnityEngine;
using TMPro;

using ChickenDayZ.Gameplay.MainObjects.PowerUp;

public class UpdateBlockedTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text _blockedTimerText;

    private PowerUpObject _powerUpObject;

    void Awake()
    {
        _powerUpObject = GetComponent<PowerUpObject>();        
    }

    void Start()
    {
        _powerUpObject.OnBlockedChestTimerChanged += UpdateBlockedTimerText;
    }

    void OnDestroy()
    {
        _powerUpObject.OnBlockedChestTimerChanged -= UpdateBlockedTimerText;
    }

    private void UpdateBlockedTimerText() 
    {
        if (_powerUpObject.GetBlockedChestTimerCountDown() <= 0f)        
        {
            _blockedTimerText.text = " ";
        }
        else 
        {
            _blockedTimerText.text = (int)_powerUpObject.GetBlockedChestTimerCountDown() + "";
        }
    }
}
