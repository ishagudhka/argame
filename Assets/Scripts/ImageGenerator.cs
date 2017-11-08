﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ImageGenerator : MonoBehaviour {

	public Sprite[] images;
	private bool[] used;
	System.Random rand;

	public GameObject[] targets;

	public GameObject imagePrefab;

	void Start(){
		rand = new System.Random (25);
		RefreshImages ();
	}
			
	public void RefreshImages(){
		used = new bool[images.Length];

		foreach (GameObject target in targets) {
			
			int random = rand.Next(0, images.Length);
			while(used[random] != false){
				random = rand.Next(0, images.Length);
			}

			GameObject go = Instantiate (imagePrefab, target.transform);
			go.GetComponent<SpriteRenderer> ().sprite = images [random];
			used [random] = true;
			Debug.Log (random);
		}

		Debug.Log ("Restarted!");
	}
}
