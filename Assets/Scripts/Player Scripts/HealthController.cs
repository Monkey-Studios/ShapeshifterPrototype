using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    public GameObject healthBar;
    public GameObject player;

    private float currentLife;
    public float CurrentLife
    {
        get
        {
            return currentLife;
        }
        set
        {
            currentLife = value;
            healthBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, currentLife);

            if (currentLife <= 0)
            {
                Destroy(player.gameObject);
                SceneManager.LoadScene("Defeat");
                Debug.Log("Call Game Over subroutines");
            }
        }
    }

    void Start()
    {
        CurrentLife = 100f;
    }
    public void ReduceLifeByTag(string tag)
    {
        Debug.Log("This is getting the message");
        switch(tag)
        {
            case "Enemy":
                CurrentLife -= 10f;
                break;
            case "HealthPack":
                if(CurrentLife<100)
                CurrentLife += 25f;
                break;
            default:
                break;

        }
    }

}
