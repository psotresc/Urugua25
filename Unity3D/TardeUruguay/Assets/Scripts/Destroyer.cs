using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private float lifetime = 9; 

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
