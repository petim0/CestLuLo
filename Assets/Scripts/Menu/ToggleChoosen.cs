using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ToggleChoosen : MonoBehaviour
{
    public Toggle tVirtual, tReel;
    public ToggleGroup t;

    /*public void Start()
    {
        t = GetComponent<ToggleGroup>();
        tVirtual = GetComponent<Toggle>();
        tReel = GetComponent<Toggle>();

        if (t.ActiveToggles.gameObject == tVirtual.gameObject)
        {
            Debug.Log("v");
            //return 1;

        }else if(t.ActiveToggles.gameObject == tReel.gameObject)
        {
            Debug.Log("R");
            //return 2;
        }
        else{
            //return 0;
        }
    }*/
}
