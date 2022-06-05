using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuManager : MonoBehaviour
{

    public Text winner;
    public Text looser;
    public Text honoMention;

    // Start is called before the first frame update
    void Start()
    {
        winner.gameObject.SetActive(true);
        looser.gameObject.SetActive(true);
        honoMention.gameObject.SetActive(true);

        if (PersistentManagerScript.Instance.positions[0] == 1)
        {
            winner.text = "PLAYER 1";
            looser.text = "PLAYER 2 - " + ((PersistentManagerScript.Instance.positions[1] == 2) ? "2nd" : "3rd");
        }
        else if (PersistentManagerScript.Instance.positions[1] == 1)
        {
            winner.text = "PLAYER 2";
            looser.text = "PLAYER 1 - " + ((PersistentManagerScript.Instance.positions[0] == 2) ? "2nd" : "3rd");
        }
        else
        {
            winner.text = "Player 3";
            looser.text = "You don't deserve any honorable mention, you were beaten by a bot !";
            honoMention.gameObject.SetActive(false);
        }


        
    }

    
}
