using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorazonInstanceCont : MonoBehaviour
{
    private static CorazonInst corazon;
    private static GameObject canvas;

    public static void Initialize()
    {
        canvas = GameObject.Find("Canvas");
        if (!corazon)
            corazon = Resources.Load<CorazonInst>("Prefabs/CorazonParent");
    }

    public static void CreateCorazon(Transform location)
    {
        CorazonInst instance = Instantiate(corazon);
        //Vector2 screenPosition = Camera.main.WorldToScreenPoint(new Vector2(location.position.x, location.position.y + 5));
        //Vector2 Posicion = new Vector2( location.position.x, location.position.y);
    
        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = new Vector2(location.position.x, location.position.y + 5);
    }
}
