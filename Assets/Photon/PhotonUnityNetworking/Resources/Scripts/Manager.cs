using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Photon.Pun;

public class Manager : MonoBehaviour
{
    public string player_prefab;
    public Transform spawn_point;
    private void Start()
    {
        Debug.Log("Done");
        Spawn();
    }
    public void Spawn()
    {
        Debug.Log("Creating Player");
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", player_prefab), Vector3.zero + new Vector3(1, 0f, 0), Quaternion.identity);
    }
}


