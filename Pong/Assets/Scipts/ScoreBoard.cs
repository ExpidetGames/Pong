using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public GameObject textLeft;
    public GameObject textRight;
    int textIntLeft;
    int textIntRight;

    //ubdate Scoreboard
    public void Score(string side)
    {
        if(side == "Left")
            {
                textIntRight++;
            }
        else if(side == "Right")
                {
                    textIntLeft++;
                } 
        ubdateScoreBoard();   
    }
    void ubdateScoreBoard()
    {
        textLeft.GetComponent<UnityEngine.UI.Text>().text = textIntLeft.ToString();
        textRight.GetComponent<UnityEngine.UI.Text>().text = textIntRight.ToString();
    }
}
