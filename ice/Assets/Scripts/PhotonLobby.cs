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

    public GameObject playerPrefab;

    private void Awake()
    {
        lobby = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Connecting to server....");
        PhotonNetwork.ConnectUsingSettings(); //connect to master photon server

        //Instance = this;
        if (playerPrefab == null)
        { // #Tip Never assume public properties of Components are filled up properly, always check and inform the developer of it.

            Debug.Log("Player prefab is not there :(");
        }
        else
        {


            if (playeravatar.LocalPlayerInstance == null)
            {
                // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
            }



        }
        if (playeravatar.LocalPlayerInstance == null)
        {
            //Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
            // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
            PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
        }
 
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to server!");
        startButton.SetActive(true);
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected from server" + cause.ToString());
    }

    public void OnStartButtonClick()
    {
        startButton.SetActive(false);
        cancellButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Faied to join random room, no room available :(");
        CreateRoom();
    }
    void CreateRoom()
    {
        int randomRoomName = Random.Range(0, 10);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 2 };
        PhotonNetwork.CreateRoom("Room" + randomRoomName, roomOps);
        Debug.Log("Created a new room.");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Faied to create room :(");
        CreateRoom();
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("You are now in a room!!!");
    }
    public void OnCancellButtonClick()
    {
        startButton.SetActive(true);
        cancellButton.SetActive(false);
        PhotonNetwork.LeaveRoom();
        Debug.Log("You left the room.");
    }



    // Update is called once per frame
    void Update()
    {

    }
}