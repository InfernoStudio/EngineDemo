using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Inferno.Protos;

public class MainMenu : MonoBehaviour
{
	void Start ()
	{
		var playerStatus = Whiteboard.Get<StartUpResponse.Types.PlayerStatus>(GameConstants.Player.STARTUP_PLAYER_STATUS);

		if (playerStatus == StartUpResponse.Types.PlayerStatus.PlayerFound)
		{
			Debug.Log("Player Found");
		}
		else if (playerStatus == StartUpResponse.Types.PlayerStatus.PlayerNotFound)
		{
			Debug.Log("Player Not Found Startting Tutorial");
			Hashtable table = new Hashtable();

			table.Add("logged_in", true);
			ActionManager.instance.TriggerEvent("OpenGenericPopup",table);
		}
	}
}
