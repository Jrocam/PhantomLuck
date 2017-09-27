using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour {

    public float _playerHealth=100;
    public float _playerStr = 20;
    public Collider _Sword;
    // Use this for initialization
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {

        _playerHealth = _playerHealth - 20f;
    }
}
