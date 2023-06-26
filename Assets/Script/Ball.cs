using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Transform initialPositionBall;

    void Start()
    {
        ManagerScene.OnEventRestart += ResetPosition;
    }


    void Update()
    {
  
    }

    public void ResetPosition()
    {
        this.transform.position = initialPositionBall.position;
    }



}
