using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {

	public Rigidbody2D m_rigidbody;
	public float force_multiplier = 150.0f;
	public float lifetime = 2.0f;

	public bool hasLaunched = false;

	public void Throw(Vector3 direction)
	{
		// only launch once
		if(hasLaunched == false)
		{
			m_rigidbody.isKinematic = false;
			m_rigidbody.simulated = true;
			m_rigidbody.AddForce(direction * force_multiplier);
			hasLaunched = true;

			Destroy(gameObject, lifetime);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
    {
		Destroy(collision.gameObject);
	}
}
