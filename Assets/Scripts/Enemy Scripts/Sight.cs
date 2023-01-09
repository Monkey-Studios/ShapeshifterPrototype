using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public GameObject player;
    private float distance;

    public float angle = 360f;
    public float radius = 10f;

    public Vector3 FromVector
    {
        get
        {
            float leftAngle = -angle / 2;
            leftAngle += transform.eulerAngles.y;
            return new Vector3(Mathf.Sin(leftAngle * Mathf.Deg2Rad), 0, Mathf.Cos(leftAngle * Mathf.Deg2Rad));
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Visible");
    }


    void Update()
    {
        Vector3 directionVector = (transform.position - player.transform.position).normalized;
        ////The following code only looks at the x and z axis, ignoring the height.
        //distance = Mathf.Sqrt(Mathf.Pow(directionVector.x, 2) + Mathf.Pow(directionVector.z, 2));
        distance = Vector3.Distance(transform.position, player.transform.position);

        float dotProduct = Vector3.Dot(directionVector, transform.forward);

        if (distance < radius)
        {
            RaycastHit hitObject;

            Vector3 GetPlayerPos = player.transform.position - transform.position;

            if (Physics.Raycast(transform.position, GetPlayerPos, out hitObject, radius) && hitObject.transform.tag == "Visible")
            {
                GetComponent<Targeting>().enabled = true;
            }
            else
            {
                GetComponent<Targeting>().enabled = false;
            }
        }
        else
        {
            GetComponent<Targeting>().enabled = false;
        }
    }
}
