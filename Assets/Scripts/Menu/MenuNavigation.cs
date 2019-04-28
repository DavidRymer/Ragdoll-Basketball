using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    public void LoadScene(string sceneName) => SceneManager.LoadScene(sceneName);

    public void LoadSceneLeaveRoom(string sceneName) {
        PhotonNetwork.LeaveRoom();
        LoadScene(sceneName);
    }
    
}
