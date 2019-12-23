using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject trackObject;
    public Vector3 offset;
    Camera Cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = trackObject.transform.position + offset;    
        //gameObject.transform.position = Vector3(0,0,0);
    }
}
