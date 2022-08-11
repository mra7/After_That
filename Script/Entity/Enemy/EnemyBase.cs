using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] public int EnemyId;
    [SerializeField] public string EnemyType;
    [SerializeField] protected float maxHP;
    [SerializeField] protected GameObject deadVFX;
    [SerializeField] protected float currentHp;
    [SerializeField] protected SpriteRenderer sp;
    [SerializeField] public Rigidbody2D rb;
}
