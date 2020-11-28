using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour {

	public Camera m_cam;
	public LineRenderer m_elasticLine;
	public House m_housePrefab;
	private House m_instantiatedHouse;

	public static int score;
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButton(0))
		{
			var mouse_pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
			var mouse_pos_world = m_cam.ScreenToWorldPoint(mouse_pos);
			var mouse_pos_local = transform.InverseTransformPoint(mouse_pos_world);

			m_elasticLine.SetPosition(1, mouse_pos_local);

			if (m_instantiatedHouse == null)
			{
				m_instantiatedHouse = Instantiate(m_housePrefab, mouse_pos_world, Quaternion.identity);
			}
			else if (m_instantiatedHouse.hasLaunched == false)
			{
				m_instantiatedHouse.transform.position = mouse_pos_world;
			}
		}
		else if (Input.GetMouseButtonUp(0) && m_instantiatedHouse != null && m_instantiatedHouse.hasLaunched == false)
		{
			var mouse_pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
			var mouse_pos_world = m_cam.ScreenToWorldPoint(mouse_pos);
			var mouse_pos_local = transform.InverseTransformPoint(mouse_pos_world);

			// throw house the inverse of the mouse local pos to throw towards the catapult
			m_instantiatedHouse.Throw(-mouse_pos_local);
		}
		else
		{
			m_elasticLine.SetPosition(1, Vector3.zero);
		}
	}


	public void QuitGame()
	{
		Application.Quit();
	}
}
