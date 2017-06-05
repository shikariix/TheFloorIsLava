using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawScript : MonoBehaviour
{
	public LineRenderer line;
	private bool isMousePressed;
	public List<Vector3> pointsList = new List<Vector3>();
	private Vector3 mousePos;

	//	-----------------------------------	
	void Start ()
	{
		// Create line renderer component and set its property
		line = GetComponent<LineRenderer>();
		line.material = new Material (Shader.Find ("Particles/Additive"));
		line.positionCount = 0;
		line.startColor = Color.green;
		line.useWorldSpace = true;	
		isMousePressed = false;
	}
	//	-----------------------------------	
	void Update ()
	{
		// If mouse button down, remove old line and set its color to green
		if (Input.GetMouseButtonDown (0)) {
			pointsList.Clear();
			isMousePressed = true;
			line.positionCount = 0;
			line.startColor = Color.green;
		}

		if (Input.GetMouseButtonUp (0)) {
			isMousePressed = false;
		}
		// Drawing line when mouse is moving(presses)
		if (isMousePressed) {
			mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mousePos.z = 0;
			if (!pointsList.Contains (mousePos)) {
				pointsList.Add (mousePos);
				line.positionCount = pointsList.Count;
				line.SetPosition (pointsList.Count - 1, (Vector3)pointsList [pointsList.Count - 1]);

			}
		}
	}
}