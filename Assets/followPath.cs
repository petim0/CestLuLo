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
    }

}
