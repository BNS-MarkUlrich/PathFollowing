using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _startHealth = 3;

    private float _currentHealth;
    private new MeshRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        _currentHealth = _startHealth;
    }

    public void TakeDamage(float dmg)
    {
        _currentHealth -= dmg;
        StartCoroutine(TakeDamageFeedback());
        print("An enemy has reached the base!");

        if (_currentHealth <= 0)
        {
            StartCoroutine(PlayerDeadFeedback());
            print("The base has been destroyed.");
        }
    }

    IEnumerator TakeDamageFeedback()
    {
        Material mat = renderer.material;

        mat.color += new Color(0.9f, 0.9f, 0.9f);
        yield return new WaitForSeconds(0.1f);
        mat.color -= new Color(0.9f, 0.9f, 0.9f);
        yield return null;
    }

    IEnumerator PlayerDeadFeedback()
    {
        Material dmat = renderer.material;

        dmat.color -= new Color(0.2f, 0.2f, 0.2f, 0.8f);
        yield return null;
    }
}

//[Tooltip("Maximum amount of health")]
//public float maxHealth = 10f;
//[Tooltip("Health ratio at which the critical health vignette starts appearing")]
//public float criticalHealthRatio = 0.3f;

//public UnityAction<float, GameObject> onDamaged;
//public UnityAction<float> onHealed;
//public UnityAction onDie;

//public float currentHealth { get; set; }
//public bool invincible { get; set; }
//public bool canPickup() => currentHealth < maxHealth;

//public float getRatio() => currentHealth / maxHealth;
//public bool isCritical() => getRatio() <= criticalHealthRatio;

//bool m_IsDead;

//private void Start()
//{
//    currentHealth = maxHealth;
//}

//public void Heal(float healAmount)
//{
//    float healthBefore = currentHealth;
//    currentHealth += healAmount;
//    currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

//    // call OnHeal action
//    float trueHealAmount = currentHealth - healthBefore;
//    if (trueHealAmount > 0f && onHealed != null)
//    {
//        onHealed.Invoke(trueHealAmount);
//    }
//}

//public void TakeDamage(float damage, GameObject damageSource)
//{
//    if (invincible)
//        return;

//    float healthBefore = currentHealth;
//    currentHealth -= damage;
//    currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

//    // call OnDamage action
//    float trueDamageAmount = healthBefore - currentHealth;
//    if (trueDamageAmount > 0f && onDamaged != null)
//    {
//        onDamaged.Invoke(trueDamageAmount, damageSource);
//    }

//    HandleDeath();
//}

//public void Kill()
//{
//    currentHealth = 0f;

//    // call OnDamage action
//    if (onDamaged != null)
//    {
//        onDamaged.Invoke(maxHealth, null);
//    }

//    HandleDeath();
//}

//private void HandleDeath()
//{
//    if (m_IsDead)
//        return;

//    // call OnDie action
//    if (currentHealth <= 0f)
//    {
//        if (onDie != null)
//        {
//            m_IsDead = true;
//            onDie.Invoke();
//        }
//    }
//}