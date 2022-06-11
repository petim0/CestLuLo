using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitAnim : MonoBehaviour
{

    public Animator animator;

    void Start()
    {
            animator.SetTrigger("Exit");
    }
    
}
