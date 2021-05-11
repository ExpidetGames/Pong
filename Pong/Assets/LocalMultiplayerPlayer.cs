using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalMultiplayerPlayer : MonoBehaviour
{
    
    [SerializeField] int moveSpeed = 6;
    [HideInInspector]public Vector2 currentSpeed;
    Vector3 move;
    void Update()
    {
        CheckInput();
    }
    public void CheckInput()
    {   
        //movement if Paddle is in gamefield
        if(this.transform.position.y <= 4.2 && this.transform.position.y >= -4.2)
        {
            move = new Vector3(0,Input.GetAxisRaw("Vertical"),0);
            transform.position += move * moveSpeed * Time.deltaTime;
            
        }
        else
        {
        //move the padle only in the direction where it can freely move to
            if(this.transform.position.y >= 4.2 && Input.GetAxisRaw("Vertical") < 0)
            {   
                var move = new Vector3(0, -moveSpeed * Time.deltaTime, 0);
                this.transform.position += move;
            }
            if(this.transform.position.y <= -4.2 && Input.GetAxisRaw("Vertical") > 0)
            {   
                var move = new Vector3(0, moveSpeed * Time.deltaTime, 0);
                this.transform.position += move;
            }
        }
    }
}
