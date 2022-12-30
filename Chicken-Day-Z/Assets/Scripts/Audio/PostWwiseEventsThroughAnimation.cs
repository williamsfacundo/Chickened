using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostWwiseEventsThroughAnimation : MonoBehaviour
{
    private void CallWwiseEvent(string value)
    {
    #if DEBUG
        Debug.Log("se esta llamando al evento " + value);
    #endif
        AkSoundEngine.PostEvent(value, gameObject);

    }
}
