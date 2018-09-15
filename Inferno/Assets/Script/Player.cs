using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Player
{
	public string name;
	public string fb_id;
	public string udid;
	public string platform;
}

public class Message
{
	public string id;
	public string type;
	public object message;

	public Message()
	{
		id = Guid.NewGuid().ToString();
	}
}
