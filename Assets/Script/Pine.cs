using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pine : MonoBehaviour
{

    public int score;
    public Transform positionParicle;
    public GameObject particle;

    public delegate void DelPineScoreHandle(int score);
    public static event DelPineScoreHandle OnEventPine;
    
    void Start()
    {
        
    }


    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 10)
        {
            OnEventPine.Invoke(score);

            Instantiate(particle, positionParicle.position, positionParicle.rotation);
            Destroy(this.gameObject);
        }

    }
     
}
