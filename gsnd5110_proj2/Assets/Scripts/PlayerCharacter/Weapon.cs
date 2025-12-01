using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Weapon : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] Vector3 center;
    [SerializeField] float range;
    [SerializeField] Vector3 hitboxSize;

    [SerializeField] SpriteRenderer tempVfx;
    [SerializeField] Image attackButton;
    
    [SerializeField] float interval = 0.3f;
    private bool _onCooldown = false;

    // TEMPORARY
    [SerializeField] Animator playerAnimator;
    [SerializeField] AudioSource audioSource;

    public void Start()
    {
        center = transform.position;
        range = 2f;
        hitboxSize = new Vector3(range, range, range);
        audioSource = GetComponent<AudioSource>();
    }

    public void HitTarget()
    {
        if (!_onCooldown)
        {
            playerAnimator.Play("Attack");
            audioSource.Play();
            StartCoroutine(DisplayHit());
            Collider[] hitColliders = Physics.OverlapBox(transform.position, hitboxSize);
            foreach (var hitCollider in hitColliders)
            {
                GameObject currTarget = hitCollider.gameObject;
                if (hitCollider.gameObject.tag == "Enemy" && currTarget != null)
                {
                    EnemyController ec = currTarget.transform.GetComponent<EnemyController>();
                    if (ec != null) ec.ReceiveDamage(damage);
                }
                else if (hitCollider.gameObject.tag == "NPC" && currTarget != null)
                {
                    BubbleOnProximity bop = currTarget.transform.GetComponent<BubbleOnProximity>();
                    if (bop != null) bop.ReactToHit();
                }
            }
            StartCoroutine(ButtonCooldown());
        }
    }

    
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);

        Gizmos.DrawWireCube(transform.position, new Vector3(range, range, range));
    }

    private IEnumerator DisplayHit()
    {
        float displayLength = 0.2f;
        tempVfx.color = Color.red;
        yield return new WaitForSeconds(displayLength);
        tempVfx.color = Color.clear;
    }

    private IEnumerator ButtonCooldown()
    {
        _onCooldown = true;
        float time = 0;
        Color cooldownStart = new Color(attackButton.color.r, attackButton.color.b, attackButton.color.b, 0.5f);

        while (time < interval)
        {
            attackButton.color = Color.Lerp(cooldownStart, Color.white, time);
            time += Time.deltaTime;
            yield return null;
        }
        attackButton.color = Color.white;
        _onCooldown = false;
    }
}
