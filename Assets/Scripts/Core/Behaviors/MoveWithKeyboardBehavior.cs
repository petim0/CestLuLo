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
    public InputKeyboard inputKeyboard;
     

    private Vector3 _target;
    public Camera Camera;
    private Vector3 dir;
    private float lastspeed;
    private float BRAKING;
    private bool mooving = false;

    //PARALYZED
    private int paralyzedTime = 200;
    public bool isParalyzed;
    private const int paralysisTime = 200;
    //

    void Start(){
        /*
        if (this.gameObject.CompareTag("Player1")){
            inputKeyboard = PersistentManagerScript.Instance.p1Controls;
        } else if (this.gameObject.CompareTag("Player2")){
            inputKeyboard = PersistentManagerScript.Instance.p2Controls;
        }
        */



        dir = new Vector3(1, 0, 0);
        lastspeed = 0;
        BRAKING = (float) 0.2;
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

        

        if ((int) inputKeyboard == 0)
        {

            float speed = 0;
            float brakingSpeed;
            bool isGoingForward = lastspeed >= 0 ;

            if (isGoingForward)
            {
                speed = Math.Max(Input.GetAxis("Vertical") * agent.maxAccel, lastspeed - (float)0.1);
                brakingSpeed = BRAKING;

            }
            else {
                //Debug.Log((Input.GetAxis("Vertical") * agent.maxAccel).ToString() + " " + (lastspeed + (float)0.1).ToString());
                //Debug.Log(Math.Min(Input.GetAxis("Vertical") * agent.maxAccel, lastspeed + (float)0.1).ToString());
                speed = Math.Min(Input.GetAxis("Vertical") * agent.maxAccel, lastspeed + (float)0.1);
                brakingSpeed = -BRAKING;

            }

           
            if (Input.GetAxis("breakKeys") > 0) {
                speed = lastspeed - brakingSpeed;
                if ((speed < 0 && isGoingForward) || (speed > 0 && !isGoingForward)) {
                    speed = 0;
                }
            }

            if (isParalyzed && paralyzedTime > 0) {
                paralyzedTime -= 1;
                speed = 0;
                Debug.Log("Timer 1: "+paralyzedTime);
                if (paralyzedTime < 0) {
                    isParalyzed = false;
                }
            }


            lastspeed = speed;


            //Debug.Log(speed.ToString());
            float rotation = - Input.GetAxis("Horizontal") / 40;

            if (speed != 0) {
                dir = RotateVector2d(dir, rotation).normalized;
            }

            this.transform.LookAt(this.transform.position + dir);
            steering.linear = dir * speed;

            steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, agent.maxAccel));

        }
        else if ((int) inputKeyboard == 1)
        {
            //float speed = Input.GetAxis("VerticalWASD") * agent.maxAccel;
            //PARALYZED
            float speed;
            if (isParalyzed && paralyzedTime > 0) {
                paralyzedTime -= 1;
                speed = 0;
                Debug.Log("Timer 2: "+paralyzedTime);
                if (paralyzedTime < 0) {
                    isParalyzed = false;
                }
            } else {
                speed = Input.GetAxis("VerticalWASD") * agent.maxAccel;
            }
            float rotation = -Input.GetAxis("HorizontalWASD") / 20;


            if (speed != 0)
            {
                dir = RotateVector2d(dir, rotation).normalized;
            }
            //ADD INERTIA !!!
            this.transform.LookAt(this.transform.position + dir);
            steering.linear = dir * speed;

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

                    if (isParalyzed && paralyzedTime > 0) {
                        paralyzedTime -= 1;
                        direction = Vector3.zero;
                        Debug.Log("PARALYZED");
                    if (paralyzedTime < 0) {
                        isParalyzed = false;
                    }
                }

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
            //Debug.Log(steering.linear.ToString());
        }

        return steering;
    }


    private Vector3 RotateVector2d(Vector3 dir, float rad)
    {
        Vector3 result = new Vector3(0, 0, 0);
        result.x = dir.x * (float) Math.Cos(rad) - dir.z * (float) Math.Sin(rad);
        result.z = dir.x * (float) Math.Sin(rad) + dir.z * (float) Math.Cos(rad);
        return result;
    }



    public void Paralyze() {
        if (isParalyzed == false) {
            isParalyzed = true;
        } else if (isParalyzed == true) {

        }
        Debug.Log("Paralyzed: "+ isParalyzed);
        paralyzedTime = paralysisTime;
    }

    public Vector3 getPosition() {
        return this.transform.position;
    }
}
