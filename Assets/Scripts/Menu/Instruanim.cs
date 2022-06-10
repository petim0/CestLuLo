using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruanim : MonoBehaviour
{
    public Animator animator;


    void Start()
    {
            animator.SetTrigger("Instru");
       
    }
}
