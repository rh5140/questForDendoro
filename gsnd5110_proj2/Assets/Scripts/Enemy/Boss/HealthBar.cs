using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] BossController boss;
    Slider slider;

    void OnEnable()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = boss.GetMaxHealth();
        slider.value = boss.GetMaxHealth();
    }

    public void SetHealth(int hp)
    {
        slider.value = hp;
        if (hp == 0) StartCoroutine(DestroyHealthBar());
    }

    IEnumerator DestroyHealthBar()
    {
        yield return new WaitForSeconds(2f);
        Destroy(transform.parent.gameObject);
    }
}
