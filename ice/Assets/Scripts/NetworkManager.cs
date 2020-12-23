using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviour, IConnectionCallbacks, IMatchmakingCallbacks, IOnEventCallback
{
    public const byte InstantiateVrAvatarEventCode = 1; // example code, change to any value between 1 and 199

    [SerializeField]
    private string roomName = "oculusPhotonRoom"; // example dummy room name, you can skip using a hardcoded name altogether

    private void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    private void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    #region IConnectionCallbacks


    void IConnectionCallbacks.OnConnected()
    {
    }

    void IConnectionCallbacks.OnConnectedToMaster()
    {
        // this is an example of how to join a room quickly
        // use any of the other available matchmaking ways to join rooms
        PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions(), TypedLobby.Default);
    }

    void IConnectionCallbacks.OnDisconnected(DisconnectCause cause)
    {
    }

    void IConnectionCallbacks.OnRegionListReceived(RegionHandler regionHandler)
    {
    }

    void IConnectionCallbacks.OnCustomAuthenticationResponse(Dictionary<string, object> data)
    {
    }

    void IConnectionCallbacks.OnCustomAuthenticationFailed(string debugMessage)
    {
    }

    #endregion

    #region IMatchmakingCallbacks

    void IMatchmakingCallbacks.OnJoinedRoom()
    {
        GameObject localAvatar = Instantiate(Resources.Load("LocalAvatar")) as GameObject;
        PhotonView photonView = localAvatar.GetComponent<PhotonView>();

        if (PhotonNetwork.AllocateViewID(photonView))
        {
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions
            {
                CachingOption = EventCaching.AddToRoomCache,
                Receivers = ReceiverGroup.Others
            };

            PhotonNetwork.RaiseEvent(InstantiateVrAvatarEventCode, photonView.ViewID, raiseEventOptions, SendOptions.SendReliable);
        }
        else
        {
            Debug.LogError("Failed to allocate a ViewId.");

            Destroy(localAvatar);
        }
    }

    void IMatchmakingCallbacks.OnFriendListUpdate(List<FriendInfo> friendList)
    {
    }

    void IMatchmakingCallbacks.OnCreatedRoom()
    {
    }

    void IMatchmakingCallbacks.OnCreateRoomFailed(short returnCode, string message)
    {
    }

    void IMatchmakingCallbacks.OnJoinRoomFailed(short returnCode, string message)
    {
    }

    void IMatchmakingCallbacks.OnJoinRandomFailed(short returnCode, string message)
    {
    }

    void IMatchmakingCallbacks.OnLeftRoom()
    {
    }

    #endregion

    void IOnEventCallback.OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code == InstantiateVrAvatarEventCode)
        {
            GameObject remoteAvatar = Instantiate(Resources.Load("RemoteAvatar")) as GameObject;
            PhotonView photonView = remoteAvatar.GetComponent<PhotonView>();
            photonView.ViewID = (int)photonEvent.CustomData;
        }
    }

}