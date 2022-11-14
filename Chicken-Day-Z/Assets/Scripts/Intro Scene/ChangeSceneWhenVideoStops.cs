using UnityEngine;

using UnityEngine.SceneManagement;

using ChickenDayZ.General;

public class ChangeSceneWhenVideoStops : MonoBehaviour
{
    private Timer _timer;

    void Start()
    {
        _timer = new Timer(56f);        
    }

    void Update()
    {
        _timer.DecreaseTimer();

        if (_timer.TimerFinished) 
        {
            ChangeSceneToGameplay();
        }
    }

    public void ChangeSceneToGameplay() 
    {
        SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
    }
}
