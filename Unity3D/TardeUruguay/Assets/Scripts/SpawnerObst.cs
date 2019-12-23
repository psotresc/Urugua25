using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObst : MonoBehaviour
{
    public GameObject[] obstaclePatterns2;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;

    public static bool inicio = false;
    private float rango;
    // Update is called once per frame

    void Update()
    {
        rango = Random.Range(2, 7);

        if (timeBtwSpawn <= 0 && inicio)
        {
            int rand = Random.Range(0, obstaclePatterns2.Length);

            Instantiate(obstaclePatterns2[rand], transform.position, Quaternion.identity);
            timeBtwSpawn = rango;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }

        if (inicio)
        {
            Obstaculo.speed += .0001f;
            Debug.Log(Obstaculo.speed);

        }
    }
}
