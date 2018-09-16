using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whiteboard
{
	private static Hashtable board = new Hashtable();
	private static Whiteboard _Instance;

	private Whiteboard()
	{

	}

	public static Whiteboard Instance
	{
		get
		{
			if (_Instance == null)
				_Instance = new Whiteboard();
			return _Instance;
		}
	}

	public static void SetProperty(object key, object value)
	{
		if (board.ContainsKey(key))
			board[key] = value;
		else
			board.Add(key, value);
	}
	

	public static T Get<T>(object key)
	{
		if (board.ContainsKey(key) && board[key] is T)
			return (T)board[key];
		return default(T);
	}
	
}
