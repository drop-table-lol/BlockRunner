using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{


    public virtual void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Player") //We've been picked up
        {
            ActivateInteractable();
            //PlayInteractableAnimation

        }
    }


    public virtual void ActivateInteractable()
    {
        //empty because children do stuff
        //children do stuff
    }


}
