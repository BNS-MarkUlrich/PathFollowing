using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Transform = UnityEngine.Transform;

namespace Opdrachten
{
    /// <summary>
    /// De path follower class is verantwoordelijk voor de beweging.
    /// Deze class zorgt ervoor dat het object (in Tower Defense) vaak een enemy, het path afloopt
    /// tip: je kunt de transform.LookAt() functie gebruiken en vooruitbewegen.
    /// </summary>
    public class PathFollower : MonoBehaviour
    {
        public Transform target;
        public float speed = 1.0f;
        //public Waypoint position;

        void Update()
        {
            transform.LookAt(target);
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
}