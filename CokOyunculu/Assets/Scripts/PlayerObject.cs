using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PlayerObject : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        //CmdSpawnEnemy();
        if (isLocalPlayer == true)
            playerCamera.SetActive(true);
        else
            playerCamera.SetActive(false);

        if (isLocalPlayer == false)
        {
            return;
        }
        if (PlayerPrefs.GetInt("CharacterSelected") == 0)
        {
            CmdSpawnMyUnit0();
        }
        if (PlayerPrefs.GetInt("CharacterSelected") == 1)
        {
            CmdSpawnMyUnit1();
        }
        if (PlayerPrefs.GetInt("CharacterSelected") == 2)
        {
            CmdSpawnMyUnit2();
        }



    }
    public GameObject Enemy;
    public GameObject PlayerUnitPrefab0;
    public GameObject PlayerUnitPrefab1;
    public GameObject PlayerUnitPrefab2;

    public GameObject playerCamera;
    //public GameObject Camera;
	// Update is called once per frame
	void Update () {
        if (isLocalPlayer == true)
            playerCamera.SetActive(true);
        else
            playerCamera.SetActive(false);
    }
    //GameObject myPlayerUnit;
    [Command]
    void CmdSpawnMyUnit0()
    {
        
            GameObject go0 = Instantiate(PlayerUnitPrefab0);
            NetworkServer.SpawnWithClientAuthority(go0, connectionToClient);
      
        //myPlayerUnit = go;
        //NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
        //NetworkServer.Spawn(go);
    }
    [Command]
    void CmdSpawnMyUnit1()
    {
        

            GameObject go1 = Instantiate(PlayerUnitPrefab1);
            NetworkServer.SpawnWithClientAuthority(go1, connectionToClient);
        
        //myPlayerUnit = go;
        //NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
        //NetworkServer.Spawn(go);
    }
    [Command]
    void CmdSpawnMyUnit2()
    {

        GameObject go2 = Instantiate(PlayerUnitPrefab2);
        NetworkServer.SpawnWithClientAuthority(go2, connectionToClient);

        //myPlayerUnit = go;
        //NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
        //NetworkServer.Spawn(go);
    }
    /*[Command]
    void CmdSpawnEnemy()
    {
        GameObject go = Instantiate(Enemy);
        NetworkServer.Spawn(go);
        Debug.Log("olley bee");

    }*/
}
