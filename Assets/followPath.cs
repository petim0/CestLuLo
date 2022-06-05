using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPath : MonoBehaviour
{

    public CpScript[] cps;
    UnityEngine.AI.NavMeshAgent agent;
    private const int paralysisTime = 200;
    private int paralysisToSpend;
    private int currentTarget;



    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        currentTarget = 0;
        //Debug.Log("Starting target:" + cps[currentTarget].ToString());
        //Debug.Log("Nb of target:" + cps.Length);
        gotToWayPoint(0);
        
    }

    public CpScript getCurrentTarget() {
        return cps[currentTarget];
    }

    public void gotToWayPoint(int i) {
        currentTarget = i;
        agent.SetDestination(cps[i].transform.position);
    }

    public void goToNextWayPoint() {
        int next = (currentTarget + 1) == cps.Length ? 0 : currentTarget + 1;
        
        //Debug.Log("Next target:" + cps[next].ToString());
        gotToWayPoint(next);
    }

    public void Paralyze() {
        agent.isStopped = true;
        paralysisToSpend = paralysisTime;
    }

    private void Update()
    {
        if (paralysisToSpend > 0)
        {
            paralysisToSpend -= 1;
        }
        else if (paralysisToSpend == 0) {
            agent.isStopped = false;
        }


        //Faire ces calcules seulement si il a un item !
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.transform.CompareTag("Player1") || hit.transform.CompareTag("Player2")) {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.black);
                Debug.Log("Did Hit");
            }
                
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
            Debug.Log("Did not Hit");
        }
    }

}
