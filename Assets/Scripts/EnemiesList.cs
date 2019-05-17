using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesList : MonoBehaviour
{
	public int ReadonlyEnemyCount;
	public TileScroll tileScroll;

	private List<GridTransform> enemies;

	private void Awake()
	{
		enemies = new List<GridTransform>();
	}

	public void AddEnemy(GameObject enemy)
	{
		enemies.Add(enemy.GetComponent<GridTransform>());

		ReadonlyEnemyCount = enemies.Count;
	}

	public void RemoveEnemy(GameObject enemy)
	{
		enemies.Remove(enemy.GetComponent<GridTransform>());

		ReadonlyEnemyCount = enemies.Count;
	}

    public List<GridTransform> ListEnemies(GridVector where = null)
	{
		if (where == null)
			return enemies;

		List<GridTransform> found = new List<GridTransform>();

		foreach (GridTransform g in enemies)
		{
			if (g.GridPosition == where)
			{
				found.Add(g);
			}
		}

		return found;
	}

	public void OnPlayerMove(GridVector where)
	{
		foreach (GridTransform g in enemies)
		{
			g.SendMessage("OnPlayerMove", where);
		}

		tileScroll.OnPlayerMove(where);
	}
}
