using Com.Inferno.Protos;
using Google.Protobuf;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager 
{
	private static DataManager _Instance;
	public static DataManager Instance {
		get {
			if (_Instance == null)
				_Instance = new DataManager();
			return _Instance;
		}
	}

	private static Dictionary<Type, Dictionary<string, object>> dataDict = new Dictionary<Type, Dictionary<string, object>>();

	public static void SendDataRequest()
	{
		// Send User Data Request
		DataRequest dataRequest = new DataRequest();
		dataRequest.CurrentDataHash = Guid.NewGuid().ToString();
		Request request = RequestGenerator.CreateRequest(RequestType.LoadGameData, dataRequest.ToByteString());
		NetworkManager.Instance.SendRequest(request, Instance.OnDataReceived);
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
			AddType(typeof(Card));
			foreach (Card card in response.Data.Cards)
			{
				dataDict[typeof(Card)].Add(card.Id, card);
				//foreach (Property prop in card.Properties)
				//{
				//	object obj = SimpleJson.SimpleJson.DeserializeObject(prop.Json);
				//	Debug.LogError(string.Format("PropName : {0}  PropValue {1}",prop.Name,obj));
				//}
				Debug.LogError(string.Format("Card Id : {0}  Image {1}", card.Id, card.Image));
			}

			AddType(typeof(Chest));
			foreach (Chest chest in response.Data.Chests)
			{
				dataDict[typeof(Chest)].Add(chest.Id, chest);
				Debug.LogError(string.Format("Chest Name : {0}  Image {1}", chest.Name, chest.Image));
			}

			AddType(typeof(Reward));
			foreach (Reward reward in response.Data.Rewards)
			{
				dataDict[typeof(Reward)].Add(reward.Id, reward);
				Debug.LogError(string.Format("Reward ID : {0}  Type {1}", reward.RewardId, reward.Type));
			}

			AddType(typeof(GameElement));
			foreach (GameElement element in response.Data.Gameelements)
			{
				dataDict[typeof(GameElement)].Add(element.Id, element);
				Debug.LogError(string.Format("Game Element ID : {0}  Currency {1}", element.Id, element.Currency[0].Type));
			}
		}
	}
	
    void AddType(Type typ)
	{
		dataDict.Add(typ, new Dictionary<string, object>());
	}

	void CheckType(Type typ)
	{
		if (!dataDict.ContainsKey(typ))
		{
			AddType(typ);
		}
	}

	public object Get(Type type, string id)
	{
		CheckType(type);
		if (!dataDict[type].ContainsKey(id))
		{
			return null;
		}
		return dataDict[type][id];
	}

	public T Get<T>(string id)
	{
		return (T)Get(typeof(T), id);
	}

	public bool Has(Type type, string id)
	{
		CheckType(type);
		return dataDict[type].ContainsKey(id);
	}

	public IDictionary GetAll<T>()
	{
		return GetAll(typeof(T));
	}

	public IDictionary GetAll(Type type)
	{
		return dataDict[type];
	}

	public List<T> GetList<T>()
	{
		List<T> list = new List<T>();
		foreach (T item in GetAll<T>().Values)
		{
			list.Add(item);
		}
		return list;
	}
	
	public void Load(object obj, string id)
	{
		Type typ = obj.GetType();
		CheckType(typ);
		dataDict[typ][id] = obj;
	}

}
