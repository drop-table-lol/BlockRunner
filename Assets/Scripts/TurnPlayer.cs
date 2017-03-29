using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPlayer : MonoBehaviour
{

    public string direction = "Right";

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.tag == "Player")
        {
            Debug.Log("Turning Player");
            FindObjectOfType<PlayerMovement>().ChangeDirection(direction);
            FindObjectOfType<followPlayer>().ChangeDirection(direction);
        }
    }
}
