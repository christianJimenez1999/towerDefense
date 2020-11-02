using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
  //inserts waypoints into an array in order 
  public Waypoints[] navPoints;
  private Transform target;
  private Vector3 direction;
  public float amplify = 1f;
  private float Lamplify = 1.5f;
  private int index = 0;
  private int Lindex = 0;
  private bool move = true;
  private bool Lmove = true;
  private float smallHealth = 100;
  private float largeHealth = 200;
  public purse purse;
  //public Slider healthbar;
  //public Transform enemy;
  
  
    
    // Start is called before the first frame update
  void Start()
  {
    //Place our enemy at the start point
    //starting point at the first waypoint
    transform.position = navPoints[index].transform.position;
    NextWaypoint();
    
    
    //Move towards the next waypoint
    //Retarget to the following waypoint when we reach our current waypoint
    //Repeat through all of the waypoints until you reach the end
  }

  // Update is called once per frame
  void Update()
  {
        if (this.gameObject.tag == "smallEnemy")
        {
            if (move)
            {
                //starts moving enemy towards last waypoint
                transform.Translate(direction.normalized * Time.deltaTime * amplify);

                //checks for next waypoint and moves enemy in that direction
                //<.1f == how close it gets to the waypoint
                if ((transform.position - target.position).magnitude < .1f)
                {
                    NextWaypoint();
                }
            }
        }

        if (this.gameObject.tag == "largeEnemy")
        {
            if (Lmove)
            {
                //starts moving enemy towards last waypoint
                transform.Translate(direction.normalized * Time.deltaTime * Lamplify);

                //checks for next waypoint and moves enemy in that direction
                //<.1f == how close it gets to the waypoint
                if ((transform.position - target.position).magnitude < .1f)
                {
                    NextWaypoint();
                }
            }
        }


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray , out hit, 100))
            {
                if(hit.collider.tag == "largeEnemy")
                {
                    largeHealth -= 50;
                    if(largeHealth <= 0)
                    {
                        Debug.Log("large enemy has been destroyed.");
                        purse.killLarge();
                        Destroy(hit.collider.gameObject);
                    }
                    //healthbar.value = smallHealth;
                }
            }

            if (hit.collider.tag == "smallEnemy")
            {
                smallHealth -= 50;
                if (smallHealth <= 0)
                {
                    Debug.Log("small enemy has been destroyed.");
                    //GameObject.Find("smallEnemy").GetComponent<Enemy>().smallDestroy();
                    purse.killedSmall();
                    Destroy(hit.collider.gameObject);
                }
            }

            if (hit.collider.tag == "tower1")
            {
                if (purse.purchTower() == true)
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
                }
            }

        }


    }

  private void NextWaypoint()
  {

        if (this.gameObject.tag == "smallEnemy")
        {
            //checks its withing waypoint boundaries so it wont hit the last number because the last weypoint is the size of the array minus 1
            if (index < navPoints.Length - 1)
            {
                index += 1;
                target = navPoints[index].transform;
                direction = target.position - transform.position;
            }
            else
            {
                //if index is at 10 or higher stop the enemy from moving because it has reached the end
                move = false;
            }

        }

        if (this.gameObject.tag == "largeEnemy")
        {
            //checks its withing waypoint boundaries so it wont hit the last number because the last weypoint is the size of the array minus 1
            if (Lindex < navPoints.Length - 1)
            {
                Lindex += 1;
                target = navPoints[Lindex].transform;
                direction = target.position - transform.position;
            }
            else
            {
                //if index is at 10 or higher stop the enemy from moving because it has reached the end
                Lmove = false;
            }

        }

    }


}
