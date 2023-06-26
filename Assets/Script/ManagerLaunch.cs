using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerLaunch : MonoBehaviour
{

    private float forceMagnitude;
    public Rigidbody myRb;
    [Space]
    public Transform guideBall;
    public float speedRotation;
    private float frameRotation;
    [Space]
    public GameObject UIForce;
    public Image forceImage;
    private float forcePercentage;
    public float forceMax;

    private bool OnRotation = true;
    private bool OnForceLoad = true;
    private bool OnLaunch = false;

    public delegate void DelStartLaunchTimeHandle();
    public static event DelStartLaunchTimeHandle OnEventLaunch;

    void Start()
    {
        guideBall.gameObject.SetActive(true);
        UIForce.gameObject.SetActive(false);

        ManagerScene.OnEventRestart += RestarManager;


    }


    void Update()
    {
        if (OnRotation) RotateBall();

        if (OnForceLoad) ForceLoadUI();

        if (OnLaunch) LaunchBall();

    }


    public void RotateBall()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            frameRotation -= speedRotation * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            frameRotation += speedRotation * Time.deltaTime;
        }

        guideBall.transform.rotation = Quaternion.Euler(0, frameRotation, 0);
    }


    public void ForceLoadUI()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            OnRotation = false;
            guideBall.gameObject.SetActive(false);
            UIForce.gameObject.SetActive(true);
            OnLaunch = true;

            forceImage.fillAmount += Time.deltaTime * 0.3f;
        }
    }


    public void LaunchBall()
    {

        if (Input.GetKeyUp(KeyCode.Space))
        {
            OnForceLoad = false;

            forcePercentage = forceImage.fillAmount;


            if (forcePercentage >= 1)
            {
                forceMagnitude = Random.Range(0f,1f) * forceMax;
            }
            else
            {
                forceMagnitude = forcePercentage * forceMax;
            }

            Vector3 force = guideBall.forward;
            force *= forceMagnitude;

            myRb.AddForce(force,ForceMode.Impulse);

            OnEventLaunch.Invoke();
            OnLaunch = false;
            
        }
    }

    public void RestarManager()
    {
        guideBall.gameObject.SetActive(true);
        UIForce.gameObject.SetActive(false);
        OnRotation = true;
        OnForceLoad = true;
        forceImage.fillAmount = 0;
        frameRotation = 0;

        myRb.velocity = Vector3.zero;
    }

}
