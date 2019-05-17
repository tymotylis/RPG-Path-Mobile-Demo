using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyTemplate : MonoBehaviour
{
	public abstract void HitBySword();

	public abstract void HitByShield();

	public virtual void OnPlayerMove(GridVector where)
	{

	}
}
