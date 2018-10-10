using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Schema
{

	public class Reward
	{
		public const string Id = "id";
		public const string RewardId = "rwid";
		public const string Type = "type";
		public const string Count = "count";

	}

	public class RewardTypes
	{
		public const string CHEST = "chest";
		public const string CARD = "card";
		public const string CUSTOM = "cus";
		public const string GOLD = "gold";
		public const string GEM = "gem";
	}

}
