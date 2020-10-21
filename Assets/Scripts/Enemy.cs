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
        //private Health _takeDamageFeedback;
        private new MeshRenderer renderer;
        public int counter;

        private PathFollower _pathFollower;
        //private EnemySpawner deadPlayer;
        //private bool playerIsDead;

        private void Awake()
        {
            _pathFollower = GetComponent<PathFollower>();
            //playerIsDead = deadPlayer.stopSpawning;
            //_takeDamageFeedback = Health.TakeDamageFeedback();
            renderer = GetComponent<MeshRenderer>();
        }

        private void KillCounter(int score)
        {
            counter += score;
            Debug.Log(counter);
        }

        void Start()
        {
            SetupEnemy();
        }

        public void SetupEnemy()
        {
            _currentEnemyHealth = _startEnemyHealth;
            Health playerHealth = GameObject.FindWithTag("PlayerBase").GetComponent<Health>();
            _pathFollower.onPathComplete.AddListener(() => playerHealth.TakeDamage(_damageAmount));
            if (playerHealth._currentHealth <= 0)
            {
                //playerIsDead = true;
                gameObject.SetActive(false);
            }
        }
        public void EnemyTakeDamage(float Edmg)
        {
            _currentEnemyHealth -= Edmg;
            //Debug.Log(_currentEnemyHealth);
            StartCoroutine(TakeDamageFeedback());
            //print("Target hit");

            if (_currentEnemyHealth <= 0)
            {
                KillCounter(1);
                gameObject.SetActive(false);

                //print("Hostile down!");
                //return null;
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