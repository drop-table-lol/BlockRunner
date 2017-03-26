using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePlayerPowerup : MonoBehaviour {
    public PlayerMovement playermovement;
    //We need to make a list of vars we want to change based on 
    //different powerups. 
    //This will help with get and set vars, as well as make
    //A generalized function which invokes a powerup function
    //based on what we picked up.
	
    public void PowerUp(float lengthOfPowerup, string powerupType) //For testing
    {
        if (powerupType == "Jump")
        {
            playermovement.AddJumpForce(50);
        }

    }
}
