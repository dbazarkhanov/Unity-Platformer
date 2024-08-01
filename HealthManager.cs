using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float totalhealth;
    public float currentHealth;
    public float damageCooldown = 1f;
    private float lastDamageTime;
    public AudioClip hurtSound;
    public AudioClip deathSound;

    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = totalhealth;
        lastDamageTime = -damageCooldown;
    }

    public void TakeDamage(float _damage)
    {
        if (Time.time - lastDamageTime >= damageCooldown)
        {
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, totalhealth);

            if (currentHealth > 0)
            {
                SoundManager.instance.PlaySound(hurtSound);
                animator.SetTrigger("Hurt");
            }
            else
            {
                SoundManager.instance.PlaySound(deathSound);
                animator.SetTrigger("Death");
                GetComponent<PlayerController>().enabled = false;
            }

            lastDamageTime = Time.time;
        }

    }
}
