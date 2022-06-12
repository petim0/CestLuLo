using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class followPath : MonoBehaviour
{

    public CpScript[] cps;
    UnityEngine.AI.NavMeshAgent agent;
    
    private const int paralysisTime = 200;
    private int paralysisToSpend;
    private int currentTarget;
    private int DISTANCE_DECALAGE_HUILE = 10;
    private bool waitingOndropMoment = false;
    public bool testing = false;


    //Weapon stuff
    public Weapon weapon;
    public DizzyWeapon dizzyWeapon;
    public OilWeapon oilWeapon;
    public Inventory inventory;

    // Start is called before the first frame update
    private void Start()
    {
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = PersistentManagerScript.Instance.AiSpeed;
        agent.baseOffset = 0.255f;
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

    public void Slide(Vector3 posMiddleFlaque)
    {
        //Debug.Log("Oh no I found oil, the american will come !");
        //ça peu créer des problèmes ça genre ça reste bloqué
        agent.SetDestination(this.gameObject.transform.position + (posMiddleFlaque -this.transform.position) * (float) 2.5);
        
    }

    public void StopSliding()
    {
        //Get it back to normal
        agent.SetDestination(cps[currentTarget].transform.position);
    }

    private bool moveToDropOil() {
        //ça peu créer des problèmes ça genre c'est trop loin

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, Mathf.Infinity))
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit.distance, Color.red, 1);
            if (hit.distance >= 3 && (hit.transform.CompareTag("Wall") || hit.transform.CompareTag("Wall2"))) {
                
                //Debug.Log("Did Hit");
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit.distance, Color.red, 100);
                agent.SetDestination(transform.position + transform.TransformDirection(Vector3.left) * DISTANCE_DECALAGE_HUILE);
                return true;
            }

            return false;

        }
        else
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red, 4);
            //Debug.Log("Did not Hit");
            return false;
        }
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


        //Faire ces calcules seulement si il a un item !
        
        if (inventory.inventory.Count > 0)
        {
            InventoryItem item = inventory.inventory[0];

            //SI il a une bullet
            if (item.itemData.displayName == "Para")
            {
                if (item.stackSize > 0)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
                    {
                        if (hit.transform.CompareTag("Player1") || hit.transform.CompareTag("Player2"))
                        {
                            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.black);
                            //Debug.Log("Did Hit");
                            //Il la tire 
                            weapon.isFiring = true;
                            inventory.Remove(item.itemData);
                        }

                    }
                    else
                    {
                        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red, 1);
                        //Debug.Log("Did not Hit");
                    }

                    
                    
                }
            }
            else if (item.itemData.displayName == "Oil")
            {
                if (item.stackSize > 0)
                {
                    if (!waitingOndropMoment && moveToDropOil())
                    { 
                        waitingOndropMoment = true;
                    }

                    if (waitingOndropMoment)
                    {
                        if (!agent.pathPending && !agent.hasPath)
                        {
                            Debug.Log("I have reached my destination!");
                            //remplacer testing par l'huile et drop l'huile !!
                            inventory.Remove(item.itemData);
                            agent.SetDestination(cps[currentTarget].transform.position);
                            oilWeapon.isFiring = true;
                        }
                }
            }
            else if (item.itemData.displayName == "Dizzy")
            {
                if (item.stackSize > 0)
                {
                    dizzyWeapon.isFiring = true;
                    inventory.Remove(item.itemData);
                }
            }
        }
          
        }
    }

}
