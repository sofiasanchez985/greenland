using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class transferownership : MonoBehaviourPunCallbacks
{

    public static GameObject LocalPlayer;
    public GameObject pickup;

    //Start is called before the first frame update
    void Start()
    {
        //Debug.Log(PhotonNetwork.LocalPlayer.ActorNumber);
    }

    ////// Update is called once per frame
    void Update()
    {
        if (pickup.GetComponent<PhotonView>().IsMine)
        {
            //Debug.Log("HIII");
        }
        else
        {
            //Debug.Log("Hummm");
            pickup.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);
        }
    }
}
