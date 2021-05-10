using UnityEngine;
using Photon.Pun;
using System.Collections.Generic;
using Photon.Realtime;
using TMPro;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance;
    [SerializeField] Transform roomListContent;
    [SerializeField] GameObject roomListTiemPrefab;
    [SerializeField] TMP_InputField RoomName;
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
        if(RoomName.text != null)
        {
            RoomOptions options = new RoomOptions();
            options.MaxPlayers = 2;
          

            PhotonNetwork.JoinOrCreateRoom(RoomName.text, options, null);
            
        }

    }
    public override void OnCreatedRoom()
    {
        Debug.Log("RoomCreated");
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("RoomCreatedUbdate");
        foreach(Transform trans in roomListContent)
        {
            Destroy(trans.gameObject);
        }
        for(int i = 0; i < roomList.Count; i++)
        {
            Instantiate(roomListTiemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
        }
    }

}
