using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AK.Wwise;

public class ResetHealthParameters : MonoBehaviour
{
    [SerializeField] AK.Wwise.Event Event = new AK.Wwise.Event();

    public void ResetHealthParameters_FunctionWhenClicked()
    {
        Event.Post(gameObject);
    #if DEBUG
        Debug.Log("se esta llamando al evento " + Event);
    #endif
    }


}
