using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitBox : MonoBehaviour
{
    [SerializeField]  private float attackDamage;
    [Header("´ò»÷¸Ð")]
    [SerializeField] private int attackPause;
    [SerializeField] private GameObject attackHitVFX;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" /*&& other.gameObject.GetComponent<Enemy_01_test>().isAttacked == false*/)
        {
            var playerPosition = PlayerController.Instance.transform.position;
            int enemyId = other.gameObject.GetComponent<EnemyBase>().EnemyId;
            Vector2 difference = (playerPosition - other.transform.position).normalized;
            float vfxRotZ =(Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + 180f) % 360f;
            EventCenter.Boardcast(EventType.PoolSystem_GetGameObject, attackHitVFX, other.transform.position, vfxRotZ);
            EventCenter.Boardcast(EventType.Enemy_GetHit, enemyId, attackDamage, difference);
            EventCenter.Boardcast(EventType.Camera_Time_Pause, attackPause);
        }
    }
}
