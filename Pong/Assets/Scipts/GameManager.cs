using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{   
    public GameObject Canvas;
    public GameObject gameToEnable;

    
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom("Test");
        Debug.Log("Room Created");
        Canvas.SetActive(false);
        gameToEnable.SetActive(true);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom("Test");
        Debug.Log("Conntected to Room");
        Canvas.SetActive(false);
        gameToEnable.SetActive(true);
    }
}
