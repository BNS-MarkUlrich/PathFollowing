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
                StartCoroutine(LookAtTarget());

                if (_isShooting != true)
                {
                    StartCoroutine(ShootTimer());
                    _target.EnemyTakeDamage(_damageAmount);
                    //Debug.Log(_target);
                }
            }
        }

        IEnumerator ShootTimer()
        {
            _isShooting = true;
            //Debug.Log(CanAttack() + "ShootTmer");
            //_targetPosition = _target.transform;
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
