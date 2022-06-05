using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CpScript : MonoBehaviour
{
    public SceneManagerCestlulo sceneManager;
    public int CpNb;

    private void OnTriggerEnter(Collider other)
    {
        sceneManager.passed(other.transform.parent.tag, CpNb);
        //Ceci devrai ?tre mis dans le scene manager mais flemme, c'est plus simple ici
        //De plus c'est hard coded du coup c'est pas ouf
        Debug.Log(CpNb.ToString());
        Debug.Log(other.transform.parent.tag);
        if ((CpNb == 0 || CpNb == 3 || CpNb == 5 || CpNb == 7) && other.transform.parent.CompareTag("Player3")) {
            followPath FpScript = other.transform.parent.GetComponent<followPath>();
            if (FpScript.getCurrentTarget() == this) {
                FpScript.goToNextWayPoint();
            }
        }

     }

    public Vector3 getPosition() {
        return this.transform.position;
    }
}
