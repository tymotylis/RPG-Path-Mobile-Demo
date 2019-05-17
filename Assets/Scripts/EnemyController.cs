using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public int hp;
	public int offscreenDeletion = 5;
	public Animator animator;
	public GameObject myParticleSystem;

	private ParticleEmmitersController particleEmmitersController;
	private PlayerController player;
	private EnemiesList enemiesList;
	private GridTransform gridTransform;

	private void Start()
	{
		particleEmmitersController = GameObject.Find("ParticleEmmiters").GetComponent<ParticleEmmitersController>();
		player = GameObject.Find("Player").GetComponent<PlayerController>();
		enemiesList = GameObject.Find("Enemies").GetComponent<EnemiesList>();
		gridTransform = GetComponent<GridTransform>();
	}

	public bool DealDamage(int toPlayer = 0, int toEnemy = 0)
	{
		if (toPlayer > 0)
			animator.SetTrigger("Attack");

		player.GetDamaged(toPlayer);

		hp -= toEnemy;

		if (hp <= 0)
		{
			player.killCounter.Count++;

			Destroy(gameObject);
			return true;
		}

		return false;
	}

	public void GetPushedBack(int dmgToPlayer = 0, int dmgToEnemy = 0)
	{
		bool dead = DealDamage(dmgToPlayer, dmgToEnemy);

		if (!dead)
			MoveTo(gridTransform.GridPosition + new GridVector(0, 1));
	}

	private void OnDestroy()
	{
		//particleEmmitersController.AddParticleSystem(myParticleSystem, (Vector2) gridTransform.GridPosition);

		enemiesList.RemoveEnemy(gameObject);
	}

	public void MoveTo(GridVector where)
	{
		foreach (GridTransform g in enemiesList.ListEnemies(where))
		{
			g.GetComponent<EnemyController>().GetPushedBack();
		}

		transform.position = (Vector2) where;
	}

	public void OnPlayerMove(GridVector where)
	{
		if (gridTransform.GridPosition.Y + offscreenDeletion <= where.Y)
		{
			Destroy(gameObject);
		}
	}
}
