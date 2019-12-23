using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movCam : MonoBehaviour
{
    //private  float moviCam = 1.77f;
    private Vector3 targetMovCam;
    private float speed = 1000;

    public static int nivel; 
    // Start is called before the first frame update
    void Start()
    {
        targetMovCam = new Vector3(0.0f, 0.0f,-10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetMovCam, speed * Time.deltaTime);

        switch (nivel)
        {
            case 4:
                targetMovCam = new Vector3(11.51f, transform.position.y, transform.position.z);
                break;
            case 3:
                targetMovCam = new Vector3(5.64f, transform.position.y, transform.position.z);
                break;
            case 2:
                targetMovCam = new Vector3(0f, transform.position.y, transform.position.z);
                break;
            case 1:
                targetMovCam = new Vector3(-5.64f, transform.position.y, transform.position.z);
                break;

        }
        //if (nivel ==1)
        //{
        //    targetMovCam = new Vector3(-5.64f, transform.position.y, transform.position.z);
        //}
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    targetMovCam = new Vector3(5.64f, transform.position.y, transform.position.z);
        //}
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    targetMovCam = new Vector3(0f, transform.position.y, transform.position.z);
        //}
    }
}
