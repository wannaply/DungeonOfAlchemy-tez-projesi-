using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerHealthManager : NetworkBehaviour {

    public static PlayerHealthManager instance;
    public int MaxHp;
    
    [SyncVar]public int currentHp;
    public float waitToReload;
    private float reloadCounter;
    [SyncVar]public bool isDead;
    private soundmanager sman;
    public Font font;
    public Texture aTexture;

    // Use this for initialization
    void Start () {
        
        instance = this;
        sman = FindObjectOfType<soundmanager>();
	}

	
	// Update is called once per frame
	void Update () {
        
        MaxHp = currentHp;
        reloadCounter = waitToReload;




    }



    public void HurtPlayer(int damage)
    {
        currentHp -= damage;
        sman.playerHurt.Play();
        if(currentHp <=0)
        {
            sman.playerDead.Play();
            //gameObject.SetActive(false);
            CmdiAmDead();
            //Debug.Log(isDead);



            //gameObject.transform.position = new Vector2(FindObjectOfType<PlayerStartPoint>().transform.position.x, FindObjectOfType<PlayerStartPoint>().transform.position.y);
            //gameObject.SetActive(true);
            SetMaxHp();

            Invoke("CmdgoDie",5);
        }
    }
    public void SetMaxHp()
    {
        
        Destroy(gameObject.GetComponent<SpriteRenderer>());
    }
    [Command]
    void CmdgoDie()
    {
        
        gameObject.SetActive(false);
    }
    private void OnGUI()
    {

       // GUI.Label(new Rect((Screen.width - 100), 10, 100, 20), "HP: " + currentHp.ToString());





        if (isDead)
            {
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), aTexture);
            }
        
        
    }
    [Command]
    void CmdiAmDead()
    {
        this.isDead = true;
        this.currentHp = 0;
        this.MaxHp = 0;
    }
}





