using Prime31;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseManager : MonoBehaviour 
{

    public static string APIKey = @"MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAoiLz0e64N8x4SdDKf5AwpXQjFC3B5ACqGu4xGWCmmVy7wzqQjYU
                                    /tASFOnqWjuehQoqiPjcMeyl+If/gUILyYn6t4yBQbkyN9Re5NaYQeYpQGa/uCh2mMjd6I+tHlq24f1PUJMRoRMgeH+g+hf62
                                    cJa+L40CEmmqX1PhhB0bMZUcH68siS67UM/P1Vi9N7wSgs9SHdboHKABnzKuCAA5o6WjXxUJiei2oZRtsWzJpnghOuopxp7tr7fU
                                    LUubVYNq3PxN0z4gEImNPD+ulE9w2ufZjFMA68LyLP9k4H81KEhNUPm+MfsojaJAZicQA8fzFmk3bFwmZOp7Hakx9dqfowIDAQAB";


    public void Start()
    {
        IAP.init(APIKey);
    }

    public void PurchaseItem(string itemId)
    {

    }

}
