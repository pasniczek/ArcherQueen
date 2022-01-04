using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LoadingToServer : MonoBehaviour
{
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
}
