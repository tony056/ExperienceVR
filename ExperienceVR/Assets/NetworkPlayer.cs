using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayer : Photon.MonoBehaviour {

    public GameObject playerController;
    public GameObject playerHead;
    public Camera playerCamera;

    public GameObject otherPlayerHead;
    public GameObject otherPlayerController;
    private Vector3 correctPlayerPos;
    private Quaternion correctPlayerRot = Quaternion.identity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!photonView.isMine)
        {
            playerCamera.enabled = false;
            playerController.SetActive(false);
        } else
        {

        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            // We own this player: send the others our data
            //stream.SendNext(transform.position);
            stream.SendNext(playerCamera.transform.rotation);

            //this.photonView.RPC("UpdateOtherPlayerController", PhotonTargets.Others, playerController.transform.localPosition, playerController.transform.localRotation);
        }
        else
        {
            // Network player, receive data
            //this.correctPlayerPos = (Vector3)stream.ReceiveNext();
            this.correctPlayerRot = (Quaternion)stream.ReceiveNext();
            this.otherPlayerHead.transform.rotation = this.correctPlayerRot;
        }
    }

    // OTHER PLAYER HAND CONTROLLER UPDATE
    /*[PunRPC]
    void UpdateOtherPlayerController(Vector3 pos, Quaternion rot)
    {
        otherPlayerController.transform.localRotation = rot;
        otherPlayerController.transform.localPosition = Vector3.Lerp(otherPlayerController.transform.localPosition, pos, Time.deltaTime * 5);
    }*/


}
