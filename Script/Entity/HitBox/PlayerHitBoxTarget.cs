using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBoxTarget : MonoBehaviour
{
    //// 判定hitbox方向
    //public void ChangeHitBoxTarget() // float x, float y
    //{
    //    float x = Input.GetAxisRaw("Horizontal");
    //    float y = Input.GetAxisRaw("Vertical");
    //    //Debug.Log(x + "----" + y);
    //    // unity动画表现为上下优先于左右
    //    if (x != 0)
    //    {
    //        // 要么上要么下
    //        if (y == 1f) transform.rotation = Quaternion.Euler(0, 0, 0);
    //        if (y == -1f) transform.rotation = Quaternion.Euler(0, 0, 180);
    //    }
    //    else if (y == 0f)
    //    {
    //        // 左右
    //        if (x == 1f) transform.rotation = Quaternion.Euler(0, 0, 270);
    //        if (x == -1f) transform.rotation = Quaternion.Euler(0, 0, 90);
    //    }
    //}
}
