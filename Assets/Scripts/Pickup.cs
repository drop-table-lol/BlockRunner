using UnityEngine;

public class Pickup : MonoBehaviour
{



    public virtual void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Player") //We've been picked up
        {
            ActivatePowerup();
            Destroy(gameObject);

        }
    }

    public virtual void ActivatePowerup()
    {
        //empty because children do stuff
        //children do stuff
    }
}
