using Com.Inferno.Protos;
using Google.Protobuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RewardManager : MonoBehaviour
{
	private List<Reward> rewardsList = new List<Reward>();

	private void Awake()
	{
		ActionManager.instance.SubscribeToEvent(StringConstants.EventNames.UPDATE_GAME_DATA,OnDataUpdates);
	}
	private void OnDestroy()
	{
		ActionManager.instance.UnsubscribeToEvent(StringConstants.EventNames.UPDATE_GAME_DATA,OnDataUpdates);
	}


	private void OnDataUpdates(Hashtable table)
	{
		
	}

	public void SendBattleWinEvent()
	{
		var userProfile = Whiteboard.Get<UserProfile>(GameConstants.Player.PLAYER_PROFILE);
		RewardEvent rewardEvent = new RewardEvent();
		rewardEvent.EventType = RewardEvent.Types.RewardEventType.BattleWin;
		rewardEvent.UserId = userProfile.UserId;
		Request request = RequestGenerator.CreateRequest(RequestType.RewardUser, rewardEvent.ToByteString());
		NetworkManager.Instance.SendRequest(request, OnRewardReceived);
	}

	private void OnRewardReceived(string requestId)
	{
		RewardEvent updatedEvent = NetworkManager.Instance.GetResponse<RewardEvent>(requestId);

		if (updatedEvent.Rewards.Count > 0)
		{
			Debug.Log(string.Format("Rewarded Chest ID : {0}  Updated Slot : {1}", updatedEvent.Rewards[0].RewardId, updatedEvent.Slot));
			Hashtable param = new Hashtable();
			param.Add(ChestSlot.SLOT_INDEX, updatedEvent.Slot);
			param.Add(ChestSlot.REWARD, updatedEvent.Rewards[0]);
			ActionManager.instance.TriggerEvent(StringConstants.EventNames.UPDATE_SLOTS_DATA, param);
		}
		else
		{
			Debug.LogError("All slots are full");
		}
	}
}



