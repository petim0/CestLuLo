using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowValueSlider : MonoBehaviour
{
    Text value;

    // Start is called before the first frame update
    void Start()
    {
        value = GetComponent<Text>();
    }

    // Update is called once per frame
    public void textUpdate(float val)
    {
        value.text = Mathf.RoundToInt(val) + " min";
    }
}
