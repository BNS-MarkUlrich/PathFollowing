using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Opdrachten
{
    public class EnemyInRangeChecker : MonoBehaviour
    {
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _layer;

        public Enemy GetFirstEnemyInRange()
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, _radius, _layer);
            if (cols.Length < 1)
                return null;

            else if (cols.Length >= 2)
            {
                return cols[+1].GetComponent<Enemy>();
            }
            else
            {
                return cols[0].GetComponent<Enemy>();
            }
            
        }

        public Enemy[] GetAllEnemiesInRange()
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, _radius, _layer);
            if (cols.Length < 1)
                return null;

            List<Enemy> enemiesInRange = new List<Enemy>();
            foreach (var col in cols)
            {
                enemiesInRange.Add(col.GetComponent<Enemy>());
            }

            return enemiesInRange.ToArray();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }
}