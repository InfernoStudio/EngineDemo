using Com.Inferno.Protos;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using Google.Protobuf;


public class NetworkManager : MonoBehaviour 
{
    public static NetworkManager Instance;
    public WebSocket connection;
    public bool connectionError = false;
    public bool connectionClosed = false;
#if PRODUCTION
	public string connectionString = "ws://localhost:3000";
#elif STAGING
	public string connectionString = "ws://ec2-18-191-173-186.us-east-2.compute.amazonaws.com:9000";
#else
	public string connectionString = "ws://localhost:9000";
#endif

	public bool responseReceived = true;

    private Dictionary<string, System.Action<string>> _actionDict = new Dictionary<string, System.Action<string>>();
    private List<object> _responseRecievedList = new List<object>();
	private List<string> _responseIdsReceived = new List<string>();

	private Dictionary<string, List<object>> requestIdsToResponsesList = new Dictionary<string, List<object>>();

	public void Awake()
	{
		Instance = this;
		DontDestroyOnLoad(gameObject);
		connection = new WebSocket(connectionString);
		connection.OnOpen += OnConnectionOpen;
		connection.OnMessage += OnMessegeReceived;
		connection.OnClose += OnConnectionClose;
		connection.OnError += OnConnectionError;
		connection.Connect();

		DontDestroyOnLoad(gameObject);
	}

	void Start () 
    {
	}
    int count = 0;
    void SendRandomMessege()
    {
        if(connection.IsAlive)
        {
            string ping = "Ping : " + count;
            connection.Send(ping);
            count++;
        }
    }

    int reconnectAttempts = 0;

    public void TryReconnect()
    {
        reconnectAttempts++;
        Debug.Log(string.Format("Trying to Reconnect Attempt {0} ", reconnectAttempts));
        connection.Connect();
        connectionClosed = false;
        connectionError = false;
    }

    public void SendRequest(Request request,System.Action<string> callback)
    {
        int size = request.CalculateSize();

        byte[] eventBytes = request.ToByteArray();
        byte[] header = new byte[RequestGenerator.REQUEST_SIZE];

        // This is Little Endian
        header[3] = (byte)(size & 0xFF);
        header[2] = (byte)((size & 0xFF00) >> 8);
        header[1] = (byte)((size & 0xFF0000) >> 16);
        header[0] = (byte)((size & 0xFF000000) >> 24);

        byte[] msg = new byte[RequestGenerator.REQUEST_SIZE + size];

        int i = 0;
        int j = 0;

        for (; i < RequestGenerator.REQUEST_SIZE; i++)
        {
            msg[i] = header[i];
        }
        for (; i < (RequestGenerator.REQUEST_SIZE + size); j++, i++)
        {
            msg[i] = eventBytes[j];
        }
        Debug.Log("Message Length ------>" + msg.Length);
        connection.Send(msg);

        _actionDict.Add(request.Id, callback);
    }

    private void OnConnectionError(object sender, ErrorEventArgs e)
    {
        Debug.Log(string.Format("Error Occured {0} ", e.Message));
        connectionError = true;
    }

    private void OnConnectionClose(object sender, CloseEventArgs e)
    {
        Debug.Log(string.Format("Connection Closed {0} ", e.Reason));
        connectionClosed = true; 
    }

    private void OnMessegeReceived(object sender, MessageEventArgs e)
    {
        Debug.Log(string.Format("Messege Received from server {0} ", e.RawData));

		byte[] response = e.RawData;

        int cursor = 0;

		while (cursor < response.Length)
		{
			int j = 0;
			int headerIndex = 0;
			byte[] header = new byte[RequestGenerator.REQUEST_SIZE];
			int headerEnd = (cursor + RequestGenerator.REQUEST_SIZE);
			for (; cursor < headerEnd; headerIndex++, cursor++)
			{
				header[headerIndex] = response[cursor];
			}

			//Array.Reverse(header);
			int size = BitConverter.ToInt32(header, 0);

			byte[] evtRequest = new byte[size];
			int i = 0;
			int msgEnd = (cursor + size);
			for (; cursor < msgEnd; cursor++, i++)
			{
				evtRequest[i] = response[cursor];
			}

			Response proto = Response.Parser.ParseFrom(evtRequest);
			object responsePayloadObject = HandleResponse(proto);

			if (requestIdsToResponsesList.ContainsKey(proto.Id))
			{
				requestIdsToResponsesList[proto.Id].Add(responsePayloadObject);
			}
			else
			{
				requestIdsToResponsesList.Add(proto.Id, new List<object>());
				requestIdsToResponsesList[proto.Id].Add(responsePayloadObject);
			}
			_responseIdsReceived.Add(proto.Id);
		}
	}

    public object HandleResponse(Response response)
    {
        switch(response.Type)
        {
            case ResponseType.CreateNewUserResponse:
                return CreateUserResponseProto.Parser.ParseFrom(response.Payload);
			case ResponseType.StartupResponse:
				return StartUpResponse.Parser.ParseFrom(response.Payload);
			case ResponseType.LoadGameDataResponse:
				return DataResponse.Parser.ParseFrom(response.Payload);
			case ResponseType.RewardUserResponse:
				return RewardEvent.Parser.ParseFrom(response.Payload);
			case ResponseType.UserUpdateResponse:
				return UserUpdateResponse.Parser.ParseFrom(response.Payload);
			default:
                return null;
        }
    }

    private void OnConnectionOpen(object sender, System.EventArgs e)
    {
        Debug.Log(string.Format("Connection to {0} is opened", connection.Url));
        CancelInvoke("TryReconnect");
        connectionClosed = false;
        connectionError = false;
    }

	public T GetResponse<T>(string requestId)
	{
		object response = null;

		if (requestIdsToResponsesList.ContainsKey(requestId))
		{
			List<object> responses = requestIdsToResponsesList[requestId];

			for (int i = 0; i < responses.Count; i++)
			{
				if (responses[i] is T)
				{
					response = responses[i];
					responses[i] = null;
				}
			}

			responses.RemoveAll(item => item == null);
			return (T)response;
		}

		return (T)response;
	}
	
    public void Update()
    { 
        if(connectionError || connectionClosed)
        {
            TryReconnect();
            connectionError = false;
            connectionClosed = false;
        }

		for (int i = 0; i < _responseIdsReceived.Count; i++)
		{
			string id = _responseIdsReceived[i];
			if (_actionDict.ContainsKey(id))
			{
				_actionDict[id](id);
				_actionDict.Remove(id);
				_responseIdsReceived[i] = null;
			}
		}
		_responseIdsReceived.RemoveAll(item => item == null);
    }
}
