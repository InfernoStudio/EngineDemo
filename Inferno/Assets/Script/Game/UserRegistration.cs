using UnityEngine;
using UnityEngine.UI;
using Google.Protobuf;
using System;
using Com.Inferno.Protos;
using System.Collections.Generic;

public class UserRegistration : MonoBehaviour 
{
    public static UserRegistration Instance;
    public InputField userName;
    public CreateUserResponseProto _response;
    public bool responseNotProcessed = true;
	
    public void Awake()
    {
        Instance = this;
    }

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
			User user = User.Parser.ParseFrom(response.Payload);
			Debug.Log(" New User Created " + user.Name);
		}
		else if (response.Status == ResponseStatus.UserExist)
		{
			User user = User.Parser.ParseFrom(response.Payload);
			Debug.Log("User with same device id already exist : " + user.Name);
		}
	}

    public void OnResponseReceived(CreateUserResponseProto response)
    {
        _response = response;
        responseNotProcessed = true;
    }
}
