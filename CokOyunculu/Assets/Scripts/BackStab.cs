﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BackStab : NetworkBehaviour
{

    [SyncVar]public int damage;
    public GameObject damageBurst;
    public Transform hitPoint;
   
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Vector3 toTarget = (collision.gameObject.transform.position - transform.position).normalized;
            if(Vector3.Dot(toTarget, transform.right) <0)
            {
                collision.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damage*2);
                Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
                if (collision.gameObject.GetComponent<EnemyHealthManager>().currentHp <= 0)
                {
                    damage += 2;
                }
            }
            if (Vector3.Dot(toTarget, transform.right) > 0)
            {
                collision.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damage);
                Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
                if (collision.gameObject.GetComponent<EnemyHealthManager>().currentHp <= 0)
                {
                    damage += 2;
                }
            }


        }

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damage);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);

        }
    }
    private void OnGUI()
    {

        //GUI.Label(new Rect((Screen.width - 100), 25, 100, 20), "DMG: " + damage.ToString());








    }

}
