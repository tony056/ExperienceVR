using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkObject : Photon.MonoBehaviour {

    private Vector3 correctPlayerPos;
    private Quaternion correctPlayerRot = Quaternion.identity; // We lerp towards this

    void Start()
    {

    }

    void Update()
    {

        // Check to see if this NetworkObject is the owned by the current instance
        if (!photonView.isMine)
        {
            // Lerping smooths the movement
            transform.position = Vector3.Lerp(transform.position, this.correctPlayerPos, Time.deltaTime * 5);
            //otherPlayerHead.transform.rotation = Quaternion.Lerp(otherPlayerHead.transform.rotation, this.correctPlayerRot, Time.deltaTime * 5);
            transform.rotation = Quaternion.Lerp(transform.rotation, this.correctPlayerRot, Time.deltaTime * 5);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            // We own this player: send the others our data
            Vector3 pos = transform.localPosition;
            Quaternion rotation = Quaternion.identity;
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);

        }
        else
        {
            // Network player, receive data
            this.correctPlayerPos = (Vector3) stream.ReceiveNext();
            this.correctPlayerRot = (Quaternion) stream.ReceiveNext();
        }
    }

    // OTHER PLAYER HAND CONTROLLER UPDATE
    //[PunRPC]
    //void UpdateOtherPlayerController(Vector3 pos, Quaternion rot)
    //{
        //otherPlayerController.transform.localRotation = rot;
        //otherPlayerController.transform.localPosition = Vector3.Lerp(otherPlayerController.transform.localPosition, pos, Time.deltaTime * 5);
    //}
    
}
