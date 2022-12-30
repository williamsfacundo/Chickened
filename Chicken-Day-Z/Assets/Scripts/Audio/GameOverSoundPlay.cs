using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AK.Wwise;



public class GameOverSoundPlay : MonoBehaviour
{
    [SerializeField] AK.Wwise.Event Event = new AK.Wwise.Event();



    void Update()
    {
        float ImageSliderValue = gameObject.GetComponent<Image>().fillAmount;
        Debug.Log(ImageSliderValue);

        if (ImageSliderValue <= 0)
        {
            AkSoundEngine.PostEvent("Play_gameOver", gameObject);
        }


    }
}
