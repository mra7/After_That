using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterScence : MonoBehaviour
{
    bool firstTouch = false;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && firstTouch == false)
        {
            Debug.Log("�Ѿ����ܻ�ͷ��...");
            firstTouch = true;
        }
    }

}
