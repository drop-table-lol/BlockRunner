using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeObstacle : MonoBehaviour {

    public bool explodeNow = false;
    public GameObject obstacleRemains;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(explodeNow)
        {
            Instantiate(obstacleRemains, transform.position, transform.rotation);
            Destroy(gameObject);
        }
	}
}
