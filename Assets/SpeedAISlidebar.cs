using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedAISlidebar : MonoBehaviour
{
    public Text textholder;
    public Slider SliderAi;

    void Start()
    {
        textholder.text = Math.Round(SliderAi.value, 2).ToString();
    }



    // Update is called once per frame
    void Update()
    {
        textholder.text = Math.Round(SliderAi.value, 2).ToString();
        PersistentManagerScript.Instance.AiSpeed = SliderAi.value;
    }
}
