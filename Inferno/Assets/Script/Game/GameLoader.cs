using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Inferno.Protos;
using Google.Protobuf;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
	public GameObject userRegistrationScreen;

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

		Debug.Log("Startup Response received");
		Debug.Log("Startup Status : " + startUpResponse.StartupStatus.ToString());
		Debug.Log("Player Status : " + startUpResponse.PlayerStatus.ToString());

		if(startUpResponse.StartupStatus == StartUpResponse.Types.StartupResponseStatus.MajorUpdate)
		{
			return;
		}

		if (startUpResponse.PlayerStatus == StartUpResponse.Types.PlayerStatus.PlayerBanned)
		{
			return;
		}
		else if(startUpResponse.PlayerStatus == StartUpResponse.Types.PlayerStatus.PlayerNotFound)
		{
			userRegistrationScreen.SetActive(true);
			return; 
		}
		else if(startUpResponse.PlayerStatus == StartUpResponse.Types.PlayerStatus.PlayerFound)
		{
			Debug.Log("Player Found : ");
			SceneManager.LoadScene("GameScene");
		}
	}

}
