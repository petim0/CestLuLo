using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    public float bulletLifetime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        bulletLifetime -= Time.deltaTime;
        if (bulletLifetime < 0) {
            Destroy(gameObject);
        }
    }


    public void OnCollisionEnter(Collision other) {
        string tag = other.gameObject.tag;
        if (tag == "Player1" || tag == "Player2")
        {
            other.gameObject.GetComponent<PlayerEffectsManager>().ParalyzePlayer();
            Destroy(gameObject);
        }
        else if (tag == "Player3")
        {
            other.gameObject.GetComponent<followPath>().Paralyze();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
