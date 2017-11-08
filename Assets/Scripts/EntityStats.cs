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
            Cmdkill();
        }
    }

    [Command]
    public void Cmdkill()
    {
        Destroy(this.gameObject);
    }

    [Command]
    public void CmdTakeDamage(float daño)
    {
        this._playerHealth = _playerHealth - daño;
    }

    void OnChangeHealth(float _playerHealth)
    {
        healthBar.sizeDelta = new Vector2(_playerHealth, healthBar.sizeDelta.y);
    }


}
