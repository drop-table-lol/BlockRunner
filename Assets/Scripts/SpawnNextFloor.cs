using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNextFloor : MonoBehaviour {

    bool hasSpawned = false;
    void OnTriggerEnter(Collider colliderInfo)
    {
        if (colliderInfo.tag == "Player" && !hasSpawned)
        {
            hasSpawned = true;
            Debug.Log("Spawning Next Floor");
            FindObjectOfType<SpawnWorld>().SpawnFloor();
        }
    }
}
