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
	public ActionManager.GenericPopupEvent genericPoupEvent;

	public void Awake()
	{
		Instance = this;
		genericPoupEvent.AddListener(CreatePopup);
	}

	public void OnDestroy()
	{
		genericPoupEvent.RemoveListener(CreatePopup);
	}

	public void CreatePopup(Hashtable properties)
	{
		GenericPopup genericPopup = Instantiate(genericPopupPrefab, popupPanel);
		genericPopup.SetPopupProperties(properties);
	}
	
}
