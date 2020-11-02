using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class purse : MonoBehaviour
{
    
    public Text score;
    int current = 1000;


    // Start is called before the first frame update
    void Start()
    {
        score.color = Color.white;
        score.text = "currency " + '\n' + "  " + current.ToString("$0000");
        
    }

    public void killedSmall()
    {
        current += 50;
        showCurrent();
    }

    public void killLarge()
    {
        current += 100;
        showCurrent();
    }

    public bool purchTower()
    {
        Debug.Log("hi " + current);
        if(current - 150 >= 0)
        {
            current = current - 150;
            showCurrent();
            return true;

            
        }
        else
        {
            Debug.Log(current);
            insufficient();
            return false;
        }
        return false;
    }

    public bool purchMedium()
    {
        if (current - 250 <= 0)
        {
            insufficient();
            return false;

        }
        else
        {
            current = current - 250;
            showCurrent();
            return true;

        }
    }

    public bool purchCircle()
    {
        if (current - 350 <= 0)
        {
            insufficient();
            return false;
        }
        else
        {
            current = current - 350;
            showCurrent();
            return true;
        }
    }

    public bool purchBig()
    {
        if (current - 450 <= 0)
        {
            insufficient();
            return false;
        }
        else
        {
            current = current - 450;
            showCurrent();
            return true;
        }
    }

    public bool purchBiggest()
    {
        if (current - 700 <= 0)
        {
            insufficient();
            return false;
        }
        else
        {
            current = current - 700;
            showCurrent();
            return true;
        }
    }

    public void showCurrent()
    {
        score.text = "currency " + '\n' + current.ToString("$0000");
    }

    public void insufficient()
    {
        score.text = "insufficient " + '\n' + current.ToString("$0000");
    }

}
