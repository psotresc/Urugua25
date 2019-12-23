using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Counter : MonoBehaviour
{
    public Text uiText;
    public float mainTimer; 

    private float timer;
    public static bool canCount = true;
    private bool doOnce = false;

    public Image contador;
    public static bool acabo = false;

    public static bool reset = false;

    void Start()
    {
        timer = mainTimer;
    }


    void Update()
    {
        if (reset)
        {
            timer = mainTimer;
            canCount = true;
            doOnce = false;
            acabo = false;
            reset = false;

        }

        if (timer >= 0.0 && canCount)
        {
            timer -= Time.deltaTime;
            uiText.text = timer.ToString("F1");
            Filling();
        }
        else if (timer <0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            uiText.text = "0.00";
            timer = 0.0f;
            acabo = true;
            GameControlScript.terminoJuego = true;
        }
        
    }   

    void Filling()
    {
        var percent = timer / mainTimer;
        float result = Mathf.Lerp(0, 1, percent);
        //Debug.Log("El valor es" + result);
        contador.fillAmount = result;
    }

    public void ResetBtn()
    {
        timer = mainTimer;
        canCount = true;
        doOnce = false;
    }
}

/// CONTADOR ENUMARATOR
//public class Counter : MonoBehaviour
//{
//    public Image contador;
//    public Text timeText;
//    [Range(0,1)] public float fillAmount;
//    public static float seconds;
//    private float totalSeconds;
//    private float actualizar = 0;

//    public static bool acabo = false;

//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if(acabo == false)
//        {
//            seconds = 10;
//            totalSeconds = seconds;
//            StartCoroutine(Second());
//            acabo = true;
//        }
//    }

//    IEnumerator Second()
//    {
//        yield return new WaitForSeconds(1f);

//        if (seconds == 0)
//        {
//            Debug.Log("SE ACABO");
//            acabo = true;

//        }

//        if (seconds > 0)
//        {
//            seconds--;
//            actualizar++;
//        }

//        timeText.text = seconds.ToString();
//        Filling(); 
//        StartCoroutine(Second());
//    }

//    void Filling()
//    {
//        var percent = actualizar / totalSeconds;
//        float result = Mathf.Lerp(1, 0, percent);
//        //Debug.Log("El valor es" + result);
//        contador.fillAmount = result;
//    }


//}
