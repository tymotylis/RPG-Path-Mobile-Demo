using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraFollow : MonoBehaviour
{
	public Transform follow;
	public float offset = 3;

	private void LateUpdate()
	{
		transform.position = new Vector3(0, follow.transform.position.y + offset, -10);
	}
}
