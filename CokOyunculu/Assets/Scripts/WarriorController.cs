using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WarriorController : NetworkBehaviour
{

    public float yurumehizi;
    private Animator anim;
    private Rigidbody2D playerBody;

    private bool playerMoving;
    private Vector2 lastMove;
    private static bool playerExists; // oyun içindeki tüm scenelerde bu değer bağlantılı. o yüzden static yaptık ki değişmesin

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;
    private soundmanager sman;



    // Baslangic değerleri
    void Start()
    {
        anim = GetComponent<Animator>();
        playerBody = GetComponent<Rigidbody2D>();
        sman = FindObjectOfType<soundmanager>();



        /*if(!playerExists)
        {
            playerExists = true;                 // oyuncunun geçişlerde kopyalanmasını engelliyoruz
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);

        }*/

        lastMove = new Vector2(0f, -1f);


    }

    // Her framede yenilenir
    //RPCler ve coomandler kaldı
    void Update()
    {

        playerMoving = false;
        attacking = false;

        if (hasAuthority == false)
        {
            return;
        }
        if (!attacking)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                playerBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * yurumehizi, playerBody.velocity.y);
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                playerBody.velocity = new Vector2(playerBody.velocity.x, Input.GetAxisRaw("Vertical") * yurumehizi);
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }
            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            {
                playerBody.velocity = new Vector2(0f, playerBody.velocity.y);
            }
            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                playerBody.velocity = new Vector2(playerBody.velocity.x, 0f);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                playerBody.velocity = Vector2.zero;
                anim.SetBool("PlayerAttacking", true);

                sman.playerAttack.Play();

            }
        }
        if (attackTimeCounter >= 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if (attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("PlayerAttacking", false);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);




    }
}
