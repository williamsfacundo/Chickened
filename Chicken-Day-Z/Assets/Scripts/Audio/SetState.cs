using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetState : MonoBehaviour
{
    [SerializeField] AK.Wwise.State State = new AK.Wwise.State();

    public void ClickButton()
    {
        State.SetValue();
    }
}
