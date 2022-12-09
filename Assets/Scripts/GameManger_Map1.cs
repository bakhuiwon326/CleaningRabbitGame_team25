using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManger_Map1 : MonoBehaviour
{
    public GameObject monster;

    /*카메라*/
    public Camera cam;
    public Vector2 minCamBoundary;
    public Vector2 maxCamBoundary;

    /*플레이어*/
    public GameObject player;
    private PlayerController playerController;

    /*hp*/
    public RectTransform hp;
    public Vector2 tmpVec;
    public bool attacked = false;
 
    /*게임오버*/
    public GameObject gameOver;
    public Button restartBtn;
    
    /*공격 관련*/
    public Button attackBtn; // 공격버튼
    public Button changeBtn; // 공격버튼
    private Image changeBtnImage; // 다음 공격 무기
    private Image attackBtnImg; // 화면에 표시되는 무기 이미지
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
        if(weaponState == -1) // dustStick을 무기로 설정
        {
            attackBtnImg.sprite = dustStick;
            changeBtnImage.sprite = dustCloth;
        }
        else if(weaponState == 1) // dustCloth을 무기로 설정
        {
            attackBtnImg.sprite = dustCloth;
            changeBtnImage.sprite = dustStick;
        }
    }

    void Attack()
    {
        // 영역 안에 몬스터 있음 - 공격 성공
        if (playerController.inMonster)
        {
            Debug.Log("공격 성공!");
            playerController.attackEffect_success.SetActive(true);
            Invoke("HideAttackEffectSuccess", 1);
        }
        else
        // 영역 안에 몬스터 없음 - 공격 실패
        {
            Debug.Log("공격 실패!");
            playerController.attackEffect_fail.SetActive(true);
            Invoke("HideAttackEffectFail", 1);
        }
    }

    void HideAttackEffectSuccess()
    {
        playerController.attackEffect_success.SetActive(false);
        monster.SetActive(false); // 임시
    }

    void HideAttackEffectFail()
    {
        playerController.attackEffect_fail.SetActive(false);
        monster.SetActive(false); // 임시
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
        // 카메라 이동 관련
        Vector3 camTargetPos = new Vector3(player.transform.position.x, player.transform.position.y, cam.transform.position.z);
        camTargetPos.x = Mathf.Clamp(camTargetPos.x, minCamBoundary.x, maxCamBoundary.x);
        camTargetPos.y = Mathf.Clamp(camTargetPos.y, minCamBoundary.y, maxCamBoundary.y);
        cam.transform.position = Vector3.Lerp(cam.transform.position, camTargetPos, 0.2f);

        // hp 조절
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
