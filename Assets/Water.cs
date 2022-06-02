using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //faire en sorte que la flaque disaparaisse ?

    // Update is called once per frame
    void Update()
    {
        
    }

    void onTriggerEnter(CelluloAgent cellulo){ //cellulo.moveOnIce(); 
    }

    void changePlace(){
        //activer une deuxieme flaque et faire disparaitre celle là, comment ?

/*
        float x = Random.Range(spawnzone.GetComponent<BoxCollider>().bounds.min.x + 2, spawnzone.GetComponent<BoxCollider>().bounds.max.x - 2);
        float z = Random.Range(spawnzone.GetComponent<BoxCollider>().bounds.min.z + 2, spawnzone.GetComponent<BoxCollider>().bounds.max.z - 2);
        this.transform.position = new Vector3(x, 1, z);
        Instantiate(gems, position, transform.rotation);*/

    }

}
