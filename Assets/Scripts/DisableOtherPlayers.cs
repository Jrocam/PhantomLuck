using UnityEngine;
using UnityEngine.Networking;

public class DisableOtherPlayers : NetworkBehaviour {

	[SerializeField]
	Behaviour[] disableOtherComponents; // TODOS LOS COMPONENTES DEL OTRO 
	private Camera _sceneCamera;
	void Start()
	{
		if (!isLocalPlayer) //funcion de network behaviour
		{
			for(int i = 0; i < disableOtherComponents.Length; i++)
			{
				disableOtherComponents[i].enabled = false;
			}
		}
		else
		{
			_sceneCamera = Camera.main;
			if (_sceneCamera !=  null)
			{
				_sceneCamera.gameObject.SetActive(false);
			}

		}
	}



	//Volver a la camara original si destruyen el objeto padre del prefab
	private void OnDisable()
	{
		if(_sceneCamera != null)
		{
			_sceneCamera.gameObject.SetActive(true);
		}
	}
}
