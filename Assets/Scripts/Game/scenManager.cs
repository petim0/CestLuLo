using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scenManager : MonoBehaviour
{

    public string sceneToLoad;
    public Text player1Text;
    public Text player2Text;
    public Text time;
    public float ftime = 0;

    public float gameMinutes;

    public void IncreaseTime()
    {
        ftime = ftime  + ftime * 0.05f ;
    }

    public void DecreaseTime()
    {
        ftime = ftime * 0.95f;

    }

    // Start is called before the first frame update
    void Start()
    {
        PersistentManagerScript.Instance.player1Score = 0;
        PersistentManagerScript.Instance.player2Score = 0;
        player1Text.text = PersistentManagerScript.Instance.player1Score.ToString("00");
        player2Text.text = PersistentManagerScript.Instance.player2Score.ToString("00");
        gameMinutes = PersistentManagerScript.Instance.gameTime;
        time.text = "Timer: 00:00";
    }

    // Update is called once per frame
    void Update()
    {
        player1Text.text =  PersistentManagerScript.Instance.player1Score.ToString("00");
        player2Text.text =  PersistentManagerScript.Instance.player2Score.ToString("00");

        ftime += Time.deltaTime;
        float minutes = Mathf.FloorToInt(ftime / 60);
        float seconds = Mathf.FloorToInt(ftime % 60);
        time.text = string.Format("Timer: {0:00}:{1:00}", minutes, seconds);


        if (minutes == gameMinutes){
            LoadGameOver();
        }
    }

    void LoadGameOver(){
        SceneManager.LoadScene("GameOverScene");
    }
}
