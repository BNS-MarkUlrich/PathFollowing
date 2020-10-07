using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

namespace Opdrachten
{
    public class Tower : MonoBehaviour
    {
        protected EnemyInRangeChecker _rangeChecker;
        protected EnemyHealth _enemyHealth;
        protected EnemyHealth[] _enemiesHealth;
        protected bool _isShooting = false;
        //protected UnityEvent onAttacked;
        [SerializeField] protected float _damageAmount;


        private float duration = 4.0f;
        private float timer = 0.0f;

        //private void Start()
        //{

        //}

        private void Awake()
        {
            _rangeChecker = GetComponent<EnemyInRangeChecker>();
            _enemiesHealth = GameObject.FindObjectsOfType<EnemyHealth>();
            Array.Reverse(_enemiesHealth, 0, _enemiesHealth.Length);
            for (int i = 0; i < _enemiesHealth.Length; i++)
            {
                _enemyHealth = GameObject.FindWithTag("Enemy").GetComponent<EnemyHealth>();
                Debug.Log(_enemyHealth);
            }
        }

        void Update()
        {
            timer += Time.deltaTime;
            if(timer > duration)
            {
                Attack();
                timer = 0;
            }
            

            // als we niet kunnen aanvallen. Ga dan uit de update functie
            if (!CanAttack()) return;

            Attack();
        }

        protected virtual bool CanAttack()
        {
            return false;
        }

        protected virtual void Attack()
        {

        }
    }
}