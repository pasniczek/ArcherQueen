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

	private bool camFollow = false;

	void Awake()
	{
		PV = GetComponent<PhotonView>();
	}

	void Start()
	{
		if(PV.IsMine)
		{
			CreateControllerAC();

			cam = GameObject.Find("PlayerWCamera/MainCamera");
			camFollow = true;
		}
	}

	void CreateControllerAC()
	{
		// Transform spawnpoint = SpawnManager.Instance.GetSpawnpoint();
		player = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerWCamera"), playerSpawn, Quaternion.identity);
	}

	void Update()
	{
		if(camFollow)
		{
			Vector2.MoveTowards(cam.transform.position, player.transform.position, .03f);
		}
	}
}