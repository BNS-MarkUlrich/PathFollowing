using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
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
        public GameObject[] waypoints;

        /// <summary>
        /// De onderstaande functie is een template gehaald van het internet, 
        /// deze werkt compleet en behaald het doel van de opdracht, 
        /// helaas moet ik voor de opracht met alle 3 de classes werken.
        /// </summary>
        public int current = 0;
        float rotSpeed;
        public float speed = 1.0f;
        float WPradius = 1;
        void Update()
        {
            if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
            {
                current++;
                if (current >= waypoints.Length)
                {
                    current = 0;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);

        }

        /// <summary>
        /// Deze functie returned het volgende waypoint waar naartoe kan worden bewogen.
        /// </summary>
        public Waypoint GetNextWaypoint()
        {
            
            // dit is nu niet goed, zorg ervoor dat het goede waypoint wordt teruggegeven.
            return null;
        }
    }
}