using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{

    void Start()
    {
        Invoke("DestroySelf", 15);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }

}
