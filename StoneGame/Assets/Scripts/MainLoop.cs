﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLoop : MonoBehaviour {
    /// <summary>
    /// Array de GameObject donde sus componentes cero, uno y dos
    /// van a ser los tres prefab Stone que hayamos creado.
    /// </summary>
    public GameObject[] stones = new GameObject[3];
    /// <summary>
    /// Fuerza de torsión que vamos a aplicar en cada uno de los ejes para que
    /// la piedra tenga rotación inicial al crearse.
    /// </summary>
    public float torque = 5.0f;
    /// <summary>
    /// Valores que vamos a tener como fuerza cuando lancemos las piedras,
    /// que será un valor aleatorio entre 20 y 40.
    /// </summary>
    public float minAntiGravity = 20.0f, maxAntiGravity = 40.0f;
    /// <summary>
    /// Fuerza lateral con la que se lanzarán las piedras, con una fuerza comprendida
    /// entre un rango aleatorio entre -15 y 15.
    /// </summary>
    public float minLateralForce = -15.0f, maxLateralForce = 15.0f;
    /// <summary>
    /// Tiempo que vamos a tener que esperar entre el lanzamiento de una piedra y la
    /// siguiente.
    /// </summary>
    public float minTimeBetweenStones = 1f, maxTimeBetweenStones = 3f;
    /// <summary>
    /// Posicion X del lanzamiento de la piedra.
    /// </summary>
    public float minX = -30.0f, maxX = 30.0f;
    /// <summary>
    /// Posicion Z del lanzamiento de la piedra.
    /// </summary>
    public float minZ = -30.0f, maxZ = 30.0f;
    /// <summary>
    /// Booleano para habilitar el lanzamiento de piedras
    /// </summary>
    private bool enableStones = true;
    /// <summary>
    /// Rigidbody de la piedra que spawneemos.
    /// </summary>
    private Rigidbody rigidbody;
	/// <summary>
	/// La cantidad de piedras que se lanzan para que acabe la partida.
	/// </summary>
	public int amountStones = 20;


    // Use this for initialization
    void Start () {
        //Las corutinas se ejecutan tras todos los Update y/o si le especificamos un timempo de ejecución.
        StartCoroutine(ThrowStones());
	}

    private IEnumerator ThrowStones()
    {
		yield return new WaitForSeconds (3.0f);

		while (enableStones) {
			///Elegimos aleatoriamente una de las piedras que tengamos deltro del array de prefabs de piedras
			GameObject stone = Instantiate (stones [UnityEngine.Random.Range (0, stones.Length)]);
			//Elegimos la posicion en la que va a a aparecer
			stone.transform.position = new Vector3 (UnityEngine.Random.Range (minX, maxX), -30.0f, UnityEngine.Random.Range (minZ, maxX));
			//Le damos una rotación aleatoria
			stone.transform.rotation = UnityEngine.Random.rotation;
			//Obtenemos el Rigidbody de la piedra que hayamos obtendo aleatoriamente.
			rigidbody = stone.GetComponent<Rigidbody> ();

			//Le damos fuerzas aleatorias de giro en los tres ejes.
			rigidbody.AddTorque (Vector3.up * torque, ForceMode.Impulse);
			rigidbody.AddTorque (Vector3.right * torque, ForceMode.Impulse);
			rigidbody.AddTorque (Vector3.forward * torque, ForceMode.Impulse);

			//Aplicamos las fuerzas que moverán las piedras y les darán trayectorias.
			rigidbody.AddForce (Vector3.up * UnityEngine.Random.Range (minAntiGravity, maxAntiGravity), ForceMode.Impulse);
			rigidbody.AddForce (Vector3.right * UnityEngine.Random.Range (minLateralForce, maxLateralForce), ForceMode.Impulse);
		
			GameManager.stonesThrown++;

			if (GameManager.stonesThrown == amountStones) {
				enableStones = false;
				yield return new WaitForSeconds (6.0f);
			} else {
				
				//Una vez que termina la corutina, se para y cede el control a Unity.
				yield return new WaitForSeconds (UnityEngine.Random.Range (minTimeBetweenStones, maxTimeBetweenStones));
			}
		}

		SceneManager.LoadScene ("Final");
       
    }

    // Update is called once per frame
    void Update () {
		
	}
}
