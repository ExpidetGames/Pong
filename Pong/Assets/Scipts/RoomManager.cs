using UnityEngine;
using Photon.Pun;
using System.Collections.Generic;
using Photon.Realtime;
using TMPro;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance;
    [SerializeField] Transform roomListContent;
    [SerializeField] GameObject roomListtIemPrefab;
    [SerializeField] TMP_InputField RoomName;
    void Awake()
    {   
        Instance = this;
        PhotonNetwork.JoinLobby();
    }
    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        MenuManager.Instance.OpenMenu("Game");
    }
    public void CreateOrJoinRoom()
    {
        PhotonNetwork.CreateRoom(RoomName.text);
        MenuManager.Instance.OpenMenu("Game");
    }
   
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("Ubdate");   
		for(int i = 0; i < roomList.Count; i++)
		{
            Debug.Log(roomList[i].Name);
            
            Debug.Log(i);
            //Remove from List
			if(roomList[i].RemovedFromList)
            {   
                foreach(Transform child in roomListContent.transform)
                {
                    if(roomList[i].Name == child.GetComponent<RoomListItem>().text.text)
                    {
                        Destroy(child.gameObject);
                    }
                }   
            }
            //Add to List
            else
            {
			    Instantiate(roomListtIemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
            }
		}

    }

}
