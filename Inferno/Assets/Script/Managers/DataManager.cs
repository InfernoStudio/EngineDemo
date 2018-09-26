using Com.Inferno.Protos;
using Google.Protobuf;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
	public static DataManager Instance;

	private void Awake()
	{
		Instance = this;
	}

	public void SendDataRequest()
	{
		// Send User Data Request
		DataRequest dataRequest = new DataRequest();
		dataRequest.CurrentDataHash = Guid.NewGuid().ToString();
		Request request = RequestGenerator.CreateRequest(RequestType.LoadGameData, dataRequest.ToByteString());
		NetworkManager.Instance.SendRequest(request, OnDataReceived);

	}

	private void OnDataReceived(string requestId)
	{
		DataResponse response = NetworkManager.Instance.GetResponse<DataResponse>(requestId);

		if (response.Hashmatched == true)
		{
			Debug.LogError("No Data Updates");
		}
		else
		{
			//Debug.LogError("Game Elements Count : " + response.Data.Gameelements.Count);
			foreach (Card card in response.Data.Cards)
			{
				foreach(Property prop in card.Properties)
				{
					object obj = SimpleJson.SimpleJson.DeserializeObject(prop.Json);
					Debug.LogError(string.Format("PropName : {0}  PropValue {1}",prop.Name,obj));
				}
			}

			foreach (Chest chest in response.Data.Chests)
			{
				Debug.LogError(string.Format("Chest Name : {0}  Image {1}", chest.Name, chest.Image));
			}


			foreach (Reward reward in response.Data.Rewards)
			{
				Debug.LogError(string.Format("Reward ID : {0}  Type {1}", reward.RewardId, reward.Type));
			}

			foreach (GameElement element in response.Data.Gameelements)
			{
				Debug.LogError(string.Format("Game Element ID : {0}  Currency {1}", element.Id, element.Currency[0].Type));
			}
		}
	}
}
