using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterfaceFinal : MonoBehaviour {

	public Text textThrown;
	public Text textDestroyed;

	// Use this for initialization
	void Start () {
		textThrown.text = string.Format ("Number of Stones thrown: {0}", GameManager.stonesThrown.ToString());
		textDestroyed.text = string.Format ("Number of Stones destroyed: {0}", GameManager.stonesDestroyed.ToString());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick(){
		SceneManager.LoadScene ("StoneGame");
	}

}
