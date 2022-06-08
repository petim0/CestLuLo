using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ToggleChoosen : MonoBehaviour
{
    public Toggle tVirtual, tReel;

    public void Update()
    {
        if (tVirtual.isOn)
        {
            PersistentManagerScript.Instance.isVirtual = true;
        }else if (tReel.isOn)
        {
            PersistentManagerScript.Instance.isVirtual = false;
        }
    }
}
