using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AK.Wwise;

public class SetRTPC : MonoBehaviour

{
    [SerializeField] AK.Wwise.RTPC RTPCToBeChanged = new AK.Wwise.RTPC();


    public void ValueChanged()
    {

        float SliderValue = gameObject.GetComponent<Slider>().value;

        RTPCToBeChanged.SetGlobalValue(SliderValue);
    }
}