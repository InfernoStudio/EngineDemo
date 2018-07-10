using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

public class Util
{

    public static byte[] ObjectToByteArray(object objectToConvert)
    {
        BinaryFormatter bf = new BinaryFormatter();
        MemoryStream stream = new MemoryStream();
        bf.Serialize(stream, objectToConvert);
        return stream.ToArray();
    }
}
