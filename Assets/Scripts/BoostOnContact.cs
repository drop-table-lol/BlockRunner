using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostOnContact : MonoBehaviour {

    public Rigidbody rb;
    [SerializeField]
    int boostForce = 1000;


    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.tag == "Player")
        {
            if (rb != null)
            {
                rb.AddForce(0, 0, boostForce);
                Debug.Log("Player boosted");
            }
            else
            {
                Debug.Log("Player not found");
            }
        }
    }
}
