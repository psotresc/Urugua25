using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objeto2Script : MonoBehaviour
{
    //private int puntos = 50;
    public float speed;
    public GameObject objeto2;
    public GameObject incoming;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;

    private static int numContador;
    private static int numAntContador;

    private bool primeraCaida = true;
    void Start()
    {

    }
    void Update()
    {
        //Debug.Log(API.numero);
        //CONTROL MANUAL
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    Instantiate(objeto1, transform.position, Quaternion.identity);
        //    Instantiate(incoming, new Vector3(-1.05f, 0f, 0), transform.rotation);
        //}

        // Borrar la primera caida 
        if (API.numero2 != 0 && primeraCaida == true)
        {
            numContador = API.numero2;
            numAntContador = API.numero2;
            primeraCaida = false;
        }

        //Control API
        if (numContador != numAntContador && GameControlScript.comenzo == true && primeraCaida == false)
        {
            if (timeBtwSpawn <= 0)
            {
                Instantiate(objeto2, transform.position, Quaternion.identity);
                Instantiate(incoming, new Vector3(-1.05f, 2.5f, 0), Quaternion.identity);
                //incoming.SetActive(true);
                timeBtwSpawn = startTimeBtwSpawn;
                numAntContador = numContador;

            }
            else
            {
                timeBtwSpawn -= Time.deltaTime;
            }
        }
        else
        {
            numContador = API.numero2;
        }
    }
}
