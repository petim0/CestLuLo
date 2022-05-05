using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelluloInGameBehavior2 : AgentBehaviour
{

    private CelluloAgent celluloAgent;
    private bool playerConnected;


    // Start is called before the first frame update
    void Start()
    {
        celluloAgent = gameObject.GetComponent<CelluloAgent>();
        //ks
        playerConnected = false;

        if (celluloAgent == null)
        {
            Debug.LogWarning("An active CelluloAgent should be attached to the same gameobject.");
        }
        OnCelluloSheep();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public override void OnCelluloLongTouch(int key)
    {
        //passer le booléen à true pour que launchGameCellulos sache que le joueur est pret
        playerConnected = true;

    }



    public void OnCelluloGhost()
    {
        if (celluloAgent == null)
        {
            Debug.LogWarning("An active CelluloAgent should be attached to the same gameobject.");
        }
        else
        {
            celluloAgent.MoveOnStone();
        }
    }

    public void OnCelluloSheep()
    {
        // agent.ResetOnClick(); //on doit reset pour enlever le moveOnStone ?
        if (celluloAgent == null)
        {
            Debug.LogWarning("An active CelluloAgent should be attached to the same gameobject.");
        }
        else
        {
            celluloAgent.ClearHapticFeedback();
            celluloAgent.SetCasualBackdriveAssistEnabled(true);
        }

    }

    public bool isPlayerConnected()
    {
        return this.playerConnected;
    }

    public CelluloAgent getAgent()
    {
        return this.celluloAgent;
    }
}