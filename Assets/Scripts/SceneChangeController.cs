using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneChangeController : MonoBehaviour
{
    public void MoveToHomeScene()
    {
        Debug.Log("Ȩ���� �̵��մϴ�");
        SceneManager.LoadScene("HomeScene");
    }
    public void MoveToShopScene()
    {
        Debug.Log("������ �̵��մϴ�");
        SceneManager.LoadScene("ShopScene");
    }
    public void MoveToBagScene()
    {
        Debug.Log("�������� �̵��մϴ�");
        SceneManager.LoadScene("BagScene");
    }
    public void MoveToGameMap()
    {
        string clickedObject = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log("���Ӹ����� �̵��մϴ�");
        if(clickedObject != "empty")
        {
            SceneManager.LoadScene(clickedObject);
        }
    }
}
