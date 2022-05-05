using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PreGame : MonoBehaviour
{
    public ToggleGroup toggleGroup1;
    public ToggleGroup toggleGroup2;

    public Slider gameTimer;

    public Slider R1;
    public Slider G1;
    public Slider B1;

    public Slider R2;
    public Slider G2;
    public Slider B2;

    public Toggle currentSelection1{
        get { return toggleGroup1.ActiveToggles().FirstOrDefault(); }
    }

    public Toggle currentSelection2{
        get { return toggleGroup2.ActiveToggles().FirstOrDefault(); }
    }

    // Start is called before the first frame update
    void Start(){}

    public int player1Controls(){
        string s = currentSelection1.name;
        if (s.Equals("Player 1 ARROW Toggle")){
            return 0;
        } else if (s.Equals("Player 1 MOUSE Toggle")) {
            return 2;
        } else if (s.Equals("Player 1 WASD Toggle")){
            return 1;
         
        } else {
            return -1;
        }
    }

    public int player2Controls(){
        string s = currentSelection2.name;
        if (s.Equals("Player 2 ARROW Toggle")){
            return 0;
        } else if (s.Equals("Player 2 MOUSE Toggle")) {
            return 2;
        } else if (s.Equals("Player 2 WASD Toggle")){
            return 1;
         
        } else {
            return -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var toggles1 = toggleGroup1.GetComponentsInChildren<Toggle>();
        var toggles2 = toggleGroup2.GetComponentsInChildren<Toggle>();
        
        //Find wich controls are selected
        
        if (currentSelection1 == null || currentSelection2 == null){
            return;
        }
        

        int id = player1Controls();
        if (id < 0 || id >= 3) {
            return;
        }

        //IF same controls selected, change controls of player 2
        if (toggles1[id].isOn == toggles2[id].isOn){
            toggles2[id].isOn = false;
            if (id < 2) {
                toggles2[id + 1].isOn = true;
            } else {
                toggles2[id - 1].isOn = true;
            }
        }
        toggles1[id].isOn = true;
    }

    public void WriteToPManager(){
        PersistentManagerScript.Instance.gameTime = gameTimer.value;
        PersistentManagerScript.Instance.p1Controls = (InputKeyboard) player1Controls();
        PersistentManagerScript.Instance.p2Controls = (InputKeyboard) player2Controls();
        PersistentManagerScript.Instance.initialColor1 = new Color(R1.value,G1.value, B1.value);
        PersistentManagerScript.Instance.initialColor2 = new Color(R2.value,G2.value, B2.value);
    }



}
