using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Com.Inferno.Protos;

public class UserProfileWidget : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI playerName;
	[SerializeField]
	private TextMeshProUGUI playerLevel;
	[SerializeField]
	private Slider xpBar;
	[SerializeField]
	private Image playerAvatar;

	private void Awake()
	{
		ActionManager.instance.SubscribeToEvent(StringConstants.EventNames.UPDATE_PLAYER_PROFILE, UpdatePlayer);
	}

	private void OnDestroy()
	{
		ActionManager.instance.UnsubscribeToEvent(StringConstants.EventNames.UPDATE_PLAYER_PROFILE, UpdatePlayer);
	}

	public void UpdatePlayer(Hashtable parameters)
	{
		var playerProfile = parameters[GameConstants.Player.PLAYER_PROFILE] as UserProfile;

		if(playerProfile != null)
		{
			playerName.text = playerProfile.Username;
			playerLevel.text = (playerProfile.Xp / 100).ToString();
			xpBar.value = (playerProfile.Xp / 100f);
		}
	}

}
