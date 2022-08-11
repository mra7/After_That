using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : EnemyBase
{
    [SerializeField]
    public float moveSpeed;
    private Transform target;
    private NavMeshAgent agent;
    //public bool isAttacked;
    [Header("Hurt")]
    public float hurtLength;
    private float hurtCounter;
    private void Awake()
    {
        EventCenter.AddListener<int, float, Vector2>(EventType.Enemy_GetHit, GetHit);
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener<int, float, Vector2>(EventType.Enemy_GetHit, GetHit);
    }
    void Start()
    {
        currentHp = maxHP;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        agent.speed = moveSpeed;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    void Update()
    {
        FollowPlayer();
        if (hurtCounter <= 0) sp.material.SetFloat("_FlashAmount", 0);
        else hurtCounter -= Time.deltaTime;
        agent.SetDestination(target.position);
    }
    private void FollowPlayer()
    {
        //transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
    private void AttackPlayer()
    {
    }
    private void GetHit(int id, float attackValue, Vector2 difference)
    {
        if (id == EnemyId)
        {
            currentHp -= attackValue;
            if (currentHp > 0)
            {
                HurtShader();
                rb.AddForce(new Vector2(-difference.x * 300, -difference.y * 300));
            }
            else if (currentHp <= 0)
            {
                Destroy(gameObject);
                EventCenter.Boardcast(EventType.PoolSystem_GetGameObject, deadVFX, transform.position, 0f);
            }
        }
    }
    private void HurtShader()
    {
        // shader±äÉ«³¢ÊÔ
        sp.material.SetFloat("_FlashAmount", 1);
        hurtCounter = hurtLength;
    }
    private void Test(int id)
    {
        
    }

}
