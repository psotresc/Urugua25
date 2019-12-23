using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuletaRot : MonoBehaviour
{
    Animator anim;
    //int ruleta1 = Animator.StringToHash("Base Layer.Ruleta01-Zapato");
    public static int eleccion; 

    //public float multiplier = 1;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        switch (eleccion)
        {
            case 1:
                //Zapato
                anim.Play("Ruleta01-Zapato");
                break;
            case 2:
                //Empanada
                anim.Play("Ruleta03-Empanada");
                break;
            case 3:
                //Rana
                anim.Play("Ruleta04-Rana");
                break;
            case 4:
                //Mica
                anim.Play("Ruleta02-Mica");
                break;
            case 5:
                anim.Play("Idle");
                break;
        }

        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    anim.Play("Ruleta02-Emapanada");
        //    Debug.Log("Deberia rodar");
        //    //anim.SetTrigger("Ruleta4");
        //}
    }
}
