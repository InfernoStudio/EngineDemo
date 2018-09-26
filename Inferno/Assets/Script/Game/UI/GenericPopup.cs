using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class GenericPopup : Popup
{
	public const string TITLE = "title";
	public const string MESSAGE = "message";
	public const string BUTTON_NAMES = "button_names";
	public const string BUTTON_COLORS = "button_colors";
	public const string BUTTON_ACTIONS = "button_actions";

	public Button buttonPrefab;
	public HorizontalLayoutGroup buttonGrid;

	public TextMeshProUGUI message;
	public TextMeshProUGUI title;
	public TextMeshProUGUI positiveButtonName;
	public TextMeshProUGUI negativeButtonName;

	public Button closeButton;
	public Button positiveButton;
	public Button negativeButton;
	private List<Button> buttons;

	public void OnCloseClicked()
	{
		Close();
	}

	public override void Open()
	{
		gameObject.SetActive(true);
	}

	public override void Close()
	{
		gameObject.SetActive(false);
	}

	public override void SetProperties(Hashtable properties)
	{
		if (properties.ContainsKey(TITLE))
			title.text = properties[TITLE] as string;

		if (properties.ContainsKey(MESSAGE))
			message.text = properties[MESSAGE] as string;

		if (properties.ContainsKey(BUTTON_NAMES))
		{
			string[] buttonNames = properties[BUTTON_NAMES] as string[];
			buttons = new List<Button>();
			foreach (string buttonName in buttonNames)
			{
				Button button = Instantiate(buttonPrefab, buttonGrid.transform);
				buttons.Add(button);
			}
		}

		if (properties.ContainsKey(BUTTON_COLORS))
		{
			string[] buttonColors = properties[BUTTON_COLORS] as string[];
			foreach (var button in buttons)
			{
				buttons.Add(button);
			}
		}

		if (properties.ContainsKey(BUTTON_ACTIONS))
		{
			UnityAction[] buttonActions = properties[BUTTON_ACTIONS] as UnityAction[];
			int i = 0;
			foreach (var button in buttons)
			{
				button.onClick.AddListener(buttonActions[i]);
				i++;
			}
		}
	}
}
