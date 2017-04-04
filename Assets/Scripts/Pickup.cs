using UnityEngine;

public class Pickup : MonoBehaviour
{



    public virtual void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.tag == "Player") //We've been picked up
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
