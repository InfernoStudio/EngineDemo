// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: SharedEnums.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Com.Inferno.Protos {

  /// <summary>Holder for reflection information generated from SharedEnums.proto</summary>
  public static partial class SharedEnumsReflection {

    #region Descriptor
    /// <summary>File descriptor for SharedEnums.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static SharedEnumsReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChFTaGFyZWRFbnVtcy5wcm90bxISY29tLmluZmVybm8ucHJvdG9zKpABCgtS",
            "ZXF1ZXN0VHlwZRIQCgxSRVFVRVNUX05PTkUQABILCgdTVEFSVFVQEAESEwoP",
            "Q1JFQVRFX05FV19VU0VSEAISEwoPTE9BRF9TVFJVQ1RVUkVTEAMSEwoPSU5f",
            "QVBQX1BVUkNIQVNFEAQSEgoOTE9BRF9HQU1FX0RBVEEQBRIPCgtSRVdBUkRf",
            "VVNFUhAGKuIBCgxSZXNwb25zZVR5cGUSEQoNUkVTUE9OU0VfTk9ORRAAEhQK",
            "EFNUQVJUVVBfUkVTUE9OU0UQARIcChhDUkVBVEVfTkVXX1VTRVJfUkVTUE9O",
            "U0UQAhIcChhMT0FEX1NUUlVDVFVSRVNfUkVTUE9OU0UQAxIcChhJTl9BUFBf",
            "UFVSQ0hBU0VfUkVTUE9OU0UQBBIbChdMT0FEX0dBTUVfREFUQV9SRVNQT05T",
            "RRAFEhgKFFJFV0FSRF9VU0VSX1JFU1BPTlNFEAYSGAoUVVNFUl9VUERBVEVf",
            "UkVTUE9OU0UQBypRCg5SZXNwb25zZVN0YXR1cxIYChRSRVNQT05TRV9TVEFU",
            "VVNfTk9ORRAAEgsKB1NVQ0NFU1MQARIICgRGQUlMEAISDgoKVVNFUl9FWElT",
            "VBADQg1CC1NoYXJlZEVudW1zYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::Com.Inferno.Protos.RequestType), typeof(global::Com.Inferno.Protos.ResponseType), typeof(global::Com.Inferno.Protos.ResponseStatus), }, null));
    }
    #endregion

  }
  #region Enums
  public enum RequestType {
    [pbr::OriginalName("REQUEST_NONE")] RequestNone = 0,
    [pbr::OriginalName("STARTUP")] Startup = 1,
    [pbr::OriginalName("CREATE_NEW_USER")] CreateNewUser = 2,
    [pbr::OriginalName("LOAD_STRUCTURES")] LoadStructures = 3,
    [pbr::OriginalName("IN_APP_PURCHASE")] InAppPurchase = 4,
    [pbr::OriginalName("LOAD_GAME_DATA")] LoadGameData = 5,
    [pbr::OriginalName("REWARD_USER")] RewardUser = 6,
  }

  public enum ResponseType {
    [pbr::OriginalName("RESPONSE_NONE")] ResponseNone = 0,
    [pbr::OriginalName("STARTUP_RESPONSE")] StartupResponse = 1,
    [pbr::OriginalName("CREATE_NEW_USER_RESPONSE")] CreateNewUserResponse = 2,
    [pbr::OriginalName("LOAD_STRUCTURES_RESPONSE")] LoadStructuresResponse = 3,
    [pbr::OriginalName("IN_APP_PURCHASE_RESPONSE")] InAppPurchaseResponse = 4,
    [pbr::OriginalName("LOAD_GAME_DATA_RESPONSE")] LoadGameDataResponse = 5,
    [pbr::OriginalName("REWARD_USER_RESPONSE")] RewardUserResponse = 6,
    [pbr::OriginalName("USER_UPDATE_RESPONSE")] UserUpdateResponse = 7,
  }

  public enum ResponseStatus {
    [pbr::OriginalName("RESPONSE_STATUS_NONE")] None = 0,
    [pbr::OriginalName("SUCCESS")] Success = 1,
    [pbr::OriginalName("FAIL")] Fail = 2,
    [pbr::OriginalName("USER_EXIST")] UserExist = 3,
  }

  #endregion

}

#endregion Designer generated code
