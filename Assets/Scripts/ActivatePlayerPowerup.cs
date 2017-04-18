using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePlayerPowerup : MonoBehaviour {
    public PlayerMovement playermovement;
    public playerCollision playercollision;
    //We need to make a list of vars we want to change based on 
    //different powerups. 
    //This will help with get and set vars, as well as make
    //A generalized function which invokes a powerup function
    //based on what we picked up.

    //Vars for powerups
    int jumpForce = 50;
    int speedForce = 10000;
    int sizeToAdd = -3; //probably between 1 and 9
    private Renderer r;
    public Material[] playerMats;


    void Start()
    {
        r = GetComponent<MeshRenderer>();
        r.material = playerMats[0];
    }


    public void PowerUp(float lengthOfPowerup, string powerupType)
    {
        if (powerupType == "Jump")
        {
            Debug.Log("Jump increased");
            StartCoroutine(Jump(lengthOfPowerup));
        }
        else if (powerupType == "Speed")
        {
            Debug.Log("Speed increased");
            StartCoroutine(Speed(lengthOfPowerup));
        }
        else if (powerupType == "Invincible")
        {
            Debug.Log("Invinciblity activated");
            StartCoroutine(Invincible(lengthOfPowerup));
        }
        else if (powerupType == "Size")
        {
            Debug.Log("Size decreased");
            StartCoroutine(Size(lengthOfPowerup));
        }
        else
        {
            Debug.LogError(powerupType + " is not a valid powerup name");
        }

    }


    IEnumerator Jump(float lengthOfPowerup)
    {
        playermovement.AddJumpForce(jumpForce);
        yield return new WaitForSeconds(lengthOfPowerup);
        playermovement.AddJumpForce(-jumpForce);

    }

    IEnumerator Speed(float lengthOfPowerup)
    {
        playermovement.AddSpeedForce(speedForce);
        yield return new WaitForSeconds(lengthOfPowerup);
        playermovement.AddSpeedForce(-speedForce);

    }

    IEnumerator Invincible(float lengthOfPowerup)
    {
        playercollision.isInvincible = true;
        r.material = playerMats[1];
        Invoke("FlashPlayer", lengthOfPowerup -1.5F);
        yield return new WaitForSeconds(lengthOfPowerup);
        playercollision.isInvincible = false;
        r.material = playerMats[0];


    }


    IEnumerator Size(float lengthOfPowerup)
    {
        playermovement.AddSize(sizeToAdd);
        yield return new WaitForSeconds(lengthOfPowerup);
        playermovement.AddSize(-sizeToAdd);

    }


    void FlashPlayer()
    {
        Debug.Log("Flashing");
        Invoke("Flash0", 1.4F);
        Invoke("Flash1", 1.3F);
        Invoke("Flash0", 1.2F);
        Invoke("Flash1", 1.1F);
        Invoke("Flash0", 1.0F);
        Invoke("Flash1", .9F);
        Invoke("Flash0", .8F);
        Invoke("Flash1", .7F);
        Invoke("Flash0", .6F);
        Invoke("Flash1", .5F);
        Invoke("Flash0", .4F);
        Invoke("Flash1", .3F);
        Invoke("Flash0", .2F);
        Invoke("Flash1", .1F);
    }

    void Flash0()
    {
        Debug.Log("ChangingColorRED");
        r.material = playerMats[0];
    }

    void Flash1()
    {
        Debug.Log("ChangingColorBLUE");
        r.material = playerMats[1];
    }

}
