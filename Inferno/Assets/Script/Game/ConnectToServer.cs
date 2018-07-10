using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class ConnectToServer : MonoBehaviour 
{

    public WebSocket connection;
    public bool connectionError = false;
    public bool connectionClosed = false;
    public string connectionString = "";


	void Start () 
    {
        connection = new WebSocket(connectionString);
        connection.OnOpen += OnConnectionOpen;
        connection.OnMessage += OnMessegeReceived;
        connection.OnClose += OnConnectionClose;
        connection.OnError += OnConnectionError;
        connection.Connect();

	}

    private void OnConnectionError(object sender, ErrorEventArgs e)
    {
        print("OnConnectionError" + e.Message);
        throw new System.NotImplementedException();
    }

    private void OnConnectionClose(object sender, CloseEventArgs e)
    {
        print("OnConnectionClose");
        throw new System.NotImplementedException();
    }

    private void OnMessegeReceived(object sender, MessageEventArgs e)
    {
        print("OnMessegeReceived");
        throw new System.NotImplementedException();
    }

    private void OnConnectionOpen(object sender, System.EventArgs e)
    {
        print("OnConnectionOpen");
        throw new System.NotImplementedException();
    }
}
