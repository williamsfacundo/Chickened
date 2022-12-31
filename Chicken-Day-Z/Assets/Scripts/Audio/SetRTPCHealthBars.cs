using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AK.Wwise;

public class SetRTPCHealthBars : MonoBehaviour
{
    [SerializeField] AK.Wwise.RTPC RTPCToBeChanged = new AK.Wwise.RTPC();

    void Update()
    {
        float ImageSliderValue = gameObject.GetComponent<Image>().fillAmount;

        RTPCToBeChanged.SetGlobalValue(ImageSliderValue);
    #if DEBUG
        Debug.Log("se esta seteando el RTPC en: " + ImageSliderValue);
    #endif
      
    }
}
