using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCrouchingScript : MonoBehaviour
{
    BoxCollider playerCol;
    float origionalHeight;
    public float reduceHeight;
    public GameObject player;
    public CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        playerCol = GetComponent<BoxCollider>();
        origionalHeight = playerCol.bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Crouch
        if (Input.GetKeyDown(KeyCode.C))
            Crouch();
        else if (Input.GetKeyUp(KeyCode.C))
            GetUp();
    }

    //Method used to reduce height
    void Crouch()
    {
        //playerCol.height /= 2;
        //cc.height /= 2;
        player.transform.localScale = new Vector3(1, 0.5f, 1);

    }

    //Method used to reset height
    void GetUp()
    {
        //playerCol.height *= 2;
        //cc.height *= 2;
        player.transform.localScale = new Vector3(1, 1, 1);

    }
}
