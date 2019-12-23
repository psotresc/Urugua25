using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public Animator anim;

    //Variables movimiento
    private float movimiento = 1.77f;
    public float izqMax;
    public float derMax;
    private float speed = 100;
    private Vector2 targetPos;

    //Variables puntos
    private float timeAnim;
    private float startAnim;

    int damage = 25;
    private int puntos = 25;
    public int aumentoSpe = 50;

    public float aumento = .05f;

    

    void Start()
    {

        targetPos = new Vector2(0.0f, -4.0f);
        FloatingTextController.Initialize();
        CorazonInstanceCont.Initialize();
        
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (BotonesJuego.butIzq && transform.position.x > izqMax)
        {
            targetPos = new Vector2(transform.position.x - movimiento, transform.position.y);
        }
        else if (BotonesJuego.butDer && transform.position.x < derMax)
        {
            targetPos = new Vector2(transform.position.x + movimiento, transform.position.y);
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Extra"))
        {

            GameControlScript.puntos += puntos;
            if (HealthBarScript.agarrado)
            {
                HealthBarScript.health += aumento;
            }
            FloatingTextController.CreateFloatingText("+25", transform);
            anim.Play("Move");
        }

        if (other.CompareTag("Enemy"))
        {

            GameControlScript.health -= 1;
            GameControlScript.puntos -= damage;

            GameControlScript.visibilidad = false;
            HealthBarScript.resetBar = true;
            HealthBarScript.agarrado = false;
            FloatingTextController.CreateFloatingText("-25", transform);
            CorazonInstanceCont.CreateCorazon(transform);
            anim.Play("Obstaculo");
            
        }

        if (other.CompareTag("Special"))
        {
            HealthBarScript.agarrado = true;
            GameControlScript.puntos += aumentoSpe;
            FloatingTextController.CreateFloatingText("+50", transform);
            GameControlScript.visibilidad = true;
            anim.Play("Special");
        }

    }
}


