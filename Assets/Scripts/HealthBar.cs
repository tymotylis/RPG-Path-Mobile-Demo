using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
	public int Hp
	{
		get { return hp; }
		set
		{
			hp = Mathf.Clamp(value, 0, maxHp);
			Refresh();
		}
	}

	public int MaxHp
	{
		get { return maxHp; }
		set
		{
			maxHp = Mathf.Clamp(value, 0, int.MaxValue);

			if (Hp > 0)
				Refresh();
		}
	}

	public float hearthWidth;
	public Sprite fullHearth;
	public Sprite emptyHearth;
	public GameObject prefab;

	private int hp;
	private int maxHp;


	private void Refresh()
	{
		int fullHearths = Hp;
		int emptyHearths = MaxHp - Hp;
		int allHearths = maxHp;

		float widthSum = allHearths * hearthWidth;

		foreach (Transform child in transform)
		{
			Destroy(child.gameObject);
		}

		for (float x = -((widthSum - hearthWidth ) / 2); x <= ((widthSum + hearthWidth) / 2); x += hearthWidth)
		{
			if (fullHearths > 0 || emptyHearths > 0)
			{
				GameObject prefabGo = Instantiate(prefab, transform);
				prefabGo.GetComponent<SpriteRenderer>().sprite = fullHearths > 0 ? fullHearth : emptyHearth;
				prefabGo.transform.localPosition = new Vector2(x, 0);

				if (fullHearths > 0) fullHearths--;
				else emptyHearths--;
			}
		}
	}
}
