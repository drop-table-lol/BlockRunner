using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnEnter : MonoBehaviour {

    public List<Rigidbody> rbs = new List<Rigidbody>();
    public int maxImpactForce = 40;
    public int minImpactForce = 20;

	void Start ()
    {
		foreach(Rigidbody rb in rbs)
        {
            rb.AddForce(Random.Range(minImpactForce, maxImpactForce), Random.Range(minImpactForce, maxImpactForce), Random.Range(minImpactForce, maxImpactForce));
        }
	}
	
	
}
