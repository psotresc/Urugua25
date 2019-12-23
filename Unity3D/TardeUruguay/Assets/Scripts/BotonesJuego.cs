using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class BotonesJuego : MonoBehaviour
{
    public static bool butIzq = false;
    public static bool butDer = false;
    public static bool butOk = false;

    //////////////////PUERTOS SERIALES//////////////////////////////////////////////////////////////////////////////////

    public SerialPort sp = new SerialPort("COM4", 9600);

    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;
        Debug.Log("Abrio Puertos");


    }
    void Update()
    {


        if (sp.IsOpen)
        {
            butIzq = false;
            butDer = false;
            butOk = false;

            //Debug.Log(butDer);
            try
            {
                int lectura = sp.ReadByte();

                if (lectura == 1)
                {
                    butOk = true;
                    //Debug.Log("Ok");
                }

                else if (lectura == 2)
                {
                    butIzq = true;
                    // Debug.Log("Izquierda");
                }

                else if (lectura == 3)
                {
                    butDer = true;
                    //Debug.Log("Derecha");
                }

                else
                {
                    butIzq = false;
                    butDer = false;
                    butOk = false;
                }


            }
            catch (System.Exception)
            {
            }
        }

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////BOTONES 
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.LeftArrow))
    //    {
    //        butIzq = true;
    //    }
    //    else if (Input.GetKeyDown(KeyCode.RightArrow))
    //    {
    //        butDer = true;
    //    }

    //    else if (Input.GetKeyDown(KeyCode.DownArrow))
    //    {
    //        butOk = true;
    //    }

    //    else
    //    {
    //        butIzq = false;
    //        butDer = false;
    //        butOk = false;
    //    }
    //}


    // ACABA//////////////////////////////////////////////////////////////////
}
