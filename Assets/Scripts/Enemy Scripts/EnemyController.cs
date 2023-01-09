using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    float collisonTimer;
    public GameObject HUD;

    private void Start()
    {
        HUD = GameObject.FindGameObjectWithTag("UI");
    }
    private void OnTriggerEnter(Collider collidedObject)
    {
        if (collidedObject.tag == "Visible")
        {
            collisonTimer = 0;
            HUD.GetComponent<HealthController>().ReduceLifeByTag(this.tag);

            GetComponent<MeshRenderer>().enabled = false;
            Destroy(this.gameObject, 0.4f);
        }
    }

    private void OnTriggerStay(Collider collidedObject)
    {
        collisonTimer += Time.deltaTime;

        if (collidedObject.tag == "Visible" && collisonTimer >= 2)
        {
            collisonTimer = 0;
            HUD.GetComponent<HealthController>().ReduceLifeByTag(this.tag);
        }
    }
}
