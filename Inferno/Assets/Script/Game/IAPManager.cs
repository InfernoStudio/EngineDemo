
using Google.Protobuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prime31;
using Com.Inferno.Protos;
using System;
public class IAPManager 
{
    protected static IAPManager _instance;

    private IAPManager()
    {

    }

    public static IAPManager Instance
    {
        get 
        {
            if(_instance == null)
                _instance = new IAPManager();

            return _instance;
        }
    }

    private string[] productIdList = new string[]{"com.infernostudio.thebee.product100",
                                                        "com.infernostudio.thebee.product1",
                                                        "com.infernostudio.thebee.product5",
                                                        "com.infernostudio.thebee.product10",
                                                        "com.infernostudio.thebee.product20",
                                                        "com.infernostudio.thebee.product50"};

    private const string _androidPublicKey = @"MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAsXazPG9VU4RJtBYan0R5E9+rLIu6L+SgzaqfxCS9Uji77xYtm6q0eJDKPFZTtxWXNNE3gz01tFwwAoT5f8xAMoS5CotvxTqVe6Lyaez5ZiTZDLw1qodt
                                            /jsRg8E8MzzeI5hEz2TlV9kinMdqDaD9x6RqjuIgxT22Ma41Q8I7CJHlzwVpt7t1+5r1EFJ54s6xciCOoW4cF63y/olRh27LJciMfaZLnLFNueiygMFF7ds4I5ED0dEfHBaw32Iiv+9S1Van4hBy2QRRTexyCoNVI68lusE5jvRmdVZStnKKQ
                                            /3FiLInupvQNonGL5u9jgpDKVgn3fBJANd+quU19pY/EwIDAQAB"; 
    private List<IAPProduct> _productList;



    public void Init()
    {
        productIdList = new string[]{"com.infernostudio.thebee.product100",
                                                        "com.infernostudio.thebee.product1",
                                                        "com.infernostudio.thebee.product5",
                                                        "com.infernostudio.thebee.product10",
                                                        "com.infernostudio.thebee.product20",
                                                        "com.infernostudio.thebee.product50"};

        IAP.init(_androidPublicKey);
    }
    public void RequestProductData()
    {
        IAP.requestProductData(null, productIdList, OnProductListReceived);
    }



    public void PurchaseProduct(string productId)
    {
        IAP.purchaseConsumableProduct(productId,OnPurchaseComplete,OnVerify);
    }

    private void OnPurchaseComplete(bool status, string errorMessege)
    {
        if(status)
        {
            Debug.Log("Purchase Successful");
        }
    }

    private void OnProductListReceived(List<IAPProduct> productList)
    {
        _productList = productList;
    }

    private void OnVerify(bool status, GooglePurchase purchase)
    {
        if(status)
        {
            Debug.Log(" ######## Verifying purchase with our server ######## ");
            InAppPurchase builder = new InAppPurchase();
            builder.Receipt = purchase.originalJson;
            builder.Id = Guid.NewGuid().ToString();
		
            Request req = RequestGenerator.CreateRequest(RequestType.CreateNewUser, builder.ToByteString());
            NetworkManager.Instance.SendRequest(req,OnVerifyComplete);
        }
    }

    public void OnVerifyComplete(string eventId)
    {
       // Debug.Log();
    }



}
