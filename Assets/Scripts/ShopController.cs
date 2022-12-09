using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

enum categories { 
    cloth,
    hat,
    food
}

struct CurrentState {
    public categories currentCategory;
    public int clickedItemIdx;

    public CurrentState(categories currentCategory, int clickedItemIdx)
    {
        this.currentCategory = currentCategory;
        this.clickedItemIdx = clickedItemIdx;
    }
}

public class ShopController : MonoBehaviour
{
    private DataController dataController = DataController.Instance;

    public GameObject shopRabbit; // ¿ÊÀÔÈ÷±â Åä³¢

    public Button buyBtn;
    public Button reBtn;

    public Button clothCategoryBtn;
    public Button HatCategoryBtn;
    public Button FoodCatgoryBtn;
    
    public GameObject content;
    public GameObject shopClothesData;
    public GameObject shopHatsData;
    public GameObject shopFoodsData;

    public GameObject originWornData;
    public GameObject ClothWornData;
    public GameObject HatWornData;
    public GameObject FoodWornData;

    private CurrentState currentState = new CurrentState(categories.cloth, -1);


    // Start is called before the first frame update
    void Start()
    {
        reBtn.onClick.AddListener(onClickReBtn);
        buyBtn.onClick.AddListener(onClickBuyBtn);

        clothCategoryBtn.onClick.AddListener(onClickClothCategory);
        HatCategoryBtn.onClick.AddListener(onClickHatCategory);
        FoodCatgoryBtn.onClick.AddListener(onClickFoodCategory);
        for (int i = 0; i < content.transform.childCount; i++)
        {
            content.transform.GetChild(i).GetComponent<Button>().onClick.AddListener(onClickItem);
        }
        updateContent(shopClothesData);
    }

    void onClickBuyBtn()
    {
        dataController.saveInventory();
        /*
        Debug.Log("cloth_inventory: ");
        for (int i = 0; i < dataController.clothItems_inventory.Length ; i++){
            Debug.Log(dataController.clothItems_inventory[i]);

        }
        Debug.Log("hat_inventory: ");
        for (int i = 0; i < dataController.hatItems_inventory.Length; i++)
        {
            Debug.Log(dataController.hatItems_inventory[i]);

        }
        Debug.Log("food_inventory: ");
        for (int i = 0; i < dataController.foodItems_inventory.Length; i++)
        {
            Debug.Log(dataController.foodItems_inventory[i]);

        }
        */
   
    }

    void onClickReBtn()
    {
        dataController.clothItem_shopSelected = -1;
        dataController.hatItem_shopSelected = -1;
        // ¿Ê ¿ø»óÅÂ·Î ¹Ù²Ù±â
        SpriteRenderer rabbitClothPart = shopRabbit.transform.GetChild((int)categories.cloth).GetComponent<SpriteRenderer>();
        rabbitClothPart.sprite = originWornData.transform.GetChild((int)categories.cloth).GetComponent<SpriteRenderer>().sprite;
        // ¸Ó¸® ¿ø»óÅÂ·Î ¹Ù²Ù±â
        SpriteRenderer rabbitClothHat = shopRabbit.transform.GetChild((int)categories.hat).GetComponent<SpriteRenderer>();
        rabbitClothHat.sprite = originWornData.transform.GetChild((int)categories.hat).GetComponent<SpriteRenderer>().sprite;
    }

    void onClickItem()
    {
        GameObject clickedItem = EventSystem.current.currentSelectedGameObject;
        currentState.clickedItemIdx = clickedItem.transform.GetSiblingIndex();
        SpriteRenderer rabbitBody = shopRabbit.transform.GetChild((int)currentState.currentCategory).GetComponent<SpriteRenderer>();
        Sprite childSprite;
        if (currentState.currentCategory == categories.cloth) {
            if(dataController == null)
            {
                Debug.Log("dataController ³ÎÀÓ");
            }
            dataController.clothItem_shopSelected = currentState.clickedItemIdx;
            childSprite = ClothWornData.transform.GetChild(currentState.clickedItemIdx).GetComponent<SpriteRenderer>().sprite;
            rabbitBody.sprite = childSprite;
        } else if (currentState.currentCategory == categories.hat)
        {
            dataController.hatItem_shopSelected = currentState.clickedItemIdx;
            childSprite = HatWornData.transform.GetChild(currentState.clickedItemIdx).GetComponent<SpriteRenderer>().sprite;
            rabbitBody.sprite = childSprite;
        } else if (currentState.currentCategory == categories.food) return;

    }

    void onClickClothCategory()
    {
        clothCategoryBtn.transform.GetChild(0).GetComponent<Text>().color = new Color32(255, 192, 189, 255); // »¡°­»ö ±Û¾¾·Î
        HatCategoryBtn.transform.GetChild(0).GetComponent<Text>().color = new Color32(154, 154, 154, 255); // È¸»ö ±Û¾¾·Î
        FoodCatgoryBtn.transform.GetChild(0).GetComponent<Text>().color = new Color32(154, 154, 154, 255); // È¸»ö ±Û¾¾·Î
        currentState.currentCategory = categories.cloth;
        updateContent(shopClothesData);
    }

    void onClickHatCategory()
    {
        clothCategoryBtn.transform.GetChild(0).GetComponent<Text>().color = new Color32(154, 154, 154, 255); // È¸»ö ±Û¾¾·Î
        HatCategoryBtn.transform.GetChild(0).GetComponent<Text>().color = new Color32(255, 192, 189, 255); // »¡°­»ö ±Û¾¾·Î
        FoodCatgoryBtn.transform.GetChild(0).GetComponent<Text>().color = new Color32(154, 154, 154, 255); // È¸»ö ±Û¾¾·Î
        currentState.currentCategory = categories.hat;
        updateContent(shopHatsData);
    }

    void onClickFoodCategory()
    {
        clothCategoryBtn.transform.GetChild(0).GetComponent<Text>().color = new Color32(154, 154, 154, 255); // È¸»ö±Û¾¾·Î
        HatCategoryBtn.transform.GetChild(0).GetComponent<Text>().color = new Color32(154, 154, 154, 255); // È¸»ö ±Û¾¾·Î
        FoodCatgoryBtn.transform.GetChild(0).GetComponent<Text>().color = new Color32(255, 192, 189, 255); // »¡°­»ö ±Û¾¾·Î
        currentState.currentCategory = categories.food;
        updateContent(shopFoodsData);
    }

    void updateContent(GameObject parentObject)
    {
        for(int i = 0; i < parentObject.transform.childCount; i++)
        {
            Image contentImg = content.transform.GetChild(i).GetComponent<Image>();
            Sprite childSprite = parentObject.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite;
            contentImg.sprite = childSprite;
        }
        
        for (int i = parentObject.transform.childCount; i < content.transform.childCount; i++)
        {
            Image contentImg = content.transform.GetChild(i).GetComponent<Image>();
            contentImg.sprite = null;
        }

    }

}
