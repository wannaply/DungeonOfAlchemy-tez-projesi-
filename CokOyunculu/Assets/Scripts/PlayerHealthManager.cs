using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

    public int MaxHp;
    public int HpPool;
    public int currentHp;
    public float waitToReload;
    private float reloadCounter;
    private bool isDead;
    private soundmanager sman;

	// Use this for initialization
	void Start () {
        HpPool = MaxHp;
        sman = FindObjectOfType<soundmanager>();
	}

	
	// Update is called once per frame
	void Update () {
        MaxHp = currentHp;
        reloadCounter = waitToReload;
        if (isDead)
        {
           
            
            
                
            

               
                isDead = false;

            
        }



    }



    public void HurtPlayer(int damage)
    {
        currentHp -= damage;
        sman.playerHurt.Play();
        if(currentHp <=0)
        {
            sman.playerDead.Play();
            gameObject.SetActive(false);
           
            gameObject.transform.position = new Vector2(FindObjectOfType<PlayerStartPoint>().transform.position.x, FindObjectOfType<PlayerStartPoint>().transform.position.y);
            gameObject.SetActive(true);
            SetMaxHp();
        }
    }
    public void SetMaxHp()
    {
        currentHp = HpPool;
    }



}
