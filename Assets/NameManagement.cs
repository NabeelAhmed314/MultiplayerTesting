using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class NameManagement : MonoBehaviour
{ 
    public void SetPlayerName(string playerName)
    {
        if (string.IsNullOrEmpty(playerName))
        {
            Debug.Log("Player Name is Empty");
            return;
        }
        PhotonNetwork.NickName = playerName;
        Debug.Log(PhotonNetwork.NickName);
    }
}
