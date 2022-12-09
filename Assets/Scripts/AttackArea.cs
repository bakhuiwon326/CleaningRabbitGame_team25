using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public PlayerController player;
    private CircleCollider2D colliderCompo;

    // Start is called before the first frame update
    void Start()
    {
        colliderCompo = gameObject.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(colliderCompo.offset.x, colliderCompo.offset.y, 0);
    }


    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("범위 내에 몬스터 있어요");
        if (other.gameObject.CompareTag("Monster"))
        {
            player.inMonster = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("범위 내에 몬스터 없어요");
        if (other.gameObject.CompareTag("Monster"))
        {
            player.inMonster = false;
        }
    }

}
