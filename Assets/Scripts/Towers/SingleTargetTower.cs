using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Opdrachten
{
    public class SingleTargetTower : Tower
    {
        private Enemy _target;

        protected override bool CanAttack()
        {
            _target = _rangeChecker.GetFirstEnemyInRange();
            return _target != null;
        }
        
        protected override void Attack()
        {
            if (CanAttack()) // Check if we can attack
            {
                StartCoroutine(LookAtTarget()); // Look at enemy

                if (_isShooting != true)
                {
                    StartCoroutine(ShootTimer()); // attack in intervals
                    _target.EnemyTakeDamage(_damageAmount); // damage enemy
                }
            }
        }

        IEnumerator ShootTimer()
        {
            _isShooting = true;
            while (_isShooting == true)
            {
                yield return new WaitForSeconds(1f);
                _isShooting = false;
            }
            Attack();
        }
        IEnumerator LookAtTarget()
        {
            Vector3 _targetPosition = new Vector3(_target.transform.position.x, _target.transform.position.y, _target.transform.position.z);
            yield return _targetPosition;
            transform.LookAt(_targetPosition);
        }
    }
}
