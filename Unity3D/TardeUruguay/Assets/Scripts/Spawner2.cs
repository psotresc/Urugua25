using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    public GameObject[] obstaclePatterns;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;

    public static bool inicio = false;
    private int rango;
    // Update is called once per frame

    private void Update()
    {
        rango = Random.Range(2, 5);

        if (timeBtwSpawn <= 0 && inicio)
        {
            int rand = Random.Range(0, obstaclePatterns.Length);

            Instantiate(obstaclePatterns[rand], transform.position, Quaternion.identity);
            timeBtwSpawn = rango;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime; 
        }
    }
}
