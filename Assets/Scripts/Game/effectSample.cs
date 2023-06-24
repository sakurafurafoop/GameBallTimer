using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectSample : MonoBehaviour
{
	private void OnParticleCollision(GameObject other)
	{
		if(other.gameObject.tag == "Ball")
        {
			Rigidbody rb = other.GetComponent<Rigidbody>();
			rb.AddForce(new Vector3(50, 50));
        }
		
	}
}
