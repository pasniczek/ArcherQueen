using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
	PhotonView PV;

	GameObject player;

	GameObject cam;

	public Vector2 playerSpawn;

	void Awake()
	{
		PV = GetComponent<PhotonView>();
	}

	void Start()
	{
		if(PV.IsMine)
		{
			CreateControllerAC();
		}
	}

	void CreateControllerAC()
	{
		// Transform spawnpoint = SpawnManager.Instance.GetSpawnpoint();
		player = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerWCamera"), playerSpawn, Quaternion.identity);
	}

	// public void Die()
	// {
	// 	PhotonNetwork.Destroy(controller);
	// 	CreateController();
	// }
}