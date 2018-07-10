using UnityEngine;
using System.Collections;
using Prime31;



namespace Prime31
{
	public class IAPComboUI : MonoBehaviourGUI
	{
#if UNITY_IOS || UNITY_ANDROID
		void OnGUI()
		{
			beginColumn();
	
			if( GUILayout.Button( "Init IAP System" ) )
			{
				var key = "your public key from the Android developer portal here";
                key = @"MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAoiLz0e64N8x4SdDKf5AwpXQjFC3B5ACqGu4xGWCmmVy7wzqQjYU
                                    /tASFOnqWjuehQoqiPjcMeyl+If/gUILyYn6t4yBQbkyN9Re5NaYQeYpQGa/uCh2mMjd6I+tHlq24f1PUJMRoRMgeH+g+hf62
                                    cJa+L40CEmmqX1PhhB0bMZUcH68siS67UM/P1Vi9N7wSgs9SHdboHKABnzKuCAA5o6WjXxUJiei2oZRtsWzJpnghOuopxp7tr7fU
                                    LUubVYNq3PxN0z4gEImNPD+ulE9w2ufZjFMA68LyLP9k4H81KEhNUPm+MfsojaJAZicQA8fzFmk3bFwmZOp7Hakx9dqfowIDAQAB";
				IAP.init( key );
			}
	
	
			if( GUILayout.Button( "Request Product Data" ) )
			{
                var androidSkus = new string[] {"me.titan.toonsquad.gem1",
                                                "me.titan.toonsquad.gem2", 
                                                "me.titan.toonsquad.gem3",
                                                "me.titan.toonsquad.gem4",
                                                "me.titan.toonsquad.gem5",
                                                "me.titan.toonsquad.sale5",
                                                "me.titan.toonsquad.sale10",
                                                "me.titan.toonsquad.sale20",
                                                "me.titan.toonsquad.sale50",
                                                "me.titan.toonsquad.sale100",
                                                "me.titan.toonsquad.gachamultispin1",
                                                "me.titan.toonsquad.moneytreewithsale",
                                                "me.titan.toonsquad.moneytreenosale1",
                                                "me.titan.toonsquad.starterbuilderpack",
                                                "me.titan.toonsquad.starterpack",
                                                "me.titan.toonsquad.builderpack"
                };

                Debug.Log("No of product IDs " + androidSkus.Length);
				var iosProductIds = new string[] { "anotherProduct", "tt", "testProduct", "sevenDays", "oneMonthSubsciber" };
	
				IAP.requestProductData( iosProductIds, androidSkus, productList =>
				{
					Debug.Log( "Product list received" );
                    Debug.Log("Product list count" + productList.Count);
                    foreach (var product in productList)
                    {
                        Debug.Log(string.Format(" Product ID : {0} Product Name : {1} Product Price : {2}", product.productId, product.title, product.price));
                    }
                    
                    Utils.logObject( productList );

                   

				});
			}
	
	
			if( GUILayout.Button( "Restore Transactions (iOS only)" ) )
			{
				IAP.restoreCompletedTransactions( productId =>
				{
					Debug.Log( "restored purchased product: " + productId );
				});
			}
	
	
			if( GUILayout.Button( "Purchase Consumable" ) )
			{
#if UNITY_ANDROID
			var productId = "me.titan.toonsquad.gem1";
#elif UNITY_IOS
			var productId = "testProduct";
#endif
				IAP.purchaseConsumableProduct( productId, ( didSucceed, error ) =>
				{
					Debug.Log( "purchasing product " + productId + " result: " + didSucceed );
					
					if( !didSucceed )
						Debug.Log( "purchase error: " + error );
				});
			}
	
	
			if( GUILayout.Button( "Purchase Non-Consumable" ) )
			{
#if UNITY_ANDROID
                var productId = "me.titan.toonsquad.gem2";
#elif UNITY_IOS
			var productId = "tt";
#endif
				IAP.purchaseNonconsumableProduct( productId, ( didSucceed, error ) =>
				{
					Debug.Log( "purchasing product " + productId + " result: " + didSucceed );
					
					if( !didSucceed )
						Debug.Log( "purchase error: " + error );
				});
			}
	
			endColumn();
		}
#endif
	}

}
