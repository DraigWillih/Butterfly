using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProductType { RemoveAds, Package500, Package800, Package1200, Package2000}

public class PurchaseController : MonoBehaviour
{
    public ProductType product_type;

    public void OnClickButton()
    {
        switch (product_type)
        {
            case ProductType.RemoveAds:
                IAPManager.instance.BuyRemoveAds();
                break;

            case ProductType.Package500:
                IAPManager.instance.BuyPackage500();
                break;

            case ProductType.Package800:
                IAPManager.instance.BuyPackage800();
                break;

            case ProductType.Package1200:
                IAPManager.instance.BuyPackage1200();
                break;

            case ProductType.Package2000:
                IAPManager.instance.BuyPackage2000();
                break;
        }
    }
}
