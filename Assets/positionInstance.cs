using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionInstance : MonoBehaviour
{
    //This class is only to get the position of the cellulos, it's
    //  not a good class but it is the only simple way that I can change what I did
    //before whithout having to retest everything
    // this is pure lazyness
    // Do not write anything else in this class

    public Vector3 getPosition()
    {
        return this.transform.position;
    }
}
