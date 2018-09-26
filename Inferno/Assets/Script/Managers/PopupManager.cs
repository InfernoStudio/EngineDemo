using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PopupPair
{
	public string eventName;
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
			ActionManager.instance.SubscribeToEvent(popupReferences[i].eventName, OpenPopup);
		}
	}

	public void OpenPopup(Hashtable properties)
	{
		Debug.LogError("has Event : " + properties[StringConstants.PropertyName.EVENT_NAME]);

		string eventName = properties[StringConstants.PropertyName.EVENT_NAME] as string;

		PopupPair popupPair = popupReferences.Find(item => item.eventName.Equals(eventName));
		if (popupPair != null)
		{
			if(popupPair.isPrefab)
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
