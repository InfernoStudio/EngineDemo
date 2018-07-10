using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedLoadingText : MonoBehaviour {

	int count = 0;


	private void Start()
	{
		InvokeRepeating("AnimateLoadingText", 0, 0.5f);
	}
	void AnimateLoadingText()
	{
		if(count % 4 == 0)
		{
			GetComponent<UILabel>().text = "Loading";
		}
		else if(count % 4 == 1)
		{
			GetComponent<UILabel>().text = "Loading.";
		}
		else if (count % 4 == 2)
		{
			GetComponent<UILabel>().text = "Loading..";
		}
		else if (count % 4 == 3)
		{
			GetComponent<UILabel>().text = "Loading...";
		}
		count++;

	}
}
