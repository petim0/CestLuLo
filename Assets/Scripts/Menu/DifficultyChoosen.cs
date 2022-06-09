using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DifficultyChoosen : MonoBehaviour
{
    public Toggle tNormal, tHard;

    public void Update()
    {
        if (tHard.isOn)
        {
            PersistentManagerScript.Instance.hardMode = true;
        }
        else if (tNormal.isOn)
        {
            PersistentManagerScript.Instance.hardMode = false;
        }
    }

}
