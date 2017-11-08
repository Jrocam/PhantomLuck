using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class SwordLogic : NetworkBehaviour {
    public float maxRayDistance = 10;
    public LayerMask activeLayers;
    public int golpe = 0; //controlar el ray
    public GameObject pbody; //cuerpo con el network identity
    public NetworkInstanceId networkid;

    private void Start()
    {
        networkid = pbody.GetComponent<NetworkIdentity>().netId;
    }
    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position,transform.up); 
        RaycastHit[] hits = Physics.RaycastAll(ray, maxRayDistance, activeLayers);
        Debug.DrawRay(transform.position,transform.up * maxRayDistance, Color.red);
        foreach(RaycastHit hit in hits)
        {
            //Debug.Log("HITIN SEMTHING?");
            if (golpe == 0 && !pbody.GetComponent<NetworkIdentity>().isLocalPlayer)
            {
                GameObject otro = hit.transform.gameObject;
                Debug.Log("HITeD OThER");
                Debug.DrawLine(hit.point, hit.point + transform.up * maxRayDistance, Color.green);
                float vida_otro = otro.gameObject.GetComponent<EntityStats>()._playerHealth;
                CmdSwordSlash(vida_otro,otro);
                StartCoroutine(OneHit());
            }/*else if (pbody.GetComponent<NetworkIdentity>().isLocalPlayer)
            {
                Debug.Log("HET YERSELF");
            }*/
        }
    }

    [Command]
    void CmdSwordSlash(float health, GameObject otro)
    {
        otro.gameObject.GetComponent<EntityStats>()._playerHealth = health - 10f;
    }

    IEnumerator OneHit()
    {
        //Espera 0f segundos antes de morir
        golpe = 1;
        yield return new WaitForSeconds(1f);
        golpe = 0;
    }
}
