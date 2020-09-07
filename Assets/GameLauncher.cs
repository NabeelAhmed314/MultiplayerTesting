using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class GameLauncher : MonoBehaviourPunCallbacks
{

    public GameObject InputPanel;
    public GameObject ConnectingPanel;
    public GameObject LobbyPanel;


    private void Start()
    {
    InputPanel.SetActive(true);
    ConnectingPanel.SetActive(false);
    LobbyPanel.SetActive(false);
}

public void ConnectedToPhotonServer()
    {
        if (!PhotonNetwork.IsConnected)
        {
            InputPanel.SetActive(false);
            ConnectingPanel.SetActive(true);
            LobbyPanel.SetActive(false);
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        InputPanel.SetActive(false);
        ConnectingPanel.SetActive(false);
        LobbyPanel.SetActive(true);
        PhotonNetwork.AutomaticallySyncScene = true;
        Debug.Log(PhotonNetwork.NickName + "  is Connected to server");
    }

    public override void OnConnected()
    {
        Debug.Log("Connected to Internet");
    }

    public void OnEnterGameClicked()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to join random game but failed. There must be no open games available. " + message);
        CreateRoom();
    }

    void CreateRoom()
    {
        Debug.Log("Trying to create room");
        int randomRoomName = Random.Range(0, 10000);
        RoomOptions roomOptions = new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = 10,
        };
        PhotonNetwork.CreateRoom("Room" + randomRoomName, roomOptions);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("We Are in a Room! Yeah");
        PhotonNetwork.LoadLevel("PlayArea");    
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to create random game but failed. There must be game with same name. " + message);
        CreateRoom();
    }





}
