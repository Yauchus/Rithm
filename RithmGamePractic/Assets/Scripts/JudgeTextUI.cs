using TMPro;
using UnityEngine;
using System.Collections;

public class JudgeTextUI : MonoBehaviour
{
    public static JudgeTextUI Instance;

    public TMP_Text judgeText;
    public float showTime = 0.5f;

    Coroutine hideRoutine;

    void Awake()
    {
        Instance = this;
    }

    public void Show(string result)
    {
        if (judgeText == null) return;

        judgeText.text = result;

        if (hideRoutine != null)
            StopCoroutine(hideRoutine);

        hideRoutine = StartCoroutine(HideAfterDelay());
    }

    IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(showTime);
        if (judgeText != null)
            judgeText.text = "";
    }
}