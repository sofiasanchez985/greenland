using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class testconnect : MonoBehaviourPunCallbacks
{
    //// Start is called before the first frame update
    void Start()
    {
        print("Connecting to server....");
        PhotonNetwork.GameVersion = "0.0.1";
        PhotonNetwork.ConnectUsingSettings();

    }
    public override void OnConnectedToMaster()
    {
        print("Connected to server!");
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        //base.OnDisconnected(cause);
        print("Disconnected from server" + cause.ToString());
    }
}
