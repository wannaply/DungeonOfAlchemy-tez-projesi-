using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyHealthManager : NetworkBehaviour {

    public int MaxHp;
    [SyncVar]public int currentHp;
    

    // Use this for initialization
    void Start()
    {
        MaxHp = currentHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHp <= 0)
        {
            CmdDestroyEnemy();
        }

    }

    public void HurtEnemy(int damage)
    {
        currentHp -= damage;
    }
    [Command]
    void CmdDestroyEnemy()
    {
        Destroy(gameObject);
    }
}
