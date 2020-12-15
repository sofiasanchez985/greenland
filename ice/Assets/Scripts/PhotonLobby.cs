using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public static PhotonLobby lobby;
    public GameObject startButton;
    public GameObject cancellButton;
    private void Awake()
    {
        lobby = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        print("Connecting to server....");
        PhotonNetwork.ConnectUsingSettings(); //connect to master photon server
    }
    public override void OnConnectedToMaster()
    {
        print("Connected to server!");
        startButton.SetActive(true);
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconnected from server" + cause.ToString());
    }

    public void OnStartButtonClick()
    {
        startButton.SetActive(false);
        cancellButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        print("Faied to join random room, no room available :(");
        CreateRoom();
    }
    void CreateRoom()
    {
        int randomRoomName = Random.Range(0, 10);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 2 };
        PhotonNetwork.CreateRoom("Room" + randomRoomName, roomOps);
        print("Created a new room.");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print("Faied to create room :(");
        CreateRoom();
    }
    public override void OnJoinedRoom()
    {
        print("You are now in a room!!!");
    }
    public void OnCancellButtonClick()
    {
        startButton.SetActive(true);
        cancellButton.SetActive(false);
        PhotonNetwork.LeaveRoom();
        print("You leaft teh room.");
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
