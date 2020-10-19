using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Opdrachten
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _damageAmount;
        [SerializeField] private float _startEnemyHealth = 2;
        private float _currentEnemyHealth;

        private PathFollower _pathFollower;

        private void Awake()
        {
            _pathFollower = GetComponent<PathFollower>();
        }

        void Start()
        {
            _currentEnemyHealth = _startEnemyHealth;
            SetupEnemy();
        }

        private void SetupEnemy()
        {
            Health playerHealth = GameObject.FindWithTag("PlayerBase").GetComponent<Health>();
            _pathFollower.onPathComplete.AddListener(() => playerHealth.TakeDamage(_damageAmount));
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
}