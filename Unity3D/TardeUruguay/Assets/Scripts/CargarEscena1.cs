using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CargarEscena1 : MonoBehaviour
{
    public SerialPort sp = new SerialPort("COM4", 9600);

    void Start()
    {
        //StartCoroutine(ChangeToScene("Instrucciones"));
        sp.Open();
        sp.ReadTimeout = 1;

    }
    void Update()
    {
        if (sp.IsOpen)
        {
            try
            {
                if (sp.ReadByte() == 1)
                {
                    SceneManager.LoadScene("Instrucciones");
                }

                if (sp.ReadByte() == 2)
                {
                    SceneManager.LoadScene("Instrucciones");

                }
            }
            catch (System.Exception)
            {

            }
        }
    }
    public IEnumerator ChangeToScene(string sceneToChangeTo)
    {
        Debug.Log("Comenzo");
        yield return new WaitForSeconds(5);

        Debug.Log("Corrio");
        SceneManager.LoadScene(sceneToChangeTo);
    }
}

