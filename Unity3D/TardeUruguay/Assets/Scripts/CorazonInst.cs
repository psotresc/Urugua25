using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorazonInst : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void OnEnable()
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        //Debug.Log(clipInfo.Length);
        Destroy(gameObject, clipInfo[0].clip.length);
    }
}
