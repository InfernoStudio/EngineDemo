using Google.Protobuf;
using Com.Inferno.Protos;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class RequestGenerator
{
    public const int REQUEST_SIZE = 4;
    public string uuid;
    public int type;
    public byte[] payload;

    /// <summary>
    /// Takes request type and payload as argument and
    /// returns ref outs request byte array
    /// </summary>
    /// <param name="type"></param>
    /// <param name="payload"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    public static Request CreateRequest(RequestType type,ByteString payload)
    {
        Request reqBuilder = new Request();
        reqBuilder.Id = System.Guid.NewGuid().ToString();
        reqBuilder.Type = type;
        reqBuilder.Payload = payload;
        return reqBuilder;
    }

   
}
