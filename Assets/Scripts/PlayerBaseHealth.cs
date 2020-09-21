using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _startHealth = 3;

    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _startHealth;
    }

    public void TakeDamage(float dmg)
    {
        _currentHealth -= dmg;
        print("An enemy has reached the base!");

        if (_currentHealth <= 0)
        {
            print("The base has been destroyed.");
        }
    }
}
