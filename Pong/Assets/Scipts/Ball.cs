using UnityEngine;
using Photon.Pun;
public class Ball : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed = 15;
    bool isStart;
    [SerializeField] GameObject scoreBoard;
    ScoreBoard scoreBoardScript;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        scoreBoardScript = scoreBoard.GetComponent<ScoreBoard>();
        
        

    }
    void Update()
    {   
        //ball is only executed by the master client
        if(PhotonNetwork.IsMasterClient)
        {   
            //the game starts when there are 2 players in the room
            if(PhotonNetwork.CurrentRoom.PlayerCount == 2 && !isStart)
            {
                isStart = true;
                Debug.Log("Update");
                GoBall();
            }
        }
    }
     void OnCollisionEnter2D(Collision2D coll){
        //ball is only executed by the master client
        if(!PhotonNetwork.IsMasterClient)
            return;
        // every time the ball hits the player the ball goes faster and the ball can give the ball a cut
        if(coll.collider.CompareTag("Player")){
            Vector2 vel;
            vel.x = 1.2f*(rb2d.velocity.x);
            vel.y = rb2d.velocity.y;
            rb2d.velocity = vel;
            Debug.Log("Player");
        }
        //if a player scores the ball is reseted and the scoreboard is Ubdated
        if(coll.collider.CompareTag("RightWall"))
        {   
            scoreBoardScript.Score("Right");
            ResetBall();
        }if(coll.collider.CompareTag("LeftWall"))
        {
            scoreBoardScript.Score("Left");
            ResetBall();
        }
    }
    void GoBall(){
        float rand = Random.Range(0, 2);
        if(rand < 1){
        rb2d.AddForce(new Vector2(-speed, -15));
        } else {
        rb2d.AddForce(new Vector2(speed, 15));
        }
    }
    void ResetBall(){
        rb2d.velocity = Vector2.zero;
        gameObject.transform.position = new Vector3(0,0,1);
        GoBall();
    }



}
