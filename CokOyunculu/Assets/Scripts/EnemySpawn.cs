using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawn : NetworkBehaviour {

    private SlimeController slimeSpawn;
    public GameObject slime;
	// Use this for initialization
	void Start () {
        slimeSpawn = FindObjectOfType<SlimeController>();
        slimeSpawn.transform.position = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
}
