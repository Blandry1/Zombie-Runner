using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAdd : MonoBehaviour {

    public Player player;
    private float health;
    
	void Update () {
        health = player.playerLife;
        Text myText = GetComponent<Text>();
        myText.text = "Health " + health;  
	}
}
