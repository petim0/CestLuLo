using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMuteScript : MonoBehaviour
{

    public AudioListener audioListener;
    private bool toggle = true;

    public void ToggleSound() {
        {
            toggle = !toggle;

            if (toggle)
                AudioListener.volume = 1f;

            else
                AudioListener.volume = 0f;
        }
    }

}
