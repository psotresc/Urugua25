using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int cantidad = 10;
    void Start()
    {
        FloatingTextController.Initialize();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FloatingTextController.CreateFloatingText(cantidad.ToString(), transform);
            //TakeDamage(Random.Range(0, 100));
        }
    }
    public void TakeDamage(int amount)
    {
       
        Debug.LogFormat("{0} was dealt {1} damage", gameObject.name, amount);
    }
}
