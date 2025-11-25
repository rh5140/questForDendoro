using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeBlack : MonoBehaviour
{
    private Image _blackScreen;
    private float _fadeAmount = 0.5f;

    void Awake()
    {
        _blackScreen = GetComponent<Image>();
        _blackScreen.color = Color.black;
        StartCoroutine(FadeOpacity(0f, 1f));
    }

    IEnumerator FadeOpacity(float endOpacity, float duration)
    {
        yield return new WaitForSeconds(0.5f);
        float time = 0;
        Color startValue = _blackScreen.color;
        Color endValue = new Color(startValue.r, startValue.b, startValue.g, endOpacity);

        while (time < duration)
        {
            _blackScreen.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        _blackScreen.color = endValue;
    }
}
