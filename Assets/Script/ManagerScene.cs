using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScene : MonoBehaviour
{

    private float time = 0;
    private bool onRestartScene = false;

    public delegate void DelRestartSceneHandle();
    public static event DelRestartSceneHandle OnEventRestart;




    // Start is called before the first frame update
    void Start()
    {
        ManagerLaunch.OnEventLaunch += StartCount;


    }

    // Update is called once per frame
    void Update()
    {
        if (onRestartScene)
        {
            time += Time.deltaTime;
         
            if (time > 5)
            {
                OnEventRestart.Invoke();
                time = 0;
                onRestartScene = false;
            }
        }


    }

    private void StartCount()
    {
        onRestartScene = true;
    }



}
