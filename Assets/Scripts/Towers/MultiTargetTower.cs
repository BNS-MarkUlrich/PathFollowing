using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Opdrachten
{
    public class MultiTargetTower : Tower // Rename to "Trooper Squad"
    {
        private Enemy[] _enemies;

        protected override bool CanAttack()
        {
            _enemies = _rangeChecker.GetAllEnemiesInRange();
            if (_enemies == null) return false;
            return _enemies.Length >= 1;
        }

        protected override void Attack()
        {
            foreach (var enemy in _enemies)
            {
                print("Multitarget tower val deze vijand aan: " + enemy.name);
            }
        }
    }
}