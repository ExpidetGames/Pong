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
    int RoomList_;
    void Awake()
    {
        Instance = this;
    }

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
    }
    public void CreateOrJoinRoom()
    {
     
          

            PhotonNetwork.CreateRoom(RoomName.text);
        MenuManager.Instance.OpenMenu("Game");

    }
    public override void OnCreatedRoom()
    {
        Debug.Log("RoomCreated");
    }
   
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        RoomList_ = roomList.Count;
        Debug.Log("RoomCreatedUbdate");
        foreach(Transform trans in roomListContent)
        {
            Destroy(trans.gameObject);
            Debug.Log("Destroy"+ trans.gameObject.name);
        }
        
		for(int i = 0; i < roomList.Count; i++)
		{
            Debug.Log(i);
			if(roomList[i].RemovedFromList)
				continue;
			Instantiate(roomListtIemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
		}

    }
    void Update()
    {
        Debug.Log(RoomList_);
    }

}
