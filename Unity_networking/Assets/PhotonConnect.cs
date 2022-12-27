using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PhotonConnect : MonoBehaviour
{
    public string versionName = "0.1";
    public GameObject ConnectingPanel, ConnectedPanel, DisconectPanel;
    [SerializeField]
    private List<RoomInfo> roomList;


    public void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(versionName);
        Debug.Log("Connecting To Photon...");

    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("We are connevcted to photon Mater");
    }
    private void OnJoinedLobby()
    {
        ConnectedPanel.SetActive(true);
        ConnectingPanel.SetActive(false);
    }

    private void OnDisconnectedFromPhoton()
    {
        if (ConnectingPanel.active == true)
            ConnectingPanel.SetActive(false);
        if (ConnectedPanel.active == true)
            ConnectedPanel.SetActive(false);
        DisconectPanel.SetActive(true);
    }
    private void OnFailedToConnectToPhoton()
    {

    }
    public void RefreshRoomListings()
    {
        roomList = new List<RoomInfo>(PhotonNetwork.GetRoomList());

        /* Temp, should not be in charge of UI here. */
        Debug.Log("Located " + roomList.Count + " rooms.");
        for (int i = 0; i < roomList.Count; i++)
        {
            // Text btnText = GameObject.Instantiate(m_uiListRoomBtn, new Vector3(0.0f, 15.0f * i, 0.0f), Quaternion.identity, m_contentParent.transform).GetComponentInChildren<Text>();
            // btnText.text = roomList[i].Name;
            Debug.Log("Server: " + roomList[i].Name);
        }
    }

    public void OnReceivedRoomListUpdate()
    {
        Debug.Log("Room list received.");
        RefreshRoomListings();
    }

    private void Update()
    {
        //  OnReceivedRoomListUpdate();
        /*
        foreach (RoomInfo game in PhotonNetwork.GetRoomList())
        {
            Debug.Log(game.name);
            Debug.Log(game.PlayerCount);
            Debug.Log(game.MaxPlayers);
        }
        */
    }
}
