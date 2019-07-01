using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    
    private PlayerHealthManager phm;
    private bool check;
   
    // Start is called before the first frame update
    void Start()
    {
        if (phm != null)
        {
            phm = GameObject.Find("Player").GetComponent<PlayerHealthManager>();


            
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(phm!= null)
        check = phm.isDead;
        Debug.Log(check);

    }

    private void OnGUI()
    {

        if (phm != null)
        {
            if (check)
            {
                GUI.TextField(new Rect(10, 10, 200, 20), "gameover", 25);
            }
        }
    }
}
