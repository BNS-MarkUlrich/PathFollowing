using Opdrachten;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _startEnemyHealth = 2;
    private float _currentEnemyHealth;

    private void Start()
    {
        _currentEnemyHealth = _startEnemyHealth;
    }

    public void EnemyTakeDamage(float Edmg)
    {
        _currentEnemyHealth -= Edmg;
        Debug.Log(_currentEnemyHealth);
        print("Target hit");

        if (_currentEnemyHealth <= 0)
        {
            gameObject.SetActive(false);
            print("Hostile down!");
            //return null;
        }
    }
}
