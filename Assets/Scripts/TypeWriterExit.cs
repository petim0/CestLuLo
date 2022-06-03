using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriterExit : MonoBehaviour
{

    string originalTexte;
    Text uiText;
    public float delay = 0.2f;


    void Awake()
    {
        uiText = GetComponent<Text>();
        originalTexte = uiText.text;
        uiText.text = null;
        StartCoroutine(ShowLetterByLetter());
    }

    IEnumerator ShowLetterByLetter()
    {
        for(int i = 0; i <= originalTexte.Length; i++)
        {
            uiText.text = originalTexte.Substring(0,i);
            yield return new WaitForSeconds(delay);
        }
    }
}
