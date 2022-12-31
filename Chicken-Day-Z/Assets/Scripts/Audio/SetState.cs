using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;

public class SetState : MonoBehaviour
{
    [SerializeField] AK.Wwise.State State = new AK.Wwise.State();

    public void ClickButton()
    {
        State.SetValue();
        uint stateID;
        AkSoundEngine.GetState("MyStateGroupName", out stateID);


    }



}
