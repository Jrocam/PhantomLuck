using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject _player;
    private Vector3 _offset;
	// Use this for initialization
	void Start () {
        //_player = GameObject.FindGameObjectWithTag("player");
        //_offset = _player.transform.position - (transform.position);//distancia de la camara al personaje
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //transform.position = _player.transform.position - _offset; //movemos la camara con el personaje
    }
}
