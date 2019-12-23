using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public GameObject barraGanar;
    public GameObject Promocion;
    Image healthBar;
    float maxHealth = 0f;
    public static float health;
    public static bool ganado = false;
    public static bool reset = false;

    public static bool agarrado = false;
    public static bool resetBar = false;
    void Start()
    {
        healthBar = GetComponent<Image>();
        health = maxHealth;
        barraGanar.SetActive(false);

    }
    void Update()
    {
        //EASY
        healthBar.fillAmount = health*2;
        //MEDIUM
        //healthBar.fillAmount = health/2 ;
        barraGanar.SetActive(ganado);

        if (reset)
        {
            barraGanar.SetActive(false);
            //Debug.Log("RESET!!!!!!!!!!!!!");
            healthBar.fillAmount = 0;
            reset = false;
            ganado = false;
            health = 0;
            Promocion.SetActive(false);
        }

        // Si toca obstaculo se resetea 
        if (resetBar)
        {
            health = 0;
            healthBar.fillAmount = 0;
            resetBar = false;
        }
        // Si toca otros premios que no se resetee


        else if (resetBar)
        {

        }

        if (healthBar.fillAmount == 1 && ganado == false)
        {
            Debug.Log("GANASTE UN PREMIO");
            ganado = true;
            barraGanar.SetActive(true);
            Promocion.SetActive(true);
            StartCoroutine(Espera(4));
        }

    }
    public IEnumerator Espera(int seg)
    {
        yield return new WaitForSeconds(seg);
        Promocion.SetActive(false);
    }

}
