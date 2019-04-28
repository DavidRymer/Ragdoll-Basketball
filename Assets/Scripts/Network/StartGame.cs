using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class StartGame : MonoBehaviourPunCallbacks
{
    public GameObject spawnpoint1;
    public GameObject ballSpawnPoint;
    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("Player", spawnpoint1.transform.position, Quaternion.identity);
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1) PhotonNetwork.Instantiate("Ball", ballSpawnPoint.transform.position, Quaternion.identity);
    }
}
