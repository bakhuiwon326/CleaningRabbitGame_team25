using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneChangeController : MonoBehaviour
{
    public void MoveToHomeScene()
    {
        Debug.Log("홈으로 이동합니다");
        SceneManager.LoadScene("HomeScene");
    }
    public void MoveToShopScene()
    {
        Debug.Log("샵으로 이동합니다");
        SceneManager.LoadScene("ShopScene");
    }
    public void MoveToBagScene()
    {
        Debug.Log("가방으로 이동합니다");
        SceneManager.LoadScene("BagScene");
    }
    public void MoveToGameMap()
    {
        string clickedObject = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log("게임맵으로 이동합니다");
        if(clickedObject != "empty")
        {
            SceneManager.LoadScene(clickedObject);
        }
    }
}
