using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class EntityStats : NetworkBehaviour {

    private const float _playerMaxHealth = 50f;
    public RectTransform healthBar;

    [SyncVar(hook ="OnChangeHealth")]
    public float _playerHealth = _playerMaxHealth;

    public float _playerStr = 20f;

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

    void OnChangeHealth(float _playerHealth)
    {
        healthBar.sizeDelta = new Vector2(_playerHealth, healthBar.sizeDelta.y);
    }


}
