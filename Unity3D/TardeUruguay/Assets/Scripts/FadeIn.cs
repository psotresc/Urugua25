using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    // Start is called before the first frame update
    public Image difuminar;

    void Start()
    {
        difuminar.canvasRenderer.SetAlpha(1.0f);
        fadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void fadeOut()
    {
        difuminar.CrossFadeAlpha(0, 2, false);
    }
}
