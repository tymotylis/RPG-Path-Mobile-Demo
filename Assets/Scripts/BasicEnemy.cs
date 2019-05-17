using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : EnemyTemplate
{
	private EnemyController enemyController;
	private GridTransform gridTransform;

	private void Start()
	{
		enemyController = GetComponent<EnemyController>();
		gridTransform = GetComponent<GridTransform>();
	}

	public override void HitBySword()
	{
		enemyController.GetPushedBack(0, 1);
	}

	public override void HitByShield()
	{
		enemyController.GetPushedBack(0, 0);
	}

	public override void OnPlayerMove(GridVector where)
	{
		GridVector attack = gridTransform.GridPosition - new GridVector(0, 1);

		if (where == attack)
		{
			enemyController.DealDamage(1, 0);
		}
	}
}
