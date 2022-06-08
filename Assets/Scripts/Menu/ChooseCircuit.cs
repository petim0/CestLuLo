using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class ChooseCircuit : MonoBehaviour
{

    public List<GameObject> Children;



    public void Start()
    {

        if (PersistentManagerScript.Instance.isVirtual)
        {
            foreach (GameObject child in Children)
            {
                MeshRenderer m = child.GetComponent<MeshRenderer>();
                if (child.tag == "Wall")
                {
                    m.enabled = false;
                }
                else if (child.tag == "Tree")
                {
                    child.SetActive(false);
                }
            }
        }
    }

}
