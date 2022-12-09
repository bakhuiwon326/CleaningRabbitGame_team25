using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    public GameManger_Map1 gameManager;

    public FixedJoystick joyStick;
    public float speed;
    public Animator playerAnimator;

    /*공격관련*/
    public int hp = 100;
    public GameObject attackEffect_success;
    public GameObject attackEffect_fail;
    public bool inMonster = false;
    private int moveState = 0; // idle: 0 / 상1 하2 좌3 우4

    void OffState5()
    {
        playerAnimator.SetInteger("moveState", 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = joyStick.Horizontal;
        float inputY = joyStick.Vertical;

        //attackArea.transform.position = gameObject.transform.position + new Vector3(attackArea.offset.x, attackArea.offset.y, 0); ;

        // 캐릭터 이동 관련
        Vector2 inputVector = Mathf.Abs(inputX) > Mathf.Abs(inputY) ? new Vector2(inputX, 0) : new Vector2(0, inputY);
        if (inputVector.x > 0)
        {
            playerAnimator.SetInteger("moveState", 4);
        }
        else if (inputVector.x < 0)
        {
            playerAnimator.SetInteger("moveState", 3);
        }
        else if(inputVector.y > 0)
        {
            playerAnimator.SetInteger("moveState", 1);
        }
        else if(inputVector.y < 0)
        {
            playerAnimator.SetInteger("moveState", 2);
        }
        else if(inputVector == new Vector2(0, 0))
        {
            playerAnimator.SetInteger("moveState", 0);
        }

        transform.Translate(inputVector * Time.deltaTime * speed * 10);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("몬스터랑 충돌!");
        gameManager.attacked = true;
    }
}
