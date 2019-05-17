using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{

	public int Count
	{
		get { return count; }
		set
		{
			count = value;
			UpdateText();
		}
	}

	private int count;
	private Text text;

	private void Awake()
	{
		text = GetComponent<Text>();
		UpdateText();
	}


	private void UpdateText()
	{
		string numbersInText = count.ToString();
		int length = numbersInText.Length;

		string counterText = "000";

		if (length < 4)
			counterText = (new string('0', 3 - length) + numbersInText);
		else
			counterText = numbersInText;

		text.text = counterText;
	}
}
