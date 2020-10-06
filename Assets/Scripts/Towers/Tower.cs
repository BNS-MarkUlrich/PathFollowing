using System;
using System.Collections;
using System.Collections.Generic;
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

        private void Awake()
        {
            _rangeChecker = GetComponent<EnemyInRangeChecker>();
            _enemyHealth = GameObject.FindWithTag("Enemy").GetComponent<EnemyHealth>();
            //_enemiesHealth = GameObject.FindObjectsOfType<EnemyHealth>();
            //Debug.Log(_enemiesHealth);
        }

        void Update() //FixedUpdate
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