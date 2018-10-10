using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Com.Inferno.Protos;

public class ChestSlot : MonoBehaviour
{
	public const string SLOT_INDEX = "SLOT_INDEX";
	public const string REWARD = "REWARD";

	public Image slotImage;
	public TextMeshProUGUI inactiveText;
	public TextMeshProUGUI timeLeft;
	public Button speedUp;
	public int slotIndex;

	void Awake ()
	{
		ActionManager.instance.SubscribeToEvent(StringConstants.EventNames.UPDATE_SLOTS_DATA, UpdateSlotsData);
		ActionManager.instance.SubscribeToEvent(StringConstants.EventNames.UPDATE_PLAYER_PROFILE, UpdateSlotsFromPlayerProfile);
	}
	private void OnDisable()
	{
		ActionManager.instance.UnsubscribeToEvent(StringConstants.EventNames.UPDATE_SLOTS_DATA,UpdateSlotsData);
		ActionManager.instance.UnsubscribeToEvent(StringConstants.EventNames.UPDATE_PLAYER_PROFILE, UpdateSlotsFromPlayerProfile);
	}

	private void UpdateSlotsData(Hashtable parameters)
	{
		int slotIndex = (int)parameters[SLOT_INDEX];

		if(slotIndex == this.slotIndex)
		{
			var reward = parameters[REWARD] as Reward;
			if(reward.Type == Schema.RewardTypes.CHEST)
			{
				Chest chest = DataManager.Instance.Get<Chest>(reward.RewardId);
				//TODO : Assign Sprite based on chest.Image property
				Debug.Log("Chest Rewarded : " + chest.Name);
				inactiveText.gameObject.SetActive(false);
				slotImage.enabled = true;
			}
		}
	}
	
	private void UpdateSlotsFromPlayerProfile(Hashtable parameters)
	{
		var playerProfile = parameters[GameConstants.Player.PLAYER_PROFILE] as UserProfile;

		if(!string.IsNullOrEmpty(playerProfile.Slots[slotIndex]))
		{
			Chest chest = DataManager.Instance.Get<Chest>(playerProfile.Slots[slotIndex]);
			//TODO : Assign Sprite based on chest.Image property
			Debug.Log("Chest Rewarded : " + chest.Name);
			inactiveText.gameObject.SetActive(false);
			slotImage.enabled = true;
		}
	}

	public void OnChestClicked()
	{

	}
	
}
