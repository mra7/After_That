using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScenceFade : MonoBehaviour
{
    public Image blackImage;
    public Text scenceName;
    private float alpha;

    private void Awake()
    {
        EventCenter.AddListener(EventType.UI_Scence_Fade_In, ScenceFadeIn);
        EventCenter.AddListener(EventType.UI_Scence_Fade_Out, ScenceFadeOut);
    }
    // 每个场景都有fadein合fadeout 在场景start时直接调用fadein
    private void Start()
    {
        ScenceFadeIn();
    }
    IEnumerator FadeIn()
    {
        alpha = 1;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime;
            blackImage.color = new Color(0, 0, 0, alpha);
            if (scenceName != null) scenceName.color = new Color(255, 255, 255, alpha);
            yield return new WaitForSeconds(0);
        }
    }
    IEnumerator FadeOut()
    {
        alpha = 0;
        while (alpha < 1)
        {
            alpha += Time.deltaTime;
            blackImage.color = new Color(0, 0, 0, alpha);
            yield return new WaitForSeconds(0);
        }
    }
    private void ScenceFadeIn()
    {
        StartCoroutine(FadeIn());
    }
    private void ScenceFadeOut()
    {
        StartCoroutine(FadeOut());
    }
}