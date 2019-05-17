using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
	public UnityEvent OnLeft;
	public UnityEvent OnRight;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			float xPos = Input.mousePosition.x;

			if (xPos < Screen.width / 2)
			{
				OnLeft.Invoke();
			}
			else
			{
				OnRight.Invoke();
			}
		}

		else if (Input.GetButtonDown("Left"))
		{
			OnLeft.Invoke();
		}
		else if (Input.GetButtonDown("Right"))
		{
			OnRight.Invoke();
		}
	}
}
