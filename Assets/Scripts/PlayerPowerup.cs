using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerup : Pickup
{
    public string powerupType; //What does it do. Probably a better way to do this
    public float lengthOfPowerup; //how many seconds does it last?

    public override void ActivatePowerup()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponentInChildren<ActivatePlayerPowerup>().PowerUp(lengthOfPowerup, powerupType);
    }
	
}
