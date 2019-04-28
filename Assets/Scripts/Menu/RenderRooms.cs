using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RenderRooms : MonoBehaviourPunCallbacks
{
    public GameObject componentPrefab;
    private List<RoomInfo> rooms = new List<RoomInfo>();

    private void Start()
    {
        
        
        PhotonView photonView = PhotonView.Get(this);
    }



    public void RenderComponents()
    {
        var components = RoomsToComponents();

        if (components != null)
        {
            for (int i = 0; i < components.Length; i++)
            {
                var comp = Instantiate(components[i], Vector3.zero, Quaternion.identity, transform);
                comp.transform.localPosition = new Vector3(100, -80 - 20 * i, 0);
            }
        }
    }

    private GameObject[] RoomsToComponents()
    {
        var components = new List<GameObject>();
        if (rooms != null)
        {
            foreach (var room in rooms)
            {
                components.Add(CreateComponent(room));
            }
        }

        return components.ToArray();
    }

    private GameObject CreateComponent(RoomInfo room)
    {
        var newComponent = componentPrefab;
        newComponent.transform.Find("RoomName").GetComponent<Text>().text = room.Name;
        newComponent.transform.Find("Players").GetComponent<Text>().text = room.PlayerCount + "/" + room.MaxPlayers;
        return newComponent;
    }

    private bool DoesRoomExist(string roomName)
    {
        if (rooms == null) return false;

        foreach (var room in rooms)
        {
            if (room.Name == roomName)
            {
                return true;
            }
        }

        return false;
    }
    private void AddRoom(RoomInfo room)
    {
        Debug.Log(room.Name);
        if (room.MaxPlayers > 0 && !DoesRoomExist(room.Name)) rooms.Add(room);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        PhotonNetwork.RaiseEvent((byte) EventCaching.AddToRoomCache, roomList, RaiseEventOptions.Default, SendOptions.SendReliable);
        Debug.Log("Hello world");
        roomList.ForEach(room => AddRoom(room));

        RenderComponents();
    }
}
