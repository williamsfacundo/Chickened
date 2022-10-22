using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testStopMenuMusic : MonoBehaviour
{
    
   


    public void stopBGM()
    {
        AkSoundEngine.PostEvent("Stop_mainMenuBGM", gameObject);
    }



}
