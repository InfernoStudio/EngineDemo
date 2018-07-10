// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: User.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Com.Inferno.Protos {

  /// <summary>Holder for reflection information generated from User.proto</summary>
  public static partial class UserReflection {

    #region Descriptor
    /// <summary>File descriptor for User.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static UserReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CgpVc2VyLnByb3RvEhJjb20uaW5mZXJuby5wcm90b3MaEVNoYXJlZEVudW1z",
            "LnByb3RvIj0KBFVzZXISCgoCaWQYASABKAkSDAoEbmFtZRgCIAEoCRINCgVm",
            "Yl9pZBgDIAEoCRIMCgR1ZGlkGAQgASgJIkMKClVzZXJDcmVhdGUSCgoCaWQY",
            "ASABKAkSDAoEbmFtZRgCIAEoCRINCgVmYl9pZBgDIAEoCRIMCgR1ZGlkGAQg",
            "ASgJIm8KF0NyZWF0ZVVzZXJSZXNwb25zZVByb3RvEg8KB21lc3NlZ2UYASAB",
            "KAkSMgoGc3RhdHVzGAIgASgOMiIuY29tLmluZmVybm8ucHJvdG9zLlJlc3Bv",
            "bnNlU3RhdHVzEg8KB3BheWxvYWQYAyABKAxCDEIKVXNlclByb3Rvc2IGcHJv",
            "dG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Com.Inferno.Protos.SharedEnumsReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Com.Inferno.Protos.User), global::Com.Inferno.Protos.User.Parser, new[]{ "Id", "Name", "FbId", "Udid" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Com.Inferno.Protos.UserCreate), global::Com.Inferno.Protos.UserCreate.Parser, new[]{ "Id", "Name", "FbId", "Udid" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Com.Inferno.Protos.CreateUserResponseProto), global::Com.Inferno.Protos.CreateUserResponseProto.Parser, new[]{ "Messege", "Status", "Payload" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class User : pb::IMessage<User> {
    private static readonly pb::MessageParser<User> _parser = new pb::MessageParser<User>(() => new User());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<User> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Com.Inferno.Protos.UserReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public User() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public User(User other) : this() {
      id_ = other.id_;
      name_ = other.name_;
      fbId_ = other.fbId_;
      udid_ = other.udid_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public User Clone() {
      return new User(this);
    }

    /// <summary>Field number for the "id" field.</summary>
    public const int IdFieldNumber = 1;
    private string id_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Id {
      get { return id_; }
      set {
        id_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 2;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "fb_id" field.</summary>
    public const int FbIdFieldNumber = 3;
    private string fbId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string FbId {
      get { return fbId_; }
      set {
        fbId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "udid" field.</summary>
    public const int UdidFieldNumber = 4;
    private string udid_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Udid {
      get { return udid_; }
      set {
        udid_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as User);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(User other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Id != other.Id) return false;
      if (Name != other.Name) return false;
      if (FbId != other.FbId) return false;
      if (Udid != other.Udid) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Id.Length != 0) hash ^= Id.GetHashCode();
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (FbId.Length != 0) hash ^= FbId.GetHashCode();
      if (Udid.Length != 0) hash ^= Udid.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Id.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Id);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Name);
      }
      if (FbId.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(FbId);
      }
      if (Udid.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(Udid);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Id.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Id);
      }
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (FbId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(FbId);
      }
      if (Udid.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Udid);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(User other) {
      if (other == null) {
        return;
      }
      if (other.Id.Length != 0) {
        Id = other.Id;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.FbId.Length != 0) {
        FbId = other.FbId;
      }
      if (other.Udid.Length != 0) {
        Udid = other.Udid;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            Id = input.ReadString();
            break;
          }
          case 18: {
            Name = input.ReadString();
            break;
          }
          case 26: {
            FbId = input.ReadString();
            break;
          }
          case 34: {
            Udid = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class UserCreate : pb::IMessage<UserCreate> {
    private static readonly pb::MessageParser<UserCreate> _parser = new pb::MessageParser<UserCreate>(() => new UserCreate());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<UserCreate> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Com.Inferno.Protos.UserReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UserCreate() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UserCreate(UserCreate other) : this() {
      id_ = other.id_;
      name_ = other.name_;
      fbId_ = other.fbId_;
      udid_ = other.udid_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UserCreate Clone() {
      return new UserCreate(this);
    }

    /// <summary>Field number for the "id" field.</summary>
    public const int IdFieldNumber = 1;
    private string id_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Id {
      get { return id_; }
      set {
        id_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 2;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "fb_id" field.</summary>
    public const int FbIdFieldNumber = 3;
    private string fbId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string FbId {
      get { return fbId_; }
      set {
        fbId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "udid" field.</summary>
    public const int UdidFieldNumber = 4;
    private string udid_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Udid {
      get { return udid_; }
      set {
        udid_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as UserCreate);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(UserCreate other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Id != other.Id) return false;
      if (Name != other.Name) return false;
      if (FbId != other.FbId) return false;
      if (Udid != other.Udid) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Id.Length != 0) hash ^= Id.GetHashCode();
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (FbId.Length != 0) hash ^= FbId.GetHashCode();
      if (Udid.Length != 0) hash ^= Udid.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Id.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Id);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Name);
      }
      if (FbId.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(FbId);
      }
      if (Udid.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(Udid);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Id.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Id);
      }
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (FbId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(FbId);
      }
      if (Udid.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Udid);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(UserCreate other) {
      if (other == null) {
        return;
      }
      if (other.Id.Length != 0) {
        Id = other.Id;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.FbId.Length != 0) {
        FbId = other.FbId;
      }
      if (other.Udid.Length != 0) {
        Udid = other.Udid;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            Id = input.ReadString();
            break;
          }
          case 18: {
            Name = input.ReadString();
            break;
          }
          case 26: {
            FbId = input.ReadString();
            break;
          }
          case 34: {
            Udid = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class CreateUserResponseProto : pb::IMessage<CreateUserResponseProto> {
    private static readonly pb::MessageParser<CreateUserResponseProto> _parser = new pb::MessageParser<CreateUserResponseProto>(() => new CreateUserResponseProto());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<CreateUserResponseProto> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Com.Inferno.Protos.UserReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CreateUserResponseProto() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CreateUserResponseProto(CreateUserResponseProto other) : this() {
      messege_ = other.messege_;
      status_ = other.status_;
      payload_ = other.payload_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CreateUserResponseProto Clone() {
      return new CreateUserResponseProto(this);
    }

    /// <summary>Field number for the "messege" field.</summary>
    public const int MessegeFieldNumber = 1;
    private string messege_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Messege {
      get { return messege_; }
      set {
        messege_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "status" field.</summary>
    public const int StatusFieldNumber = 2;
    private global::Com.Inferno.Protos.ResponseStatus status_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Com.Inferno.Protos.ResponseStatus Status {
      get { return status_; }
      set {
        status_ = value;
      }
    }

    /// <summary>Field number for the "payload" field.</summary>
    public const int PayloadFieldNumber = 3;
    private pb::ByteString payload_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString Payload {
      get { return payload_; }
      set {
        payload_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as CreateUserResponseProto);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(CreateUserResponseProto other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Messege != other.Messege) return false;
      if (Status != other.Status) return false;
      if (Payload != other.Payload) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Messege.Length != 0) hash ^= Messege.GetHashCode();
      if (Status != 0) hash ^= Status.GetHashCode();
      if (Payload.Length != 0) hash ^= Payload.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Messege.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Messege);
      }
      if (Status != 0) {
        output.WriteRawTag(16);
        output.WriteEnum((int) Status);
      }
      if (Payload.Length != 0) {
        output.WriteRawTag(26);
        output.WriteBytes(Payload);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Messege.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Messege);
      }
      if (Status != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Status);
      }
      if (Payload.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(Payload);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(CreateUserResponseProto other) {
      if (other == null) {
        return;
      }
      if (other.Messege.Length != 0) {
        Messege = other.Messege;
      }
      if (other.Status != 0) {
        Status = other.Status;
      }
      if (other.Payload.Length != 0) {
        Payload = other.Payload;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            Messege = input.ReadString();
            break;
          }
          case 16: {
            status_ = (global::Com.Inferno.Protos.ResponseStatus) input.ReadEnum();
            break;
          }
          case 26: {
            Payload = input.ReadBytes();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
