using UnityEngine;
using TMPro;
using System.Collections;

public class TextCycler : MonoBehaviour
{
    public TMP_Text targetText;            // Assign your subtitle text here
    public float changeInterval = 2f;      // Time between text changes

    [TextArea]
    public string[] messages;              // Add the list of messages in Inspector

    private int currentIndex = 0;

    void Start()
    {
        if (targetText == null || messages.Length == 0)
        {
            Debug.LogError("TextCycler is missing references!");
            return;
        }

        targetText.text = messages[0];
        StartCoroutine(CycleTextRoutine());
    }

    IEnumerator CycleTextRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeInterval);

            // Move to next text
            currentIndex = (currentIndex + 1) % messages.Length;

            // Fade-out → switch → fade-in
            yield return StartCoroutine(FadeText(0f, 0.4f));
            targetText.text = messages[currentIndex];
            yield return StartCoroutine(FadeText(1f, 0.4f));
        }
    }

    IEnumerator FadeText(float targetAlpha, float duration)
    {
        Color c = targetText.color;
        float startAlpha = c.a;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
            targetText.color = new Color(c.r, c.g, c.b, newAlpha);
            yield return null;
        }
    }
}
