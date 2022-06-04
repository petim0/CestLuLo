using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CpScript : MonoBehaviour
{
    public SceneManagerCestlulo sceneManager;
    public int CpNb;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(this.ToString());
        sceneManager.passed(other.transform.parent.tag, CpNb);

     }

    public Vector3 getPosition() {
        return this.transform.position;
    }
}
