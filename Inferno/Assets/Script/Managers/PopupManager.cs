using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PopupManager : MonoBehaviour
{
	public static PopupManager Instance;
	public List<GameObject> Popups = new List<GameObject>();
	public GenericPopup genericPopupPrefab;
	public RectTransform popupPanel;

	public void Awake()
	{
		Instance = this;
		ActionManager.instance.SubscribeToEvent("OpenGenericPopup",CreatePopup);
	}

	public void CreatePopup(Hashtable properties)
	{
		GenericPopup genericPopup = Instantiate(genericPopupPrefab, popupPanel);
		genericPopup.SetPopupProperties(properties);
	}
	
}
