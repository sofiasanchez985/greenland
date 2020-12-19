//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Photon.Pun;
//using Photon.Realtime;
//using UnityEngine.SceneManagement;

//public class PhotonLobby1 : MonoBehaviourPunCallbacks
//{
//    public static PhotonLobby lobby;
//    public GameObject startButton;
//    public GameObject cancellButton;
//    private void Awake()
//    {
//        lobby = this;
//    }

//    // Start is called before the first frame update
//    void Start()
//    {
//        Debug.Log("Connecting to server....");
//        PhotonNetwork.ConnectUsingSettings(); //connect to master photon server
//    }
//    public override void OnConnectedToMaster()
//    {
//        Debug.Log("Connected to server!");
//        PhotonNetwork.AutomaticallySyncScene = true;
//        startButton.SetActive(true);
//    }
//    public override void OnDisconnected(DisconnectCause cause)
//    {
//        Debug.Log("Disconnected from server" + cause.ToString());
//    }

//    public void OnStartButtonClick()
//    {
//        startButton.SetActive(false);
//        cancellButton.SetActive(true);
//        PhotonNetwork.JoinRandomRoom();
//    }
//    public override void OnJoinRandomFailed(short returnCode, string message)
//    {
//        Debug.Log("Faied to join random room, no room available :(");
//        CreateRoom();
//    }
//    void CreateRoom()
//    {
//        int randomRoomName = Random.Range(0, 10);
//        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 2 };
//        PhotonNetwork.CreateRoom("Room" + randomRoomName, roomOps);
//        Debug.Log("Created a new room.");
//    }
//    public override void OnCreateRoomFailed(short returnCode, string message)
//    {
//        Debug.Log("Faied to create room :(");
//        CreateRoom();
//    }
//    public override void OnJoinedRoom()
//    {
//        Debug.Log("You are now in a room!!!");
//        SceneManager.LoadScene(1);
//    }
//    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
//    {
//        Debug.Log("You are now entered a room!!!");
//    }
//    public void OnCancellButtonClick()
//    {
//        startButton.SetActive(true);
//        cancellButton.SetActive(false);
//        PhotonNetwork.LeaveRoom();
//        Debug.Log("You leaft teh room.");
//    }


//}