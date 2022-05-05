using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject spawnzone;
    public GameObject gems;
    public float spawnTime;        
    public float spawnDelay;
    public AudioClip audioSpawn;
    AudioSource aud;

    //Auxiliary method because we want to use it for CollectorGem and it doesn't work if we add an AudioSource to CollectorGem
    public void PlayAud()
    {
        aud = GetComponent<AudioSource>();
        aud.PlayOneShot(audioSpawn, 0.7F);

    }

    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay,spawnTime);        
    }

    void Spawn()
    {
        PlayAud();
        float x = Random.Range(spawnzone.GetComponent<BoxCollider>().bounds.min.x + 2, spawnzone.GetComponent<BoxCollider>().bounds.max.x - 2);
        float z = Random.Range(spawnzone.GetComponent<BoxCollider>().bounds.min.z + 2, spawnzone.GetComponent<BoxCollider>().bounds.max.z - 2);
        Vector3 position = new Vector3(x, 1, z);
        Instantiate(gems, position, transform.rotation);
    }



} 
 


