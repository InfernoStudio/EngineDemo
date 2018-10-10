using UnityEngine;
using UnityEngine.UI;
using Google.Protobuf;
using System;
using Com.Inferno.Protos;
using System.Collections.Generic;
using System.Collections;

public class UserRegistration : Popup 
{
    public InputField userName;
    public CreateUserResponseProto _response;
    public bool responseNotProcessed = true;
	
	public void Start()
	{
	}

	public void OnCreateClicked()
	{  
		string username = userName.text;

		if (username.ToLower().Equals("username") || string.IsNullOrEmpty(username))
		{
			
		}

		UserCreate createUserRequest = new UserCreate();
		createUserRequest.Name = userName.text;
		createUserRequest.Udid = SystemInfo.deviceUniqueIdentifier;
		createUserRequest.FbId = "";
		createUserRequest.Platform = "ANDROID";
		Request request = RequestGenerator.CreateRequest(RequestType.CreateNewUser, createUserRequest.ToByteString());
		NetworkManager.Instance.SendRequest(request, OnResponseReceived);
    }

	public void OnResponseReceived(string requestId)
	{
		CreateUserResponseProto response =	NetworkManager.Instance.GetResponse<CreateUserResponseProto>(requestId);

		if (response.Status == ResponseStatus.Success)
		{
			UserProfile user = UserProfile.Parser.ParseFrom(response.Payload);
			Util.Log(" New User Created " + user.Username);
			Hashtable parameters = new Hashtable();
			parameters.Add(GameConstants.Player.PLAYER_PROFILE, user);
			ActionManager.instance.TriggerEvent(StringConstants.EventNames.UPDATE_PLAYER_PROFILE, parameters);
		}
		else if (response.Status == ResponseStatus.UserExist)
		{
			UserProfile user = UserProfile.Parser.ParseFrom(response.Payload);
			Hashtable parameters = new Hashtable();
			parameters.Add(GameConstants.Player.PLAYER_PROFILE, user);
			ActionManager.instance.TriggerEvent(StringConstants.EventNames.UPDATE_PLAYER_PROFILE, parameters);
			Debug.Log("User with same device id already exist : " + user.Username);
		}
		DataManager.SendDataRequest();
		Close();
	}

    public void OnResponseReceived(CreateUserResponseProto response)
    {
        _response = response;
        responseNotProcessed = true;
    }

	public override void Open()
	{
		gameObject.SetActive(true);
	}

	public override void Close()
	{
		gameObject.SetActive(false);
	}

	public override void SetProperties(Hashtable properties)
	{
		
	}
}
