using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    private Transform target;
    [SerializeField]
    private float moveSpeed = 2.0f;
    [SerializeField]
    private float minX, maxX, minY, maxY;

    //public Vector2 max;
    protected override void Awake()
    {
        base.Awake();
        EventCenter.AddListener<int>(EventType.Camera_Time_Pause, HitPause);
    }
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //target = PlayerController.Instance.transform;
    }
    void Update()
    {
        //transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
    private void LateUpdate()
    {
        transform.position =  Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), moveSpeed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
                                         Mathf.Clamp(transform.position.y, minY, maxY),
                                         transform.position.z);
    }
    //  ¹¥»÷¶ÙÖ¡
    private void HitPause(int duration)
    {
        StartCoroutine(Pause(duration));
    }
    IEnumerator Pause(int duration)
    {
        float pauseTime = duration / 60f;
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(pauseTime);
        Time.timeScale = 1;
    }
}
