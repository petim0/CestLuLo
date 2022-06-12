using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MuteActive : MonoBehaviour
{
    public Toggle muted;

    public void Update()
    {
        if (muted.isOn)
        {
            PersistentManagerScript.Instance.muted = true;
        }
    }
}
