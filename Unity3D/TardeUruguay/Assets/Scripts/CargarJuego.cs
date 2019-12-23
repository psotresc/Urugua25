using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarJuego : MonoBehaviour
{
    public SerialPort sp = new SerialPort("COM4", 9600);

    void Start()
    {
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
                    SceneManager.LoadScene("Juego");
                }

                if (sp.ReadByte() == 2)
                {
                    SceneManager.LoadScene("Juego");

                }
            }
            catch (System.Exception)
            {

            }
        }
    }



}
