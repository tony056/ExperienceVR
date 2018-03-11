using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARPlayerManager : Photon.MonoBehaviour 
{

    public GameObject playerCamera;

	// Use this for initialization
	void Start () {
		if(playerCamera != null)
        {
            if (!photonView.isMine)
            {
                playerCamera.SetActive(false);
            }
        } 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
