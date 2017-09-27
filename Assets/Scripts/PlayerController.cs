using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    [SerializeField]
    private float moveSpeed=5f;
    private Vector3 moveInput;
    private Camera mainCamera;
    private Animator _panimator;
    public GameObject Sword;
    private Vector3 rotateInput;
    // Use this for initialization
    void Start()
    { 
        _panimator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Vertical") > 0f)
        {
            transform.Translate(new Vector3(0f, 0f, Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed));
        }
        transform.Rotate(new Vector3(0f, Input.GetAxis("Horizontal")*moveSpeed, 0f));
        if (Input.GetButtonDown("Fire1")) //FALTA SINCRONIZARLOS MUCHO la animacion/collider, no me dio la cabeza para hacerlo
        {
            Sword.SetActive(true);
        }
        if(Input.GetButtonUp("Fire1"))
        {
            Sword.SetActive(false);
        }
        _panimator.SetFloat("Attack", Input.GetAxis("Fire1"));//ATAQUE
        _panimator.SetFloat("Movedf", Input.GetAxis("Vertical")); //ACTIVAMOS LA CONDICION/PARAMETRO DEL ANIMATOR para mover
	}
}
