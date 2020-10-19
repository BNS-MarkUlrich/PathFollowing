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
                // MARK: Add transform.LookAt() function
                // Smth like:
                // if target != null
                //  - transform.LookAt() function
                // else
                // - reset rotation

                if (_isShooting != true)
                {
                    StartCoroutine(ShootTimer());
                    //_target = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
                    _target.EnemyTakeDamage(_damageAmount);
                    Debug.Log(_target);
                }
            }
            //Debug.Log("SingleTargetTower: Ik heb 1 target en val deze aan!");
        }

        IEnumerator ShootTimer()
        {
            _isShooting = true;
            //Debug.Log(CanAttack() + "ShootTmer");
            while (_isShooting == true)
            {
                yield return new WaitForSeconds(1f);
                _isShooting = false;
            }
            Attack();
        }
    }
}
