using Opdrachten;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLookAt : Tower
{
    private Enemy _target;

    protected override bool CanAttack()
    {
        _target = _rangeChecker.GetFirstEnemyInRange();
        return _target != null;
    }

    protected override void Attack()
    {
        if (CanAttack())
        {
            StartCoroutine(LookAtTarget());
        }
    }
    IEnumerator LookAtTarget()
    {
        Vector3 _targetPosition = new Vector3(_target.transform.position.x, transform.position.y, _target.transform.position.z);
        yield return _targetPosition;
        transform.LookAt(_targetPosition);
    }
}
