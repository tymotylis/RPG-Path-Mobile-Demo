using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public enum GoTypes
	{
		shield, sword
	}

	public int health;
	public float dieTime;
	public HealthBar healthBar;
	public Animator animator;
	public Animator blinkingRed;
	public Counter killCounter;
	public GameObject deathScreen;

	private EnemiesList enemiesList;
	private GridTransform myGridTransform;

	private void Awake()
	{
		myGridTransform = GetComponent<GridTransform>();
		enemiesList = GameObject.Find("Enemies").GetComponent<EnemiesList>();

		deathScreen.SetActive(false);

		healthBar.MaxHp = health;
		healthBar.Hp = health;
	}

	public void GetDamaged(int damage)
	{
		if (damage > 0)
		{
			blinkingRed.SetTrigger("Blink");

			health -= damage;
			healthBar.Hp = health;

			if (health <= 0)
			{
				StartCoroutine(Die());
			}
		}
	}

	public void GoLeft()
	{
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
		{
			GridVector currentPosition = myGridTransform.GridPosition;

			if (currentPosition.X == -2)
			{
				GoStraight(GoTypes.sword);
				return;
			}

			GridVector position = currentPosition + new GridVector(-1, 1);
			MoveTo(position, GoTypes.sword);

			animator.SetTrigger("MoveLeft");
		}
		
	}

	public void GoRight()
	{
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
		{
			GridVector currentPosition = myGridTransform.GridPosition;

			if (currentPosition.X == 2)
			{
				GoStraight(GoTypes.sword);
				return;
			}

			GridVector position = currentPosition + new GridVector(1, 1);
			MoveTo(position, GoTypes.sword);

			animator.SetTrigger("MoveRight");
		}
	}

	public void GoStraight(GoTypes how)
	{
		GridVector currentPosition = myGridTransform.GridPosition;
		GridVector position = currentPosition + new GridVector(0, 1);

		MoveTo(position, how);

		animator.SetTrigger("MoveStraight");
	}

	private void MoveTo(GridVector where, GoTypes how)
	{
		transform.position = (Vector2)where;
		enemiesList.OnPlayerMove(where);

		foreach (GridTransform e in enemiesList.ListEnemies(where))
		{
			EnemyTemplate enemy = e.GetComponent<EnemyTemplate>();

			if (how == GoTypes.shield)
			{
				enemy.HitByShield();
			}
			else if (how == GoTypes.sword)
			{
				enemy.HitBySword();
			}
			else
			{
				Debug.LogError("Not Defined!");
			}
		}
	}

	private IEnumerator Die()
	{
		yield return new WaitForSeconds(dieTime);

		deathScreen.SetActive(true);
		Time.timeScale = 0;
	}
}
