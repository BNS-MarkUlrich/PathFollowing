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

        private PathFollower _pathFollower;

        private void Awake()
        {
            _pathFollower = GetComponent<PathFollower>();
        }

        void Start()
        {
            SetupEnemy();
        }

        private void SetupEnemy()
        {
            Health playerHealth = GameObject.FindWithTag("PlayerBase").GetComponent<Health>();
            _pathFollower.onPathComplete.AddListener(() => playerHealth.TakeDamage(_damageAmount));
        }
    }

}