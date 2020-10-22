using Opdrachten;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthDisplay : MonoBehaviour
{
    private Enemy _enemyHealth;
    private float _targetHealth;
    private float _targetStartHealth;
    private float _barHealth;
    public Text _healthString;
    public Slider _healthSlider;

    private void Awake()
    {
        _enemyHealth = GetComponentInParent<Enemy>();
        _targetStartHealth = _enemyHealth._startEnemyHealth;
    }

    void Update()
    {
        _targetHealth = _enemyHealth._currentEnemyHealth;
        _healthString.text = " " + _targetHealth;

        //bar calculations
        _barHealth = _targetHealth / _targetStartHealth * 100;
        _healthSlider.value = _barHealth;
    }
}
