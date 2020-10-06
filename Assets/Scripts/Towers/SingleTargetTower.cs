using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Opdrachten
{
    public class SingleTargetTower : Tower // Rename to "(Heavy) Cannon"
    {
        private Enemy _target;

        protected override bool CanAttack()
        {
            _target = _rangeChecker.GetFirstEnemyInRange();
            return _target != null;
        }
        
        protected override void Attack()
        {
            //onAttacked.Invoke();
            if (CanAttack())
            {
                //Debug.Log(CanAttack() + "While");
                //_isShooting = true;
                if (_isShooting != true)
                {
                    StartCoroutine(ShootTimer());
                    _enemyHealth.EnemyTakeDamage(_damageAmount);
                }
            }
            //for (int i = 0; i < _enemiesHealth.Length-1; i++)
            //{
            //    if (CanAttack())
            //    {
            //        StartCoroutine(ShootTimer());
            //    }
            //}
            //Debug.Log("SingleTargetTower: Ik heb 1 target en val deze aan!");
        }

        IEnumerator ShootTimer()
        {
            _isShooting = true;
            while (_isShooting == true)
            {
                yield return new WaitForSeconds(1f);
                _isShooting = false;
            }
            //_enemyHealth.EnemyTakeDamage(_damageAmount);
            yield return !CanAttack();
            Debug.Log(CanAttack() + "ShootTmer");
            Attack();
        }
    }
}
