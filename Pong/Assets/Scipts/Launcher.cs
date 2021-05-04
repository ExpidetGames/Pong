using UnityEngine;
using Photon.Pun;

public class Launcher :  MonoBehaviourPunCallbacks
{
    public GameObject PlayerPrefab;
    //connecting to Photon
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
    }
    //spawn player at different positions  depending on the players allready in the room 
     public override void OnJoinedRoom()
    {
        SpawnPlayer();
    }
    public void SpawnPlayer()
    {   
        if(PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector2(-8 ,3 ),Quaternion.identity);
        }
        else if(PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector2(8 ,-3 ),Quaternion.identity);
        }
        
        
    }
    
        
}
