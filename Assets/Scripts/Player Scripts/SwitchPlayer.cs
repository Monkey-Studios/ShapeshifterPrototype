using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayer : MonoBehaviour
{
	// referenses to controlled game objects
	public GameObject avatar1, avatar2, avatar3;
	CharacterControllerScript Cc;
	// Use this for initialization
	void Start()
	{
		// enable first avatar and disable another one
		avatar1.gameObject.SetActive(true);
		avatar2.gameObject.SetActive(false);
		avatar3.gameObject.SetActive(false);
		Cc = GetComponent<CharacterControllerScript>();
	}
	void Update()
    {
		SwitchAvatar();
    }

    // public method to switch avatars by pressing UI button
    public void SwitchAvatar()
	{

		if (Input.GetKeyDown("1"))
		{
			avatar1.gameObject.SetActive(true);
			avatar2.gameObject.SetActive(false);
			avatar3.gameObject.SetActive(false);
			gameObject.tag = "Visible";
			Cc.currentPlayer = 0;
		}
		else if (Input.GetKeyDown("2"))
		{
			avatar1.gameObject.SetActive(false);
			avatar2.gameObject.SetActive(true);
			avatar3.gameObject.SetActive(false);
			gameObject.tag = "Visible";
			Cc.currentPlayer = 1;
		}
		else if (Input.GetKeyDown("3"))
		{
			avatar1.gameObject.SetActive(false);
			avatar2.gameObject.SetActive(false);
			avatar3.gameObject.SetActive(true);
			gameObject.tag = "Invisible";
			Cc.currentPlayer = 2;
		}
    }

	}