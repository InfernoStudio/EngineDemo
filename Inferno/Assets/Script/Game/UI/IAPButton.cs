using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPButton : MonoBehaviour 
{
    public string productId;



    public void OnClick()
    {
        IAPManager.Instance.PurchaseProduct(productId);
    }
}
