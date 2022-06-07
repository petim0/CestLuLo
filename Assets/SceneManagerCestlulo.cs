using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class SceneManagerCestlulo : MonoBehaviour
{

    private int maxCpNb;
   

    public positionInstance[] players;
    public CpScript[] cps;

    //Ceci pourrait être améliorée avec des maps
    private int[] lastCp;
    

    private int[] lapCount;

    private int LAP_VALUE;
    private int WAYPOINT_VALUE;

    private float[] distances;
    public int[] position;

    public Text player1Pos;
    public Text player2Pos;

    public int NB_OF_LAPS_TO_WIN;

    


    // Start is called before the first frame update
    void Start()
    {
        lastCp = new int[players.Length];
        lapCount = new int[players.Length];
        maxCpNb = cps.Length;
        distances = new float[players.Length];
        position = new int[players.Length];

        player1Pos.text = "FIRST!";
        player2Pos.text = "FIRST!";

        LAP_VALUE = 1000;
        WAYPOINT_VALUE = LAP_VALUE / (maxCpNb+1);

        ChooseCircuit choosen = GetComponent<ChooseCircuit>();
        choosen.DesactivateCircuit();

    }

    // Update is called once per frame
    void Update()
    {
        /*
        Debug.Log(players[0].getPosition());
        Debug.Log(cps[0].getPosition());
        */

        

        //C'est immonde mais j'ai pas eu le courage de faire plus jolis
        // Et je sais pas ce que c'est le mieux entre for forfor et forfor qui refait des calculs
        // Les deux sont dégeu en vrai
        for (int i = 0; i < players.Length; i++) {
            distances[i] = GetDistance(i, lastCp[i], lapCount[i]);
        }

        for (int i = 0; i < players.Length; i++)
        {
            position[i] = 1;
            for (int j = 0; j < players.Length; j++)
                if (distances[i] < distances[j]) {
                    position[i] += 1;
                }
                
        }

        /*
        for (int i = 0; i < players.Length; i++)
        {
            Debug.Log(i.ToString() + "is: " + position[i].ToString());
        }
        */

        player1Pos.text = position[0].ToString();
        player2Pos.text = position[1].ToString();
    }


    public void passed(string tag, int cpNb)
    {
        int previousCP = cpNb - 1 < 0 ? maxCpNb - 1 : cpNb - 1;
        //Debug.Log("Previous CP : " + previousCP);

        //Faudrai bien mieux faire des maps mais flemme 
        if (tag == "Player1" && lastCp[0] == previousCP) {
            lastCp[0] = cpNb;
            if (cpNb == 0) {
                lapCount[0] += 1;
            }

            if (lapCount[0] == NB_OF_LAPS_TO_WIN) {
                LoadGameOver();
            }
        }

        if (tag == "Player2" && lastCp[1] == previousCP) {

            lastCp[1] = cpNb;
            if (cpNb == 0)
            {
                lapCount[1] += 1;
            }

            if (lapCount[1] == NB_OF_LAPS_TO_WIN)
            {
                LoadGameOver();
            }
        }

        if (tag == "Player3" && lastCp[2] == previousCP)
        {

            lastCp[2] = cpNb;
            if (cpNb == 0)
            {
                lapCount[2] = lapCount[2] + 1;
            }

            //Debug.Log(lapCount[2].ToString());
            //Debug.Log(lapCount[2] == NB_OF_LAPS_TO_WIN);
            if (lapCount[2] == NB_OF_LAPS_TO_WIN)
            {
                LoadGameOver();
            }
        }


        /*
        Debug.Log(tag);
        Debug.Log(P1LastCP.ToString() + " " + P2LastCP.ToString());
        Debug.Log(P1laps.ToString() + " " + P2laps.ToString());
        */
    }

    
    public float GetDistance(int playerNb, int LastCp, int currentLap)
    {
        
        return (players[playerNb].getPosition() - cps[LastCp].getPosition()).magnitude + LastCp * WAYPOINT_VALUE + currentLap * LAP_VALUE;
    }


    void LoadGameOver()
    {
        PersistentManagerScript.Instance.positions = position;
        SceneManager.LoadScene("GameOverCestLuLo");
    }



}
