using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {

    public int damage;
    public GameObject damageBurst;
    public Transform hitPoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" )
        {
            collision.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damage);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
        }

        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damage);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);

        }
    }

}
