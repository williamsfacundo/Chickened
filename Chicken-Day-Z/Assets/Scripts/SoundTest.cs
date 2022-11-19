using UnityEngine;

public class SoundTest : MonoBehaviour
{
    public string EventName;

    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent(EventName, gameObject);        
    }    
}
