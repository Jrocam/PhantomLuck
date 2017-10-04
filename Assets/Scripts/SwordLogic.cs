using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordLogic : MonoBehaviour {
    public float maxRayDistance = 10;
    public LayerMask activeLayers;

    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position,transform.up); 
        RaycastHit[] hits = Physics.RaycastAll(ray, maxRayDistance, activeLayers);
        Debug.DrawRay(transform.position,transform.up * maxRayDistance, Color.red);
        foreach(RaycastHit hit in hits)
        {
            if (hit.transform.gameObject.tag.Equals("Enemy"))
            {
                GameObject otro = hit.transform.gameObject;
                Debug.Log("HIT ThE ENEMY");
                Debug.DrawLine(hit.point, hit.point + transform.up * maxRayDistance, Color.green);
                float vida_otro = otro.gameObject.GetComponent<EntityStats>()._playerHealth;
                otro.gameObject.GetComponent<EntityStats>()._playerHealth = vida_otro - 100f;
            }
        }
    }
}
