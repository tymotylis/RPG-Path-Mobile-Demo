using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator : MonoBehaviour
{
	public int startPosition;
	public int sequenceGaps;
	public GridTransform playerGridTransform;

	private GameObject[] enemySequences;
	private List<int> seqsNotTaken;
	private int needle;
	private EnemiesList list;

    void Start()
    {
		list = GetComponent<EnemiesList>();
		enemySequences = Resources.LoadAll<GameObject>("EnemySequences");

		if (enemySequences != null && enemySequences.Length > 0)
		{
			int length = enemySequences.Length;

			RefreshNotTakenSeqs();

			needle = startPosition;
		}
		else
		{
			Destroy(this);
		}
	}

    void Update()
    {
		int playerY = playerGridTransform.GridPosition.Y;

		if (playerY + 10 >= needle)
		{
			AddRandomSequence();
		}
    }

	private void RefreshNotTakenSeqs()
	{
		seqsNotTaken = new List<int>();

		for (int i = 0; i < enemySequences.Length; i++)
		{
			seqsNotTaken.Add(i);
		}
	}

	private void AddRandomSequence()
	{
		int rndSequenceNum = Random.Range(0, seqsNotTaken.Count);
		int rndSequence = seqsNotTaken[rndSequenceNum];
		seqsNotTaken.Remove(rndSequence);

		GameObject sequence = enemySequences[rndSequence];
		AddSequence(sequence);

		if (seqsNotTaken.Count == 0)
			RefreshNotTakenSeqs();
	}

	private void AddSequence(GameObject sequence)
	{
		needle += sequenceGaps + 1;

		Vector2 position = new Vector2(0, needle);
		Transform newSequence = Instantiate(sequence, position, Quaternion.identity, transform).transform;

		int furthestAway = needle;

		foreach (Transform e in newSequence)
		{
			GridVector gridPosition = e.GetComponent<GridTransform>().GridPosition;

			if (gridPosition.Y > furthestAway)
			{
				furthestAway = gridPosition.Y;
			}
			else if (gridPosition.Y < needle)
			{
				Debug.LogWarning("Enemy is under the defined bounds of the sequence!");
			}
		}

		needle = furthestAway;

		Unpack(newSequence);
	}

	private void Unpack(Transform what)
	{
		int count = what.childCount;

		for (int i = 0; i < count; i++)
		{
			Transform g = what.GetChild(0);

			g.parent = transform;
			list.AddEnemy(g.gameObject);
		}

		Destroy(what.gameObject);
	}
}
