﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A))
			transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * 100.0f, Space.World);
	}
}
