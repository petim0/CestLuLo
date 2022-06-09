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
     
    private const int rotationDivider = 20;
    private const int slidingRotationDivider = 1;

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
    
    //SLIDE
    private Steering lastSteering;
    private bool isSliding;
    
    //Control Inversion
    private int invertedTime;
    public bool isInverted;
    private const int inversionTime = 200;


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

        if (isSliding && !isParalyzed) {
            return lastSteering; 
        }

        

        if ((int) inputKeyboard == 0)
        {

            float speed = 0;
            float brakingSpeed = 0;
            bool isGoingForward = lastspeed >= 0 ;

            if (isGoingForward)
            {
                speed = Math.Max(Input.GetAxis("Vertical") * agent.maxAccel, lastspeed - (float)0.1);
                brakingSpeed = BRAKING;

            }
            else {
                //Debug.Log((Input.GetAxis("Vertical") * agent.maxAccel).ToString() + " " + (lastspeed + (float)0.1).ToString());
                //Debug.Log(Math.Min(Input.GetAxis("Vertical") * agent.maxAccel, lastspeed + (float)0.1).ToString());

                //Pas d'inertie en arrière, c'est pas cool pour jouer
                speed = Input.GetAxis("Vertical") * agent.maxAccel;

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
            float rotation;
            int divider = (isSliding && !isParalyzed) ? slidingRotationDivider : rotationDivider;
            if (isInverted && invertedTime > 0) {
                invertedTime -= 1;
                rotation = Input.GetAxis("Horizontal") / divider;
                if (invertedTime < 0) {
                    isInverted = false;
                }
            } else {
                rotation = - Input.GetAxis("Horizontal") / divider;
            }

            if (speed != 0) {
                dir = RotateVector2d(dir, rotation).normalized;
            }

            this.transform.LookAt(this.transform.position + dir);
            steering.linear = dir * speed;

            steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, agent.maxAccel));

        }
        else if ((int) inputKeyboard == 1)
        {
            float speed = 0;
            float brakingSpeed = 0;
            bool isGoingForward = lastspeed >= 0;

            Debug.Log((Input.GetAxis("VerticalWASD") * agent.maxAccel).ToString() + " " + (lastspeed + (float)0.1).ToString());
            Debug.Log(Math.Min(Input.GetAxis("VerticalWASD") * agent.maxAccel, lastspeed + (float)0.1).ToString());

            if (isGoingForward)
            {
                speed = Math.Max(Input.GetAxis("VerticalWASD") * agent.maxAccel, lastspeed - (float)0.1);
                brakingSpeed = BRAKING;

            }
            else
            {
                //Pas d'inertie en arrière, c'est pas cool pour jouer
                speed = Input.GetAxis("VerticalWASD") * agent.maxAccel;

            }


            if (Input.GetAxis("breakWASD") > 0)
            {
                speed = lastspeed - brakingSpeed;
                if ((speed < 0 && isGoingForward) || (speed > 0 && !isGoingForward))
                {
                    speed = 0;
                }
            }

            if (isParalyzed && paralyzedTime > 0)
            {
                paralyzedTime -= 1;
                speed = 0;
                Debug.Log("Timer 2: " + paralyzedTime);
                if (paralyzedTime < 0)
                {
                    isParalyzed = false;
                }
            }


            lastspeed = speed;


            float rotation;
            int divider = (isSliding && !isParalyzed) ? slidingRotationDivider : rotationDivider;
            if (isInverted && invertedTime > 0)
            {
                invertedTime -= 1;
                rotation = Input.GetAxis("HorizontalWASD") / divider;
                if (invertedTime < 0)
                {
                    isInverted = false;
                }
            }
            else
            {
                rotation = -Input.GetAxis("HorizontalWASD") / divider;
            }

            if (speed != 0)
            {
                dir = RotateVector2d(dir, rotation).normalized;
            }

            this.transform.LookAt(this.transform.position + dir);
            steering.linear = dir * speed;

            steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, agent.maxAccel));
        }

        lastSteering = steering;

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
        paralyzedTime = paralysisTime;
    }

    public void Slide() {
        if (isParalyzed == true) {
        } else {
            isSliding = true;
        }
    }

    public void InverseControl() {
        if (isInverted == false) {
            isInverted = true;
        } else if (isInverted == true) {
        }
        invertedTime = inversionTime;
    }
    
    public void StopSliding() {
        isSliding = false;
    }
}
