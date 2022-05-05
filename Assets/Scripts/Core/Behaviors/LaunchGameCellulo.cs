using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LaunchGameCellulo : AgentBehaviour
{
    private bool player1Connected;
    private bool player2Connected;
    public bool gameLaunched;
    public CelluloInGameBehavior cellulo1;
    public CelluloInGameBehavior cellulo2;

    // Start is called before the first frame update
    void Start()
    {
        player1Connected = false;
        player2Connected = false;
        gameLaunched = false ; 

    }

    // Update is called once per frame
    void Update()
    {
        player1Connected = cellulo1.isPlayerConnected();
        player2Connected = cellulo2.isPlayerConnected();
        if(gameLaunched == false){  //checks si le jeu est lancé, si non, vérifie que les 2 joueurs sont prets
                                    // si c'est le cas, change gameLaunched et change de scène.
            if(player1Connected && player2Connected){
            cellulo1.getAgent().ClearHapticFeedback();
            cellulo2.getAgent().ClearHapticFeedback();
            SceneManager.LoadScene(1);
            gameLaunched = true; 
            }
        }
        
        
    }
}
