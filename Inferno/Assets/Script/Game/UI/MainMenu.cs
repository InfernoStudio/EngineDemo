using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Inferno.Protos;
using System;
using Google.Protobuf;
public class MainMenu : MonoBehaviour
{
	void Start ()
	{
		var playerStatus = Whiteboard.Get<StartUpResponse.Types.PlayerStatus>(GameConstants.Player.STARTUP_PLAYER_STATUS);
		var playerProfile = Whiteboard.Get<UserProfile>(GameConstants.Player.PLAYER_PROFILE);

		if (playerStatus == StartUpResponse.Types.PlayerStatus.PlayerFound)
		{
			Util.Log("Player Found");
			Hashtable table = new Hashtable();
			table.Add(GameConstants.Player.PLAYER_PROFILE, playerProfile);
			ActionManager.instance.TriggerEvent(StringConstants.EventNames.UPDATE_PLAYER_PROFILE, table);

		}
		else if (playerStatus == StartUpResponse.Types.PlayerStatus.PlayerNotFound)
		{
			Hashtable table = new Hashtable();
			table.Add(StringConstants.PropertyName.EVENT_NAME, StringConstants.EventNames.OPEN_USER_REGISTRATION);
			ActionManager.instance.TriggerEvent(StringConstants.EventNames.OPEN_USER_REGISTRATION, table);
		}
	}
	


}
