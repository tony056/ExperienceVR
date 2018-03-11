using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class PhotonCommsManager : Photon.PunBehaviour {

    private GameObject currentPlayer;

    void Start()
    {
        PhotonNetwork.logLevel = PhotonLogLevel.Full;
        PhotonNetwork.ConnectUsingSettings("0.1");
    }

    /////////////////////// Photon Methods  ///////////////////////

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        // instantiate user avatar locally and spawns in remote instances
        if (PhotonNetwork.isMasterClient)
        {
            initNonVRPlayer();
        }
        else
        {
            
            initVRPlayer();
        }
        
    }

    // This is called if there is no one playing or if all rooms are full, so create a new room
    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Can't join random room!");
        PhotonNetwork.CreateRoom(null);
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    private void initVRPlayer()
    {
        currentPlayer = PhotonNetwork.Instantiate("Player", new Vector3(0, 1.6f, 0), Quaternion.identity, 0);
        currentPlayer.GetComponent<PlayerController>().isControllable = true;
		Debug.Log ("attend as server");
    }

    private void initNonVRPlayer()
    {
        currentPlayer = PhotonNetwork.Instantiate("PCPlayer", new Vector3(0, 1.6f, 2), Quaternion.Euler(-Quaternion.identity.eulerAngles), 0);
		Debug.Log ("attend as client");
        //Quaternion oppositeDirection = Quaternion.Euler(-currentPlayer.transform.rotation.eulerAngles);
        //currentPlayer.transform.rotation = oppositeDirection;
    }
}
