using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour // Player health
{
    [SerializeField] public float _startHealth = 3;

    public float _currentHealth;
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
        //print("An enemy has reached the base!");

        if (_currentHealth <= 0)
        {
            StartCoroutine(PlayerDeadFeedback());
            //print("The base has been destroyed.");
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

        dmat.color -= new Color(0.2f, 0.2f, 0.2f, 3.8f);
        yield return null;
    }
}