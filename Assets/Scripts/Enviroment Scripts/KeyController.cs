using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyController : MonoBehaviour
{
    //Declare Variables
    public int score = 0;
    public Text keyText;
    // Start is called before the first frame update
    void Start()
    {
        keyText.text = score.ToString();
    }
    void OnTriggerEnter(Collider obj)
    {
       if(obj.tag == "Key")
        {
            obj.gameObject.SetActive(false);
            score++;
            keyText.text = score.ToString();
            if(score == 4)
            {
                SceneManager.LoadScene("Victory");
            }
        }
    }
}
