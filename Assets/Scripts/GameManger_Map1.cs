using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManger_Map1 : MonoBehaviour
{
    public GameObject monster;

    /*ī�޶�*/
    public Camera cam;
    public Vector2 minCamBoundary;
    public Vector2 maxCamBoundary;

    /*�÷��̾�*/
    public GameObject player;
    private PlayerController playerController;

    /*hp*/
    public RectTransform hp;
    public Vector2 tmpVec;
    public bool attacked = false;
 
    /*���ӿ���*/
    public GameObject gameOver;
    public Button restartBtn;
    
    /*���� ����*/
    public Button attackBtn; // ���ݹ�ư
    public Button changeBtn; // ���ݹ�ư
    private Image changeBtnImage; // ���� ���� ����
    private Image attackBtnImg; // ȭ�鿡 ǥ�õǴ� ���� �̹���
    private int weaponState = -1;
    public Sprite dustStick; // weaponState = -1
    public Sprite dustCloth; // weaponState = 1
    private Animator attackEffectAnimator;



    void ClickRestarat()
    {
        SceneManager.LoadSceneAsync("Map1");
    }

    void ChangeWeaponBtn()
    {
        weaponState *= -1;
        if(weaponState == -1) // dustStick�� ����� ����
        {
            attackBtnImg.sprite = dustStick;
            changeBtnImage.sprite = dustCloth;
        }
        else if(weaponState == 1) // dustCloth�� ����� ����
        {
            attackBtnImg.sprite = dustCloth;
            changeBtnImage.sprite = dustStick;
        }
    }

    void Attack()
    {
        // ���� �ȿ� ���� ���� - ���� ����
        if (playerController.inMonster)
        {
            Debug.Log("���� ����!");
            playerController.attackEffect_success.SetActive(true);
            Invoke("HideAttackEffectSuccess", 1);
        }
        else
        // ���� �ȿ� ���� ���� - ���� ����
        {
            Debug.Log("���� ����!");
            playerController.attackEffect_fail.SetActive(true);
            Invoke("HideAttackEffectFail", 1);
        }
    }

    void HideAttackEffectSuccess()
    {
        playerController.attackEffect_success.SetActive(false);
        monster.SetActive(false); // �ӽ�
    }

    void HideAttackEffectFail()
    {
        playerController.attackEffect_fail.SetActive(false);
        monster.SetActive(false); // �ӽ�
    }

    // Start is called before the first frame update
    void Start()
    {
        attackBtn.onClick.AddListener(Attack);
        changeBtn.onClick.AddListener(ChangeWeaponBtn);
        restartBtn.onClick.AddListener(ClickRestarat);

        attackBtnImg = attackBtn.transform.GetChild(0).GetComponent<Image>();
        changeBtnImage = changeBtn.transform.GetChild(0).GetComponent<Image>();
        playerController = player.GetComponent<PlayerController>();

        playerController.attackEffect_fail.SetActive(false);
        playerController.attackEffect_success.SetActive(false);

        hp.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 456);
    }


    private void Update()
    {
        // ī�޶� �̵� ����
        Vector3 camTargetPos = new Vector3(player.transform.position.x, player.transform.position.y, cam.transform.position.z);
        camTargetPos.x = Mathf.Clamp(camTargetPos.x, minCamBoundary.x, maxCamBoundary.x);
        camTargetPos.y = Mathf.Clamp(camTargetPos.y, minCamBoundary.y, maxCamBoundary.y);
        cam.transform.position = Vector3.Lerp(cam.transform.position, camTargetPos, 0.2f);

        // hp ����
        if (attacked)
        {
            attacked = false;
            hp.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, hp.sizeDelta.x - 76);
        }

        if (hp.sizeDelta.x == 0)
        {
            gameOver.SetActive(true);
        }
        
    }

}
