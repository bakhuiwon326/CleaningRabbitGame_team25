using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataController : MonoBehaviour
{
    private static DataController instance = null;

    // 인벤토리에 저장된 아이템들 개수. 
    public int[] clothItems_inventory = new int[12];
    public int[] hatItems_inventory = new int[12];
    public int[] foodItems_inventory = new int[3];

    // shop에서 선택된 아이템들 index
    public int clothItem_shopSelected = -1; // index
    public int hatItem_shopSelected = -1; // index
    public int[] foodItems_shopSelected = new int[3];

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if(instance != this) Destroy(this.gameObject);
        }
    }

    public static DataController Instance
    {
        get {
            if (!instance)
            {
                return null;
            }
            return instance;
        }
    }
    
    public void saveInventory()
    {
        if(clothItem_shopSelected >= 0)
        {
            clothItems_inventory[clothItem_shopSelected]++;
        }
        if(hatItem_shopSelected >= 0)
        {
            hatItems_inventory[hatItem_shopSelected]++;
        }

    }

}
