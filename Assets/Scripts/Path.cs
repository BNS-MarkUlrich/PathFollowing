using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Opdrachten
{
    /// <summary>
    /// De path class beheerd een array van waypoints. En houd bij bij welk waypoint een object is.
    /// Deze vormen samen het pad. 
    /// Logica die op het path niveau plaatsvindt gebeurt in deze class.
    /// Een deel van de functies welke je nodig hebt zijn hier al beschreven.
    /// </summary>
    public class Path : MonoBehaviour
    {

        [SerializeField] private Waypoint[] _waypoints;

        //public int _currentWaypointIndex;

        /// <summary>
        /// Deze functie returned het volgende waypoint waar naartoe kan worden bewogen
        /// </summary>
        /// <param name="currentWaypoint">Geef me huidige waypoint referentie.</param>
        /// <returns>Geeft null terug wanneer laatste waypoint is bereikt, als currentWaypoint null is geeft hij de eerste in de lijst terug.</returns>
        public Waypoint GetNextWaypoint(Waypoint currentWaypoint)
        {
            if(currentWaypoint == null)
            {
                Debug.Log("Waypoints[0]");
                return _waypoints[0];
            }
            
            for(int i = 0; i < _waypoints.Length; i++)
            {
                if(i == _waypoints.Length - 1)
                {
                    Debug.Log("Waypoints null");
                    return null;
                }
                else if (currentWaypoint == _waypoints[i])
                {
                    Debug.Log("Waypoints i++");
                    return _waypoints[++i];
                }
            }

            // TODO: If valid reference but not in array == append to array

            return null;
            //return _waypoints[].gameObject.GetComponent<Waypoint>();
        }
    }
}