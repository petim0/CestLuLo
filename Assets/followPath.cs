using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPath : MonoBehaviour
{

    public CpScript[] cps;
    UnityEngine.AI.NavMeshAgent agent;
    private const int paralysisTime = 200;
    private int paralysisToSpend;



    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        gotToWayPoint(0);
        
    }

    public void gotToWayPoint(int i) {

        agent.SetDestination(cps[i].transform.position);
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
