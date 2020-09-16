using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
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
        

        [SerializeField] private float _speed = 3.0f;
        [SerializeField] private float _arrivalthreshold = 0.1f;

        Waypoint position;




        private void Update()
        {

            Vector3 heightOffsetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            float distance = Vector3.Distance(transform.position, heightOffsetPosition);

            if (distance <= _arrivalthreshold)
            {
                transform.LookAt(heightOffsetPosition);
                transform.Translate(Vector3.forward * _speed * Time.deltaTime);
            }
        }
    }
}



    /// <summary>
    /// Below class is old version
    /// </summary>

//    public class PathFollower : MonoBehaviour
//    {
//        public Transform target;
//        public float speed = 1.0f;

//        void Update()
//        {
//            transform.LookAt(target);
//            float step = speed * Time.deltaTime;
//            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
//        }
//    }
//}