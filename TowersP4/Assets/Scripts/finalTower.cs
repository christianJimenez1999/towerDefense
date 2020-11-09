using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class finalTower : MonoBehaviour
{
    public int currentHealth = 100;
    private int startingHealth;
    private HealthBar healthBar;
    public GameObject particleEffect;
    private Camera myCamera;

    public GameObject restart;


    // Start is called before the first frame update
    void Start()
    {
        myCamera = GetComponent<Camera>();
        restart.SetActive(false);
        healthBar = GetComponentInChildren<HealthBar>();
        startingHealth = currentHealth;
    }

    public void TakeDamage(int amountDamage)
    {
        currentHealth -= amountDamage;
        if (currentHealth < 0)
        {

            Vector3 xyz = new Vector3(0, -180, 0);
            GameObject particle = Instantiate(particleEffect, transform.position, Quaternion.Euler(xyz));

            
            Destroy(this.gameObject); //Get rid of object
            Destroy(particle, 2f);

           

            if (currentHealth < 0)
            {
                GameObject.FindGameObjectWithTag("final").GetComponent<finalTower>().over();
            }


        }
        else
        {
            healthBar.Damage(currentHealth, startingHealth);
        }
    }

    void over()
     {

        restart.SetActive(true);
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseClick = Input.mousePosition;
            //Debug.Log(mouseClick);

            Ray ray = myCamera.ScreenPointToRay(mouseClick);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "final")
                {
                    Debug.Log("restart");
                    SceneManager.LoadScene("part4");
                }

            }
        }
    }

     

}
