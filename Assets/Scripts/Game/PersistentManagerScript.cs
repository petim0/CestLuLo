using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistentManagerScript : MonoBehaviour
{
    public static PersistentManagerScript Instance { get; private set; }

    //Those are useless but we can't delete it otherwise it makes errors in other scenes we don't use
    public float gameTime;
    public InputKeyboard p1Controls;
    public InputKeyboard p2Controls;
    public int player1Score;
    public int player2Score;


    //the reste is useful 
    public Color initialColor1;
    public Color initialColor2;

    public int[] positions;

    public bool isVirtual;
    public float AiSpeed;
    public bool muted;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
}
