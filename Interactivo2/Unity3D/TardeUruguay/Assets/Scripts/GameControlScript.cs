using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControlScript : MonoBehaviour
{
    //Personaje
    public GameObject Personaje;

    //Variables corazones
    public GameObject heart1, heart2, heart3, gameOver;
    public static int health;

    //Variables puntos
    public Text puntaje;
    public static int puntos;
    public static string puntosPasar;

    //Variables barra
    public GameObject barra;
    public static bool visibilidad;
    public GameObject barraGanar;

    //Variable Inicio
    public static bool comenzo = false;

    //Cambio UI
    public GameObject ui1;
    public GameObject ui2;
    public GameObject ui3;

    public static int uiUsar;

    //Folio
    public Text cuenta;
    public Text cuenta2;
    public Text folio;

    //Numero de recompensas PIBE 20, POLO 10, De 10 1 es o Polo o Pibe.
    int polo = 10;
    int pibe = 20;
    int elizabeth = 100;
    int antonio = 100;

    // Asignacion folios
    int fpolo = 0000;
    int fpibe = 0000;
    int felizabeth = 0000;
    int fantonio = 0000;

    // Botones presionados
    public static bool presionado = false;
    public static bool terminoJuego = false;

    //Public texto Foto
    public Text textoFoto;

    //Letreros
    public GameObject LetreroPibe;
    public GameObject LetreroZapa;
    public GameObject LetreroEli;
    public GameObject LetreroPolo;

    public GameObject Cubierta;

    //INICIO //////////////////////////////////////////////////////////////////////////////////////////////////////
    void Start()
    {
        // Se resetea la interfase
        Reset();

        //Comienza en instrucciones
        Instrucciones();

        FloatingTextController.Initialize();
    }

    //UPDATE //////////////////////////////////////////////////////////////////////////////////////////////////////
    void Update()
    {

        // BOTONES


        //Si acabaron los counters para entrar a juego
        if (Counter.acabo)
        {
            Reset();
            Instrucciones();
            Counter.acabo = false;
        }

        if (Counter2.acabo)
        {
            Reset();
            Instrucciones();
            Counter2.acabo = false;
        }

        // Si se toca cualquier tecla inicia nivel 1 

        if (terminoJuego)
        {
            if (BotonesJuego.butDer || BotonesJuego.butIzq || BotonesJuego.butOk)
            {
                presionado = true;
                
            }
        }

        if (presionado && terminoJuego)
        {
            Juego();
        }

        // ACTUALIZA PUNTAJE 
        puntaje.text = puntos.ToString();
        //Mandalo a Popup
        puntosPasar = puntos.ToString();
        

        //ACTUALIZA BARRA
        barra.SetActive(visibilidad);

        //SWITCH INTERFASE
        switch (uiUsar)
        {
            case 1:
                ui1.SetActive(true);
                ui2.SetActive(false);
                ui3.SetActive(false);
                break;
            case 2:
                ui1.SetActive(false);
                ui2.SetActive(true);
                ui3.SetActive(false);
                break;
            case 3:
                ui1.SetActive(false);
                ui2.SetActive(false);
                ui3.SetActive(true);
                break;
        }

        // SI CHOCA CON OBSTACULO QUITA CORAZONES 
        #region CORAZONES
        if (health > 3)
            health = 3;
        switch (health)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                Time.timeScale = 1;
                break;
            case 2:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            case 1:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(true);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                if (HealthBarScript.ganado)
                {
                    Ruleta();
                    health = 1;
                    Personaje.SetActive(false);
                    Cubierta.SetActive(true);
                }
                else
                {
                    Perdiste();
                    health = 1;
                    Personaje.SetActive(false);
                    Cubierta.SetActive(true);
                }
                break;
        }
        #endregion CORAZONES
    }

    public void Reset()
    {
        //No se ve persoanje 
        Personaje.SetActive(true);
        //NO SE VE BARRA
        barra.SetActive(visibilidad);

        //NO HA COMENZADO
        comenzo = false;
        terminoJuego = true;
        presionado = false;

        // COMIENZA CON TRES CORAZONES 
        health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);

        //RESET CONTADOR
        //Counter2.reset = true;
        //Counter.reset = true;

        puntos = 0;

        //RESET RULETA
        RuletaRot.eleccion = 5;

        // RESET BARRA
        HealthBarScript.reset = true;
        HealthBarScript.ganado = false;
        barraGanar.SetActive(false);

        //Reset Letreros
        LetreroPibe.SetActive(false);
        LetreroZapa.SetActive(false);
        LetreroEli.SetActive(false);
        LetreroPolo.SetActive(false);

        Cubierta.SetActive(false);

        Obstaculo.speed = 3;
    }

    public void Instrucciones()
    {
        // CAMARA INICIO
        movCam.nivel = 1;

        //INTERFASE 1
        uiUsar = 1;      
    }

    /// PANTALLA JUEGO ////////////////////////////////////////////////////////////////////////////////////////////
    void Juego()
    {
        //CAMARA NIVEL 2
        movCam.nivel = 2;

        // COMIENZO SPAWNERS
        comenzo = true;
        terminoJuego = false;

        Spawner.inicio = true;
        Spawner2.inicio = true;
        Spawner3.inicio = true;
        SpawnerObst.inicio = true;
    }

    /// PANTALLA PERDISTE ////////////////////////////////////////////////////////////////////////////////////////////
    void Perdiste()
    {
        Counter2.reset = true;

        cuenta2.text = puntos.ToString("0000");

        movCam.nivel = 4;
        uiUsar = 3;
        Spawner.inicio = false;
        Spawner2.inicio = false;
        Spawner3.inicio = false;
        SpawnerObst.inicio = false;

    }
    /// PANTALLA RULETA ////////////////////////////////////////////////////////////////////////////////////////////
    void Ruleta()
    {
        Counter.reset = true;
        
        cuenta.text = puntos.ToString("0000");

        movCam.nivel = 3;
        uiUsar = 2;
        Spawner.inicio = false;
        Spawner2.inicio = false;
        Spawner3.inicio = false;
        RuletaRot.eleccion = 1;

        
        //Counter.acabo = true;

        
        int contador = 0;
        int especial = 0; 
        int normales;
        int especiales;
        int seleccion =0;

        normales = Random.Range(1, 3);
        especiales = Random.Range(3, 5);

        //Si no se ha seleccionado especial y es menor a 10 selecciona uno de los 2
        if (contador < 10 && especial ==0)
        {
            int seleccion1 = Random.Range(1, 3);
            if (seleccion1 ==1)
            {
                seleccion = normales;
            }
            if (seleccion1 == 2)
            {
                seleccion = especiales;
                especial = 1;
            }
            contador++;
            especial++;
        }
        //Si ya se selecciono especial entonces selecciona random de normales
        else if (contador < 10)
        {
            if (contador > 10)
            {
                contador = 0;
                especial = 0;
            }
            seleccion = normales;
            contador++;
        }

        //Hay 2 randoms
        //Uno selecciona los especiales y otro los normales

        // Si el 
        switch (seleccion)
        {
            case 1:
                antonio--;
                RuletaRot.eleccion = 1;
                fantonio++;
                folio.text = fantonio.ToString("0000");
                //Letrero de Antonio 
                LetreroZapa.SetActive(true);
                //Cambiar texto abajo
                textoFoto.text = "Toma una foto de esta pantalla y preséntala en Uruguay #12 para canjear tu promoción";
                break;

            case 2:
                pibe--;
                RuletaRot.eleccion = 2;
                fpibe++;
                folio.text = fpibe.ToString("0000");
                //Letrero de Pibe 
                LetreroPibe.SetActive(true);
                //Cambiar texto abajo
                textoFoto.text = "Toma una foto de esta pantalla y preséntala en Uruguay esquina con Simón Bolivar #51 para canjear tu promoción";
                break;

            case 3:
                polo--;
                RuletaRot.eleccion = 3;
                fpolo++;
                folio.text = fpolo.ToString("0000");
                //Letrero de Polo 
                LetreroPolo.SetActive(true);
                //Cambiar texto abajo
                textoFoto.text = "Toma una foto de esta pantalla y preséntala en Uruguay #31 para canjear tu promoción";
                break;

            case 4:
                elizabeth--;
                RuletaRot.eleccion = 4;
                felizabeth++;
                folio.text = felizabeth.ToString("0000");
                //Letrero de Elizabeth 
                LetreroEli.SetActive(true);
                //Cambiar texto abajo
                textoFoto.text = "Toma una foto de esta pantalla y preséntala en Uruguay #26 para canjear tu promoción";
                break;
        }

        
        //Numero de Uruguay

    }
    

}

