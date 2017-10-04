using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour {

    public float _playerHealth = 100;
    public float _playerStr = 20;
    // Use this for initialization

    // Update is called once per frame
    void Update() {
        if (_playerHealth <= 0)
        {
            StartCoroutine(kill());
        }
    }
    IEnumerator kill()
    {
        //Espera 0f segundos antes de morir
        yield return new WaitForSeconds(0f); 
        Destroy(this.gameObject);
    }

}
