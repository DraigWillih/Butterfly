using System;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour, IStoreListener
{
    public static IAPManager instance;

    private static IStoreController store_controller;
    private static IExtensionProvider extension_provider;

    public string remove_ads;
    public string packages_500;
    public string packages_800;
    public string packages_1200;
    public string packages_2000;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if(store_controller == null)
        {
            InitializePurchasing();
        }
    }

    private void InitializePurchasing()
    {
        if (IsInitialized())
        {
            return;
        }

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        // Aqui coloca os nossos produtos
        //builder.AddProduct(remove_ads, ProductType.NonConsumable);
        //builder.AddProduct(packages_500, ProductType.Consumable);
        //builder.AddProduct(packages_800, ProductType.Consumable);
        //builder.AddProduct(packages_1200, ProductType.Consumable);
        //builder.AddProduct(packages_2000, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);
    }

    private bool IsInitialized()
    {
        return store_controller != null && extension_provider != null;
    }

    private void BuyProductID(string id)
    {
        if (IsInitialized())
        {
            Product product = store_controller.products.WithID(id);

            if(product != null && product.availableToPurchase)
            {
                store_controller.InitiatePurchase(product);
            }
        }
    }

    public void BuyRemoveAds()
    {
        BuyProductID(remove_ads);
    }

    public void BuyPackage500()
    {
        BuyProductID(packages_500);
    }

    public void BuyPackage800()
    {
        BuyProductID(packages_800);
    }

    public void BuyPackage1200()
    {
        BuyProductID(packages_1200);
    }

    public void BuyPackage2000()
    {
        BuyProductID(packages_2000);
    }

    // inicialização
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        store_controller = controller;
        extension_provider = extensions;
    }

    // falha na inicialização
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        
    }

    // falha na compra
    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        
    }

    // compra realizada
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        if(String.Equals(purchaseEvent.purchasedProduct.definition.id, remove_ads, StringComparison.Ordinal))
        {
            // programação para remoção do ads
        }
        else if (String.Equals(purchaseEvent.purchasedProduct.definition.id, packages_500, StringComparison.Ordinal))
        {
            // programação para pacote de 500
        }
        else if (String.Equals(purchaseEvent.purchasedProduct.definition.id, packages_800, StringComparison.Ordinal))
        {
            // programação para pacote de 800
        }
        else if (String.Equals(purchaseEvent.purchasedProduct.definition.id, packages_1200, StringComparison.Ordinal))
        {
            // programação para pacote de 1200
        }
        else if (String.Equals(purchaseEvent.purchasedProduct.definition.id, packages_2000, StringComparison.Ordinal))
        {
            // programação para pacote de 2000
        }

        return PurchaseProcessingResult.Complete;
    }
}
