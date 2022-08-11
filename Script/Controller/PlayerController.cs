using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    private Rigidbody2D rb;
    // 动画
    Animator animator;
    // 角色状态
    public PlayerState currentState;
    // 角色移动
    Vector3 positionChange;
    [SerializeField]
    private float moveSpeed = 5.0f;
    protected override void Awake()
    {
        base.Awake();
        EventCenter.AddListener<Vector3>(EventType.Character_Change_Position, ChangePosition);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        transform.position = new Vector3(-10.5f, -1.5f, 0);
    }
    void Update()
    {
        positionChange = Vector3.zero;
        positionChange.x = Input.GetAxisRaw("Horizontal");
        positionChange.y = Input.GetAxisRaw("Vertical");
        PlayerAttack();
    }
    private void FixedUpdate()
    {
        if (currentState != PlayerState.attacking)
        {
            PlayerMove();
        }
    }
    // 处理攻击
    private void PlayerAttack()
    {
        if (Input.GetKeyDown(KeyCode.J) && currentState != PlayerState.attacking)
        {
            animator.SetBool("isMoving", false);
            currentState = PlayerState.attacking;
            animator.SetTrigger("Attack");
            StartCoroutine(AttackCo());
        }
    }
    private IEnumerator AttackCo()
    {
        transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        animator.SetBool("isAttacking", true);
        currentState = PlayerState.attacking;
        yield return null;
    }
    private void AttackEnd()
    {
        if (positionChange == Vector3.zero) currentState = PlayerState.idleing;
        if (positionChange != Vector3.zero) currentState = PlayerState.moving;
        animator.SetBool("isAttacking", false);
    }
    // 处理角色移动
    private void PlayerMove()
    {
        // 处理移动
        if (positionChange != Vector3.zero /*&& currentState == PlayerState.moving*/)
        {
            currentState = PlayerState.moving;
            rb.MovePosition(transform.position + positionChange.normalized * Time.deltaTime * moveSpeed);
            animator.SetFloat("moveX", positionChange.x);
            animator.SetFloat("moveY", positionChange.y);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
    private void ChangePosition(Vector3 pos)
    {
        transform.position = pos;
    }
    // 角色面向方向 TODO
    private void PlayerForward()
    {
        if (positionChange.x == 0 && positionChange.y == 0) return;
    }
    private void Test()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            //EventCenter.Boardcast(EventType.Enemy_GetHit, 1);
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                           