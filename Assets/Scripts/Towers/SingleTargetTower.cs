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
                StartCoroutine(ShootTimer());
            }
            //Debug.Log("SingleTargetTower: Ik heb 1 target en val deze aan!");
        }

        IEnumerator ShootTimer()
        {
            _enemyHealth.EnemyTakeDamage(_damageAmount);
            yield return new WaitForSeconds(1f);
            Attack();
        }
    }
}
