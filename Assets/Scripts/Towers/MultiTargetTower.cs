using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Opdrachten
{
    public class MultiTargetTower : Tower // Rename to "Trooper Squad"
    {
        public Enemy[] _enemies;
        [SerializeField] protected float _enemySpeed;
        private bool fireonce = false;

        protected override bool CanAttack()
        {
            _enemies = _rangeChecker.GetAllEnemiesInRange();
            if (_enemies == null)
            {
                return false;
            }
            else
            {
                return _enemies.Length > 0;
            }
        }

        protected override void Attack()
        {

            if (CanAttack()) // Check if we can attack
            {
                foreach (Enemy enemy in _enemies)
                {
                    if (enemy)
                    {
                        if (fireonce != true)
                        {
                            StartCoroutine(SlowEnemy(enemy));
                            enemy.GetComponent<PathFollower>()._speed /= 2;
                        }
                    }
                }
            }
        }

        IEnumerator SlowEnemy(Enemy anEnemy)
        {
            fireonce = true;
            while (fireonce == true)
            {
                yield return new WaitForSeconds(0.5f);
                anEnemy.GetComponent<PathFollower>()._speed *= 2;
                fireonce = false;
                
            }
            Attack();

            //print("Multitarget tower val deze vijand aan: " + enemy.name);
        }
    }
}