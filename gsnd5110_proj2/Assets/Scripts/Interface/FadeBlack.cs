using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeBlack : MonoBehaviour
{
    private CanvasGroup _loadingScreen;

    void Awake()
    {
        _loadingScreen = GetComponent<CanvasGroup>();
        _loadingScreen.alpha = 1f;
        StartCoroutine(FadeOpacity(0f, 1f));
    }

    IEnumerator FadeOpacity(float endOpacity, float duration)
    {
        yield return new WaitForSeconds(0.5f);
        float time = 0;
        float startValue = _loadingScreen.alpha;

        while (time < duration)
        {
            _loadingScreen.alpha = Mathf.Lerp(startValue, endOpacity, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        _loadingScreen.alpha = endOpacity;
    }

    public void RunFadeCoroutine(float endOpacity, float duration)
    {
        StartCoroutine(FadeOpacity(endOpacity, duration));
    }
}
