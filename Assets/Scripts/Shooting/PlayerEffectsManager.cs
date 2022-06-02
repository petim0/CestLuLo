using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffectsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int startingSpeed;
    public int currentSpeed;

    void Start()
    {
        currentSpeed = startingSpeed;
    }

    public void ParalyzePlayer(){
        /*
        if (speedPercentage < 0 || speedPercentage > 100) {
            Debug.LogWarning("SpeedPercentage must be between 0 and 1000.");
            return;
        }
        currentSpeed = currentSpeed * speedPercentage;
        //TODO: Change PLAYER COLOR
        if (speedPercentage == 100) {
            currentSpeed = startingSpeed;
        }
        */
        this.gameObject.GetComponent<MoveWithKeyboardBehavior>().Paralyze();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
