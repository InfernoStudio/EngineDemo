using UnityEngine;
using UnityEngine.UI;
using Google.Protobuf;
using System;
using Com.Inferno.Protos;
using Facebook.Unity;
using System.Collections.Generic;
using Facebook.Unity;

public class UserRegistration : MonoBehaviour 
{
    public static UserRegistration Instance;
    public UIInput m_UserName;
    public CreateUserResponseProto _response;
    public bool responseNotProcessed = true;
	
    public void Awake()
    {
        Instance = this;
    }

    public void OnCreateClicked()
    {
        Player player = new Player();
        player.name = m_UserName.label.text;
        player.id = Guid.NewGuid().ToString();

		User usrBuilder = new User();

        usrBuilder.Name = player.name;
        usrBuilder.Id = player.id;
		usrBuilder.Udid = SystemInfo.deviceUniqueIdentifier;
        usrBuilder.FbId = PlayerPrefs.GetString(GameConstants.PlayerPrefKeys.FB_ID);
		Request req = RequestGenerator.CreateRequest(RequestType.CreateNewUser, usrBuilder.ToByteString());

        NetworkManager.Instance.SendRequest(req, OnResponseReceived);
    }

	public void OnResponseReceived(string requestId)
	{
		CreateUserResponseProto response =	NetworkManager.Instance.GetResponse<CreateUserResponseProto>(requestId);

		if(response.Status == ResponseStatus.Success)
		{
			Debug.Log("New User Created");
		}
		else if (response.Status == ResponseStatus.UserExist)
		{
			Debug.Log("User with same device id already exist");
		}
	}

    public void OnResponseReceived(CreateUserResponseProto response)
    {
        _response = response;
        responseNotProcessed = true;
    }

	public void OnFacebookClicked()
	{
		var perms = new List<string>() { "public_profile", "email" };
		FB.LogInWithReadPermissions(perms, AuthCallback);
	}

	private void AuthCallback(ILoginResult result)
	{
		if (FB.IsLoggedIn)
		{
			// AccessToken class will have session details
			var aToken = AccessToken.CurrentAccessToken;
			string accessToken = PlayerPrefs.GetString(GameConstants.PlayerPrefKeys.FACEBOOK_ACCESS_TOKEN);
			string userId = PlayerPrefs.GetString(GameConstants.PlayerPrefKeys.FB_ID);
			if (string.IsNullOrEmpty(accessToken) || !accessToken.Equals(aToken.TokenString))
			{
				PlayerPrefs.SetString(GameConstants.PlayerPrefKeys.FACEBOOK_ACCESS_TOKEN, aToken.TokenString);
			}

			if (string.IsNullOrEmpty(userId))
			{
				PlayerPrefs.SetString(GameConstants.PlayerPrefKeys.FB_ID, aToken.UserId);
			}

			// Print current access token's User ID
			Debug.Log(aToken.UserId);
			// Print current access token's granted permissions
			foreach (string perm in aToken.Permissions)
			{
				Debug.Log(perm);
			}
		}
		else
		{
			Debug.Log("User cancelled login");
		}
	}
}
