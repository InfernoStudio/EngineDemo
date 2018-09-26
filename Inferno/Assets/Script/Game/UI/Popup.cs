using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public abstract class Popup : MonoBehaviour
{

	public abstract void Open();
	public abstract void Close();
	public abstract void SetProperties(Hashtable properties);
}
