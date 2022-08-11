using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitScence : MonoBehaviour
{
    [SerializeField]
    public string NextScenceName;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Vector3 pos = new Vector3(-10.5f, -1.5f, 0);
            //EventCenter.Boardcast(EventType.UI_Scence_Fade_Out);
            EventCenter.Boardcast(EventType.Character_Change_Position, pos);
            SceneManager.LoadScene(NextScenceName);
        }
    }
}
