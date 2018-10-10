using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public enum PopupEvents
{
	OPEN_GENERIC_POPUP = 1,
	OPEN_USER_REGISTRATION = 2,
}

[Serializable]
public class PopupPair
{
	public PopupEvents eventName;
	public Popup popup;
	public bool isPrefab;
}

public class PopupManager : MonoBehaviour
{
	public static PopupManager Instance;
	public List<PopupPair> popupReferences = new List<PopupPair>();

	public GenericPopup genericPopupPrefab;
	public RectTransform popupPanel;

	public void Awake()
	{
		Instance = this;
	}

	public void Start()
	{
		for(int i = 0; i < popupReferences.Count; i++)
		{
			ActionManager.instance.SubscribeToEvent(popupReferences[i].eventName.ToString(), OpenPopup);
		}
	}

	public void OpenPopup(Hashtable properties)
	{

		string eventName = properties[StringConstants.PropertyName.EVENT_NAME] as string;

		PopupPair popupPair = popupReferences.Find(item => item.eventName.ToString().Equals(eventName));
		if (popupPair != null)
		{
			Debug.LogError("has Event : " + properties[StringConstants.PropertyName.EVENT_NAME]);
			if (popupPair.isPrefab)
			{
				Popup genericPopup = Instantiate(popupPair.popup, popupPanel);
				genericPopup.SetProperties(properties);
				genericPopup.Open();
			}
			else
			{
				popupPair.popup.SetProperties(properties);
				popupPair.popup.Open();
			}
		}
	}
	
}
