using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordLogic : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<EntityStats>()._playerHealth <= 0f)
        {
            Destroy(other.gameObject);
        }
    }
}
