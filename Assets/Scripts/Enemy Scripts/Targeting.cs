using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    public GameObject target;
    private Vector3 directionToTarget;
    private float angleToTarget;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Visible");
    }
    // Update is called once per frame
    void Update()
    {
        directionToTarget = target.transform.position - transform.position;
        angleToTarget = Mathf.Atan2(directionToTarget.x, directionToTarget.z) * Mathf.Rad2Deg;
        //Debug.Log(directionToTarget + ". Angle: " + angleToTarget);

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, angleToTarget, transform.eulerAngles.z);
    }
}
