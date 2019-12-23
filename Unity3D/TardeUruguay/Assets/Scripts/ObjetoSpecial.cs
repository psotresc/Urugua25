using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoSpecial : MonoBehaviour
{
    public float speed = 2;
    public static bool agarrado = false;

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);

        }
    }
}
