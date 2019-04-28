using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class JoinRoom : MonoBehaviour
{

    public void Join(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
        SceneManager.LoadScene("Game");
    }

}