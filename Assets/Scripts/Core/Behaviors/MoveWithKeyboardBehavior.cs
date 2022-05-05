using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Input Keys
public enum InputKeyboard{
    arrows, 
    wasd,
    mouse
}

public class MoveWithKeyboardBehavior : AgentBehaviour
{
    private InputKeyboard inputKeyboard;

    private Vector3 _target;
    public Camera Camera;

    private bool mooving = false;

    void Start(){
        if (this.gameObject.CompareTag("Player1")){
            inputKeyboard = PersistentManagerScript.Instance.p1Controls;
        } else if (this.gameObject.CompareTag("Player2")){
            inputKeyboard = PersistentManagerScript.Instance.p2Controls;
        }
    }

    public void OnEnable()
    {
        if (Camera == null)
        {
            throw new InvalidOperationException("Camera not set");
        }
    }


    public override Steering GetSteering()
    {

        Steering steering = new Steering();
        //implement your code here
        if ((int) inputKeyboard == 0)
        {
            
            steering.linear = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * agent.maxAccel;
            steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, agent.maxAccel));

        }
        else if ((int) inputKeyboard == 1)
        {
            steering.linear = new Vector3(Input.GetAxis("HorizontalWASD"), 0, Input.GetAxis("VerticalWASD")) * agent.maxAccel;
            steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, agent.maxAccel));
        }
        else {

            if (Input.GetMouseButton(0))
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.transform.position.y));

                if (!mooving)
                {
                    RaycastHit hit;

                    pos.y = Camera.transform.position.y;
                    //Debug.Log("Mouse pos to WORLD: " + pos.ToString());
                    //Debug.Log("Player pos: " + gameObject.transform.position.ToString());

                    if (Physics.Raycast(pos, Vector3.down, out hit))
                    {
                        //Debug.Log("Found an object - nature: " + hit.collider.transform.parent.tag.ToString());
                        if (hit.collider.transform.parent.tag.CompareTo(gameObject.transform.tag) == 0)
                        {
                            mooving = true;
                        }
                        
                    }
                }
                else {
                    pos.y = gameObject.transform.position.y;

                    Vector3 direction = pos - gameObject.transform.position;
                    //Debug.Log(direction.ToString());

                    // Juste pour empecher qu'il fasse des aller retours si on laisse la souris sur le cellulo
                    if (direction.magnitude < 0.1) {
                        //Debug.Log("magnitude ils too small");
                        direction = Vector3.zero;
                    }
                    direction.Normalize();

                    //Debug.Log("D After normalisation: " + direction.ToString());
                    steering.linear = direction * agent.maxAccel;
                }                
            }
             else if (!Input.GetMouseButton(0))
             {
                    mooving = false;
             }
        }

        if (this.gameObject.CompareTag("Player2"))
        {
            Debug.Log(steering.linear.ToString());
        }

        return steering;
    }
}
