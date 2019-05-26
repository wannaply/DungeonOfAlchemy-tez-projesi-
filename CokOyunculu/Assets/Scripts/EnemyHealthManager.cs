using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyHealthManager : NetworkBehaviour {

    public int MaxHp;
    public int currentHp;

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
            Destroy(gameObject);
        }

    }

    public void HurtEnemy(int damage)
    {
        currentHp -= damage;
    }
    public void SetMaxHp()
    {
        currentHp = MaxHp;
    }
}
