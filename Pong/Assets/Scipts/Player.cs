using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviour
{
    [SerializeField] PhotonView photonView;
    [SerializeField] int moveSpeed = 100;
    [HideInInspector]public Vector2 currentSpeed;
    Vector3 move;
    void Update()
    {
        //if is localplayer
        if (photonView.IsMine)
        {
          
            CheckInput();
        }
        else
        {
            Destroy(GetComponent<Rigidbody2D>());
        }
    }
    public void CheckInput()
    {   
        //movement if Paddle is in gamefield
        if(this.transform.position.y <= 4.2 && this.transform.position.y >= -4.2)
        {
            move = new Vector3(0,Input.GetAxisRaw("Vertical"),0);
            transform.position += move * moveSpeed * Time.deltaTime;
            //just because the ball script needs the currentspeed
            currentSpeed = (move * moveSpeed * Time.deltaTime)*100;
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


