using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class CreateRoom : MonoBehaviour
{
    public GameObject roomNameField;
    public GameObject numberOfPlayersDropdown;
    public void Submit()
    {
        string roomName = roomNameField.transform.Find("Text").GetComponent<Text>().text;
        byte maxPlayers = (byte) numberOfPlayersDropdown.GetComponent<Dropdown>().value;
        PhotonNetwork.CreateRoom(roomName, new RoomOptions() { MaxPlayers = maxPlayers }, TypedLobby.Default);
    }

}
