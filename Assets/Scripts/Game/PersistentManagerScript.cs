using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistentManagerScript : MonoBehaviour
{
    public static PersistentManagerScript Instance { get; private set; }

    public float gameTime;
    public InputKeyboard p1Controls;
    public InputKeyboard p2Controls;

    public Color initialColor1;
    public Color initialColor2;

    public int player1Score;
    public int player2Score;

    public int[] positions;

    public bool isVirtual;
    public float AiSpeed;

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
