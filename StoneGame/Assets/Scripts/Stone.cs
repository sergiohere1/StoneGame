using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -30.0f) 
		{
			Destroy (gameObject);
		}
	}

	private void OnMouseDown()
	{
		//Instanciamos la explosion en la posición de la piedra y con el giro que tenga.
		Instantiate (explosion, transform.position, Quaternion.identity);
		Destroy (gameObject);
		GameManager.stonesDestroyed++;
	}


}
