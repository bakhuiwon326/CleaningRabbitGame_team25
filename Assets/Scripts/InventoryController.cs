using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    private DataController dataController = DataController.Instance;

    public Button clothCategoryBtn;
    public Button HatCategoryBtn;
    public Button FoodCatgoryBtn;

    public GameObject content;

    public GameObject clothData;
    public GameObject hatData;
    public GameObject foodData;

    void Start()
    {
        clothCategoryBtn.onClick.AddListener(onClickClothCategory);
        HatCategoryBtn.onClick.AddListener(onClickHatCategory);
        FoodCatgoryBtn.onClick.AddListener(onClickFoodCategory);
        updateContent_cloth();
    }


    void onClickClothCategory()
    {
        clothCategoryBtn.transform.GetChild(0).GetComponent<Text>().color = new Color32(255, 192, 189, 255); // »¡°­»ö ±Û¾¾·Î
        HatCategoryBtn.transform.GetChild(0).GetComponent<Text>().color = new Color32(154, 154, 154, 255); // È¸»ö ±Û¾¾·Î
        FoodCatgoryBtn.transform.GetChild(0).GetComponent<Text>().color = new Color32(154, 154, 154, 255); // È¸»ö ±Û¾¾·Î
        updateContent_cloth();
    }

    void onClickHatCategory()
    {
        clothCategoryBtn.transform.GetChild(0).GetComponent<Text>().color = new Color32(154, 154, 154, 255); // È¸»ö ±Û¾¾·Î
        HatCategoryBtn.transform.GetChild(0).GetComponent<Text>().color = new Color32(255, 192, 189, 255); // »¡°­»ö ±Û¾¾·Î
        FoodCatgoryBtn.transform.GetChild(0).GetComponent<Text>().color = new Color32(154, 154, 154, 255); // È¸»ö ±Û¾¾·Î
        updateContent_hat();
    }

    void onClickFoodCategory()
    {
        clothCategoryBtn.transform.GetChild(0).GetComponent<Text>().color = new Color32(154, 154, 154, 255); // È¸»ö±Û¾¾·Î
        HatCategoryBtn.transform.GetChild(0).GetComponent<Text>().color = new Color32(154, 154, 154, 255); // È¸»ö ±Û¾¾·Î
        FoodCatgoryBtn.transform.GetChild(0).GetComponent<Text>().color = new Color32(255, 192, 189, 255); // »¡°­»ö ±Û¾¾·Î
        updateContent_food();
    }

    void updateContent_cloth()
    {
        int contentIdx = 0;
        for (int i = 0; i < dataController.clothItems_inventory.Length; i++)
        {
            if (dataController.clothItems_inventory[i] > 0)
            {
                Debug.Log("¿Ü¾ÊµÅ?" + content.transform.GetChild(contentIdx).name + "  " + clothData.transform.GetChild(i).name);
                Image contentImg = content.transform.GetChild(contentIdx).GetComponent<Image>();
                Sprite childSprite = clothData.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite;
                contentImg.sprite = childSprite;
                contentIdx++;
            }
        }
    }

    void updateContent_hat()
    {
        int contentIdx = 0;
        for (int i = 0; i < dataController.hatItems_inventory.Length; i++)
        {
            if (dataController.hatItems_inventory[i] > 0)
            {
                Image contentImg = content.transform.GetChild(contentIdx).GetComponent<Image>();
                Sprite childSprite = hatData.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite;
                contentImg.sprite = childSprite;
                contentIdx++;
            }
        }
    }

    void updateContent_food()
    {
        int contentIdx = 0;
        for (int i = 0; i < dataController.foodItems_inventory.Length; i++)
        {
            if (dataController.foodItems_inventory[i] > 0)
            {
                Image contentImg = content.transform.GetChild(contentIdx).GetComponent<Image>();
                Sprite childSprite = foodData.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite;
                contentImg.sprite = childSprite;
                contentIdx++;
            }
        }
    }
}
