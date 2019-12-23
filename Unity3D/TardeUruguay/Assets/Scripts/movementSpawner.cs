using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementSpawner : MonoBehaviour
{

    public float maxPos = 2f;
    public float minPos = -2f;
    public float speed ;

    private bool dirRight = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dirRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

        }
        else
        {
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }

        if (transform.position.x >= maxPos)
        {
            dirRight = false;
        }

        if (transform.position.x <= minPos)
        {
            dirRight = true;
        }
    }
}
