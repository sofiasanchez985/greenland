using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class transferownership : MonoBehaviourPunCallbacks
{


    //private GameObject pickup;

    // Start is called before the first frame update
    //void Start()
    //{

    //}

    ////// Update is called once per frame
    void Update()
    {
        //if (pickup.GetComponent<PhotonView>().IsMine)
        //{
        //    //grabObject(); 
        //}
        //else
        //{
        //    base.photonView.RequestOwnership();
        //    //pickup.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.player.ID);
        //    //grabObject();
        //}
    }

    private void OnTriggerEnter(Collider collider)
    {
        base.photonView.RequestOwnership();
    }
}
