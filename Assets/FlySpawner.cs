using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySpawner : MonoBehaviour {

	public float m_secondsBetweenFly = 3.0f;
	public float m_currentTime = 0.0f;
	public float m_maxX = 5.0f;
	public float m_maxY = 5.0f;

	public GameObject m_flyPrefab;
	
	// Update is called once per frame
	void Update () {

		m_currentTime += Time.deltaTime;

		if(m_currentTime >= m_secondsBetweenFly)
		{
			float x = Random.Range(1.0f, m_maxX);
			float y = Random.Range(-m_maxY, m_maxY);

			Instantiate(m_flyPrefab, new Vector3(x, y, 0.0f), Quaternion.identity);
			m_currentTime = 0.0f;
		}
	}
}
