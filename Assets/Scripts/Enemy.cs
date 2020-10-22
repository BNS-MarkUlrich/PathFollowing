using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

namespace Opdrachten
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _damageAmount;
        [SerializeField] public float _startEnemyHealth = 2;
        public float _currentEnemyHealth;
        private new MeshRenderer renderer;
        private Health playerHealth;

        private PathFollower _pathFollower;

        private void Awake()
        {
            _pathFollower = GetComponent<PathFollower>();
            renderer = GetComponent<MeshRenderer>();
        }

        void Start()
        {
            SetupEnemy();
        }

        private void LateUpdate()
        {
            if (playerHealth._currentHealth <= 0)
            {
                //gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }

        public void SetupEnemy()
        {
            _currentEnemyHealth = _startEnemyHealth;
            playerHealth = GameObject.FindWithTag("PlayerBase").GetComponent<Health>();
            _pathFollower.onPathComplete.AddListener(() => playerHealth.TakeDamage(_damageAmount));
        }
        public void EnemyTakeDamage(float Edmg)
        {
            _currentEnemyHealth -= Edmg;
            StartCoroutine(TakeDamageFeedback());

            if (_currentEnemyHealth <= 0)
            {
                //gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
        IEnumerator TakeDamageFeedback()
        {
            Material mat = renderer.material;

            mat.color += new Color(24.9f, 24.9f, 24.9f);
            yield return new WaitForSeconds(0.2f);
            mat.color -= new Color(24.9f, 24.9f, 24.9f);
            yield return null;
        }
    }
}