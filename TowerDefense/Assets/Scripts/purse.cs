using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class purse : MonoBehaviour
{

    public Text score;
    int current = 0000;


    // Start is called before the first frame update
    void Start()
    {
        score.color = Color.white;
        score.text = "currency " + '\n' + "  " + current.ToString("0000");

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

    public void showCurrent()
    {
        score.text = "currency " + '\n' + current.ToString("0000");
    }

}
