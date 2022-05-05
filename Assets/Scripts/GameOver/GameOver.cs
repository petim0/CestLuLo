using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public GameObject draw;
    private int score1 = 20;
    private int score2=1;
    // Start is called before the first frame update
    void Start()
    {
        
        score1 = PersistentManagerScript.Instance.player1Score;
        score2 = PersistentManagerScript.Instance.player2Score; 
        //Debug.Log("1 "+score1);
        //Debug.Log("2 "+PersistentManagerScript.Instance.getPlayer2Score());
        displayFollowingScore();
     //   resetGameState();

    }
    // Update is called once per frame
    void Update()
    {
    }

    void displayFollowingScore(){
        if( score1 > score2){
            Player1.SetActive(true);
            Player2.SetActive(false);
            draw.SetActive(false);
        }else{
            if(score1 <  score2){
            Player1.SetActive(false);
            Player2.SetActive(true);
            draw.SetActive(false);
            }else{
            Player1.SetActive(false);
            Player2.SetActive(false);
            draw.SetActive(true);                
            }
        }
    }

}
