using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AkGameObj))]
public class CoinsCollisionEvents : MonoBehaviour
{
    public AK.Wwise.Event eventoWwise = new AK.Wwise.Event();

    //[SerializeField] private string eventoWwise;

    private void Start()
    {
        /*if (true)
        {
            #if UNITY_EDITOR
                Debug.Log("Si, se cumple la condicion");
            #endif

            AkSoundEngine.PostEvent(eventoWwise, gameObject);
        }*/

        //AkSoundEngine.Post(eventoWwise);
        
        eventoWwise.Post(gameObject);

    }


    private void OnDestroy()
    {
        AkSoundEngine.PostEvent("Stop_EmisorCoins", gameObject);
    }







    //bool sonarAlto = true;
    //bool sonarBajo = true;

    //private void Update()
    //{
    //    if (transform.position.y > 10 && sonarAlto)
    //    {
    //        AkSoundEngine.PostEvent("SonarAlto", gameObject);
    //        //Setea una variable de nombre X y valor falso
    //        sonarAlto = false;
    //        sonarBajo = true;
    //    }

    //    if (transform.position.y < 5 && sonarBajo)
    //    {
    //        AkSoundEngine.PostEvent("SonarBajo", gameObject);
    //        sonarBajo = false;
    //        sonarAlto = true;
    //    }

    //}







}
