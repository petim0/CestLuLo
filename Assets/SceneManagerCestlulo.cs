using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerCestlulo : MonoBehaviour
{

    private int maxCpNb;
   

    public MoveWithKeyboardBehavior[] players;
    public CpScript[] cps;

    //Ceci pourrait être améliorée avec des maps
    private int[] lastCp;
    

    private int[] lapCount;

    private int LAP_VALUE;
    private int WAYPOINT_VALUE;

    private float[] distances;
    public int[] position;

    


    // Start is called before the first frame update
    void Start()
    {
        lastCp = new int[players.Length];
        lapCount = new int[players.Length];
        maxCpNb = cps.Length;
        distances = new float[players.Length];
        position = new int[players.Length];


        LAP_VALUE = 1000;
        WAYPOINT_VALUE = LAP_VALUE / (maxCpNb+1);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Debug.Log(players[0].getPosition());
        Debug.Log(cps[0].getPosition());
        */

        //Debug.Log(GetDistance(0, P1LastCP, P1laps));

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

        for (int i = 0; i < players.Length; i++)
        {
            Debug.Log(i.ToString() + "is: " + position[i].ToString());
        }
        

        
    }


    public void passed(string tag, int cpNb)
    {
        int previousCP = cpNb - 1 < 0 ? maxCpNb : cpNb - 1;

        //Faudrai bien mieux faire des maps mais flemme 
        if (tag == "Player1" && lastCp[0] == previousCP) {
            lastCp[0] = cpNb;
            if (cpNb == 0) {
                lapCount[0] += 1;
            }
        }

        if (tag == "Player2" && lastCp[1] == previousCP) {

            lastCp[1] = cpNb;
            if (cpNb == 0)
            {
                lapCount[1] += 1;
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
    
}
