using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
