using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerup : Pickup
{
    [Header("List of powerups:")]
    [Header("Speed")]
    [Header("Jump")]
    [Header("Invincible")]
    [Header("Size")]
    public string powerupType; //What does it do. Probably a better way to do this
    public float lengthOfPowerup; //how many seconds does it last?
    
    public override void ActivatePowerup()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponentInChildren<ActivatePlayerPowerup>().PowerUp(lengthOfPowerup, powerupType);
        FindObjectOfType<Score>().AddScore(10);
    }
	
}