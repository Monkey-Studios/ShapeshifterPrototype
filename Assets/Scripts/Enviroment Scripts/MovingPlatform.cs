using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //Used to create an array for all its assigned target positions
    public Vector3[] points;
    //Used to know which target point it is at
    public int point_number = 0;
    //Assigns the platforms current destination target
    private Vector3 current_target;
    //Used to help snap to its final destination
    public float tolerance;
    //Speed of the platform
    public float speed;
    //Delay before moving again
    public float delay_time;
    public float delay_start;
    //Switch used to tell the platform if it will move automatically or by a trigger
    public bool automatic;
    //Sets the inital journey for the platform
    void Start()
    {
        if (points.Length > 0)
        {
            current_target = points[0];
        }
        tolerance = speed * Time.deltaTime;
    }
    // Updates and changes platforms course when needed to do so
    void FixedUpdate()
    {
        if (transform.position != current_target)
        {
            MovePlatform();
        }
        else
        {
            UpdateTarget();
        }

        void MovePlatform()
        {
            Vector3 heading = current_target - transform.position;
            transform.position += (heading / heading.magnitude) * speed * Time.deltaTime;
            if (heading.magnitude < tolerance)
            {
                transform.position = current_target;
                delay_time = Time.time;
            }
        }

        void UpdateTarget()
        {
            if (automatic)
            {
                if (Time.time - delay_start > delay_time)
                {
                    NextPlatform();
                }
            }
        }

        void NextPlatform()
        {
            point_number++;
            if (point_number >= points.Length)
            {
                point_number = 0;
            }
            current_target = points[point_number];
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = transform;
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}