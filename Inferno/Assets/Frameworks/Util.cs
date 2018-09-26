using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;

public class Util
{

    public static byte[] ObjectToByteArray(object objectToConvert)
    {
        BinaryFormatter bf = new BinaryFormatter();
        MemoryStream stream = new MemoryStream();
        bf.Serialize(stream, objectToConvert);
        return stream.ToArray();
    }


	public static void Log(string log)
	{
#if LOG_ENABLED
		Debug.Log(log);
#endif
	}

	public static void LogError(string log)
	{
#if LOG_ENABLED
		Debug.LogError(log);
#endif
	}
}
