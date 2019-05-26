using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
public class SlimeController : NetworkBehaviour {


    public float movespeed;
    private Rigidbody2D slimeBody;
    private bool isMoving;
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;
    public float waitToReload;
    private bool isReloading;
    private GameObject thePlayer;
    private Vector3 moveDirection;
    private bool chase;
    private Vector3 chaser;
    
    
    // Use this for initialization
    void Start () {

        slimeBody = GetComponent<Rigidbody2D>();
        

        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
       // CmdSpawnEnemy();


    }
	
	// Update is called once per frame
	void Update () {
        

        if(chase)
        {
            transform.position = Vector2.MoveTowards(transform.position, chaser, movespeed * Time.deltaTime);
        }
        


            if (isMoving)
            {
                timeToMoveCounter -= Time.deltaTime;
                slimeBody.velocity = moveDirection;
                if (timeToMoveCounter < 0f)
                {
                    isMoving = false;
                    timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
                }

            }
            else
            {
                timeBetweenMoveCounter -= Time.deltaTime;
                slimeBody.velocity = Vector2.zero;
                if (timeBetweenMoveCounter < 0f)
                {
                    isMoving = true;
                    timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
                    CmdMoveEnemy();

                }
            }
        
        
        
	}
    
    
    [Command]
    void CmdMoveEnemy()
    {
        moveDirection = new Vector3(Random.Range(-1f, 1f) * movespeed, Random.Range(-1f, 1f) * movespeed, 0f);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            chase = true;
            chaser = collision.gameObject.transform.position;
        }
    }



}
