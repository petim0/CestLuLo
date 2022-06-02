using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLLCamera : MonoBehaviour
{
    //ce script va etre attaché à une caméra avec comme target un des cellulos pour qu'elle reste fixé à lui
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
       lateUpdate();
    }

    void lateUpdate(){ //que fait la méthode lookAt
        transform.LookAt(target.transform, Vector3.zero); //camera points to the target et le vecteur nul désigne la direction "haut" (??)
    }




}
