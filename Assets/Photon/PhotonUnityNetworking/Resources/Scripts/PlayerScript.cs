using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerScript : MonoBehaviourPunCallbacks
{
    public float moveSpeed;
    public float new_localX;
    public float new_localZ;
    public Grid[] grids;
    public GameObject cameraParent;
    void Initialize()
    {
        cameraParent.SetActive(photonView.IsMine);
        moveSpeed = 1;


    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine) return;

        new_localX = moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        new_localZ = moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Translate(new_localX, 0f, new_localZ);

    }
}







