using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTransform : MonoBehaviour
{
	public GridVector GridPosition
	{
		get { return GetGridPosition(); }
	}

	private GridVector GetGridPosition()
	{
		return new GridVector(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
	}

}
