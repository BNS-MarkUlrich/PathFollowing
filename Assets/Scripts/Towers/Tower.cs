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
        //protected UnityEvent onAttacked;
        [SerializeField] protected float _damageAmount;

        private void Awake()
        {
            _rangeChecker = GetComponent<EnemyInRangeChecker>();
            _enemyHealth = GameObject.FindWithTag("Enemy").GetComponent<EnemyHealth>();
        }

        void Update() //FixedUpdate
        {
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