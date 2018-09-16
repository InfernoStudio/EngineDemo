using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Inferno.Protos;
using Google.Protobuf;
using UnityEngine.SceneManagement;
using System;

public class GameLoader : MonoBehaviour
{
	public StartUpResponse.Types.PlayerStatus currentPlayerStatus = StartUpResponse.Types.PlayerStatus.None;




	private void Awake()
	{
		DontDestroyOnLoad(this);
	}

	void Start ()
	{
		StartUp startUp = new StartUp();
		VersionProto version = new VersionProto();

		version.MajorNumber = 1;
		version.MinorNumber = 0;
		version.PatchNumber = 0;

		startUp.Version = version;
		startUp.Platform = "ANDROID";
		startUp.Udid = SystemInfo.deviceUniqueIdentifier;
		string fb_id = PlayerPrefs.GetString(GameConstants.PlayerPrefKeys.FB_ID);
		startUp.StaticDataHash = Guid.NewGuid().ToString();

		if(!string.IsNullOrEmpty(fb_id))
		{
			startUp.Fbid = fb_id;
		}
		else
		{
			startUp.Fbid = "";
		}

		Request request = RequestGenerator.CreateRequest(RequestType.Startup, startUp.ToByteString());

		NetworkManager.Instance.SendRequest(request, HandleStartupResponse);
	}

	public void HandleStartupResponse(string requestId)
	{
		StartUpResponse startUpResponse =  NetworkManager.Instance.GetResponse<StartUpResponse>(requestId);

		Debug.Log(" startup response received ");
		Debug.Log(" startup status : " + startUpResponse.StartupStatus.ToString());
		Debug.Log(" player status : " + startUpResponse.PlayerStatus.ToString());

		if(startUpResponse.StartupStatus == StartUpResponse.Types.StartupResponseStatus.MajorUpdate)
		{
			ActionManager.instance.TriggerEvent("OpenUserLogin");
			//PopupManager.Instance.CreatePopup("Major Update", startUpResponse.Message, "update", null, delegate	{
			//	Debug.LogError(" going to update page ");
			//});
			return;
		}
		else if(startUpResponse.StartupStatus == StartUpResponse.Types.StartupResponseStatus.MinorUpdate)
		{
			//PopupManager.Instance.CreatePopup("Minor Update", startUpResponse.Message, "update", "skip", delegate {
			//	Debug.LogError(" going to update page ");
			//},
			//delegate {

			//});
		}

		if (startUpResponse.PlayerStatus == StartUpResponse.Types.PlayerStatus.PlayerBanned)
		{
			//PopupManager.Instance.CreatePopup("Banned!!", startUpResponse.Message, "update", null, delegate	{
			//	Debug.LogError(" close the game ");
			//});
			return;
		}
		else if(startUpResponse.PlayerStatus    == StartUpResponse.Types.PlayerStatus.PlayerNotFound 
				|| startUpResponse.PlayerStatus == StartUpResponse.Types.PlayerStatus.PlayerFound)
		{
			Whiteboard.SetProperty(GameConstants.Player.STARTUP_PLAYER_STATUS, startUpResponse.PlayerStatus);
			SceneManager.LoadScene("GameScene");
			return;
		}
	}

}
