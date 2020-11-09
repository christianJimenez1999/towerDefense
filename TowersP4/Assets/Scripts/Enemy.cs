using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
  private Waypoints[] navPoints;
  private Transform target;
  private Vector3 direction;
  public float amplify = 1;
  private int index = 0;
  private bool move = true;
  private Purse purse;
  public int currentHealth = 100;
  private int startingHealth;
  public int cashPoints = 100;
  private HealthBar healthBar;
  public GameObject particleEffect;
  public UnityEvent DeathEvent;
  public UnityEvent died;
  private EnemyManager manage;
  int enemyCount;
    private finalTower ftower;
    public GameObject restart;

    // Start is called before the first frame update
    public void StartEnemy(Waypoints[] navigationalPath)
  {
    //    restart.SetActive(false);
    
    navPoints = navigationalPath;
    purse = GameObject.FindGameObjectWithTag("Purse").GetComponent<Purse>();
    ftower = GameObject.FindGameObjectWithTag("final").GetComponent<finalTower>();
    healthBar = GetComponentInChildren<HealthBar>();
    manage = GetComponent<EnemyManager>();
    startingHealth = currentHealth;
    //Place our enemy at the start point
    transform.position = navPoints[index].transform.position;
    NextWaypoint();
    
    //Move towards the next waypoint
    //Retarget to the following waypoint when we reach our current waypoint
    //Repeat through all of the waypoints until you reach the end
  }

  // Update is called once per frame
  void Update()
  {
    if (move)
    {
      transform.Translate(direction.normalized * Time.deltaTime * amplify);

      if ((transform.position - target.position).magnitude < .1f)
      {
        NextWaypoint();
      }
    }

        enemyCount = manage.counter;
        if(enemyCount > 0)
        {
            Debug.Log(enemyCount);
        }
        

    }

    private void NextWaypoint()
  {
    if (index < navPoints.Length - 1)
    {
      index += 1;
      target = navPoints[index].transform;
      direction = target.position - transform.position;

            if(index == navPoints.Length - 1)
            {

                ftower.transform.GetComponent<finalTower>().TakeDamage(100);
            }

    }
    else
    {
      move = false;
    }
  }

  public void TakeDamage(int amountDamage)
  {
    currentHealth -= amountDamage;
    if (currentHealth < 0)
    {
      
      Vector3 xyz = new Vector3(0, -180, 0);
      GameObject particle = Instantiate(particleEffect, transform.position, Quaternion.Euler(xyz));
      
      purse.AddCash(cashPoints); //add cash to purse
      DeathEvent.Invoke();    ///notify towers that I am killed
      Destroy(this.gameObject); //Get rid of object
      Destroy(particle, 2f);
      enemyCount -= 1;
      Debug.Log(enemyCount);  
            

            /*if(enemyCount == 0)
            {
                GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>().over();
            }*/


    }
    else
    {
          healthBar.Damage(currentHealth, startingHealth);
    }
  }

    /*void over()
    {
        restart.SetActive(true);
        Button buttn = restart.GetComponent<Button>();
        buttn.onClick.AddListener(beggin);
    }

    public void beggin()
    {
        SceneManager.LoadScene("part4");
    }*/

}
