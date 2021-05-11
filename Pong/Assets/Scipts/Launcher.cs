using UnityEngine;
using Photon.Pun;
public class Launcher :  MonoBehaviourPunCallbacks
{
    public static Launcher Instance;
    [SerializeField] GameObject PlayerPrefab;
    [SerializeField] GameObject MultiplayerPrefab;

 
    //connecting to Photon
    void Start()
    {   
        Instance = this;
        PhotonNetwork.ConnectUsingSettings();
    }
    //spawn player at different positions  depending on the players allready in the room 
     public override void OnJoinedRoom()
    {
        Instantiate(MultiplayerPrefab);
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
