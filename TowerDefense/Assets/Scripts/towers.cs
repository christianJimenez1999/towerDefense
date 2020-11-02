using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towers : MonoBehaviour
{
    public purse purse;
    private Renderer render;

    // Start is called before the first frame update
    void Start()
    {
        render = this.gameObject.GetComponent<Renderer>();
        render.material.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.tag == "tower1")
                {
                    if (purse.purchTower() == true)
                    {   
                        hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
                    }
                }
                /*else if (hit.collider.tag == "mediumTower")
                {
                    if (purse.purchMedium())
                    {
                        this.GetComponent<MeshRenderer>().material.color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
                    }

                }
                else if (hit.collider.tag == "circleTower")
                {
                    if (purse.purchCircle())
                    {
                        this.GetComponent<MeshRenderer>().material.color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
                    }
                }
                else if (hit.collider.tag == "bigTower")
                {
                    if (purse.purchBig())
                    {
                        this.GetComponent<MeshRenderer>().material.color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
                    }
                }
                else if (hit.collider.tag == "biggestTower")
                {
                    if (purse.purchBiggest())
                    {
                        this.GetComponent<MeshRenderer>().material.color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
                    }
                }*/
            }
        }

    }

    
}
