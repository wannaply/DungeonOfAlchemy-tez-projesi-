using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {

    public Slider healthBar;
    public Text hpText;
    public PlayerHealthManager playerHealth;

    private static bool UIExists;

    // Use this for initialization
    void Start()
    {
        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);

        }
    }
	
	// Update is called once per frame
	void Update () {
        healthBar.maxValue = playerHealth.MaxHp;
        healthBar.value = playerHealth.currentHp;
        hpText.text = "HP:" + playerHealth.currentHp + "/" + playerHealth.MaxHp;
		
	}
}
