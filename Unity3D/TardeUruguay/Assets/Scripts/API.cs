using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;

public class API : MonoBehaviour
{
    //Variables Sensor1 Pibe 
    private const string URL = "http://uruguay25.mx/apiUruguay/sensor1/lastOne.php";
    public static string valor;
    private int myVar = 0;
    public static int numero;

    //Variables Sensor2 Zapateria
    private const string URL2 = "http://uruguay25.mx/apiUruguay/sensor2/lastOne.php";
    public static string valor2;
    private int myVar2 = 0;
    public static int numero2;

    //Variables Sensor3 Eli 
    private const string URL3 = "http://uruguay25.mx/apiUruguay/sensor3/lastOne.php";
    public static string valor3;
    private int myVar3 = 0;
    public static int numero3;

    //Variables Sensor4 Polo 
    private const string URL4 = "http://uruguay25.mx/apiUruguay/sensor4/lastOne.php";
    public static string valor4;
    private int myVar4 = 0;
    public static int numero4;

    public float tiempoConexion = 10f;
 
    
    public void Start()
    {   
        StartCoroutine(GetSensor1(URL));
        StartCoroutine(GetSensor2(URL2));
        StartCoroutine(GetSensor3(URL3));
        StartCoroutine(GetSensor4(URL4));
    }

    IEnumerator GetSensor1(string URL)
    {
        //Hace peticion 
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        //si hay error
        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        //Muestra lo que regreso
        else
        {
            //lee el json y saca datos
            JSONNode data = JSON.Parse(www.downloadHandler.text);
            valor = data["info1"].Value;

            //Asignalo a una variable
            numero = int.Parse(valor);
        
            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;

            //Conteo de consulta
            //Debug.Log("SE REALIZO CONSULTA Sensor1 " + myVar + "= " + numero);
            myVar += 1;

            //Espera para realizar consulta nuevamente
            yield return new WaitForSeconds(tiempoConexion);

            //Haz que se llame constantemente 
            StartCoroutine(GetSensor1(URL));
        }
    }

    IEnumerator GetSensor2(string URL2)
    {
        //Hace peticion 
        UnityWebRequest www = UnityWebRequest.Get(URL2);
        yield return www.SendWebRequest();

        //si hay error
        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        //Muestra lo que regreso
        else
        {
            //lee el json y saca datos
            JSONNode data = JSON.Parse(www.downloadHandler.text);
            valor2 = data["info1"].Value;

            //Asignalo a una variable
            numero2 = int.Parse(valor2);

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;

            //Conteo de consulta
            //Debug.Log("SE REALIZO CONSULTA Sensor2 " + myVar2 + "= " + numero2);
            myVar2 += 1;

            //Espera para realizar consulta nuevamente
            yield return new WaitForSeconds(tiempoConexion);

            //Haz que se llame constantemente 
            StartCoroutine(GetSensor2(URL2));
        }
    }

    IEnumerator GetSensor3(string URL3)
    {
        //Hace peticion 
        UnityWebRequest www = UnityWebRequest.Get(URL3);
        yield return www.SendWebRequest();

        //si hay error
        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        //Muestra lo que regreso
        else
        {
            //lee el json y saca datos
            JSONNode data = JSON.Parse(www.downloadHandler.text);
            valor3 = data["info1"].Value;

            //Asignalo a una variable
            numero3 = int.Parse(valor3);

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;

            //Conteo de consulta
            //Debug.Log("SE REALIZO CONSULTA Sensor3 " + myVar3 + "= " + numero3);
            myVar3 += 1;

            //Espera para realizar consulta nuevamente
            yield return new WaitForSeconds(tiempoConexion);

            //Haz que se llame constantemente 
            StartCoroutine(GetSensor3(URL3));
        }
    }

    IEnumerator GetSensor4(string URL4)
    {
        //Hace peticion 
        UnityWebRequest www = UnityWebRequest.Get(URL4);
        yield return www.SendWebRequest();

        //si hay error
        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        //Muestra lo que regreso
        else
        {
            //lee el json y saca datos
            JSONNode data = JSON.Parse(www.downloadHandler.text);
            valor4 = data["info1"].Value;

            //Asignalo a una variable
            numero4 = int.Parse(valor4);

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;

            //Conteo de consulta
            //Debug.Log("SE REALIZO CONSULTA Sensor3 " + myVar4 + "= " + numero4);
            myVar4 += 1;

            //Espera para realizar consulta nuevamente
            yield return new WaitForSeconds(tiempoConexion);

            //Haz que se llame constantemente 
            StartCoroutine(GetSensor4(URL4));
        }
    }
}

