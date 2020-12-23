using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class playeravatar : MonoBehaviourPunCallbacks
{
    // start is called before the first frame update

    public static GameObject LocalPlayerInstance;

    void start()
    {
        if (photonView.IsMine)
        {
            playeravatar.LocalPlayerInstance = this.gameObject;
        }
        // #Critical
        // we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
        DontDestroyOnLoad(this.gameObject);
    }

    // update is called once per frame
    void update()
    {

    }
}
