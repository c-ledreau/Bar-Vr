using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

[System.Serializable]
public class DefaultRoom
{
    public string Name;
    public int sceneIndex;
    public int maxPlayer;
}

public class networkManager : MonoBehaviourPunCallbacks
{

    public List<DefaultRoom> defaultRooms;
    public GameObject roomUI;
    // Update is called once per frame
    public void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try connect to server ...");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("connected to server");
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
    }


    public void InitializeRoom(int defaultRoomIndex)
    {
        DefaultRoom roomSettings = defaultRooms[defaultRoomIndex];
        //load Scene
        PhotonNetwork.LoadLevel(roomSettings.sceneIndex);

        //create room
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = (byte)roomSettings.maxPlayer;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom(roomSettings.Name, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("lobby joined");
        roomUI.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("joined the room");
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("a new player joined the room");
        base.OnPlayerEnteredRoom(newPlayer);
    }
}
