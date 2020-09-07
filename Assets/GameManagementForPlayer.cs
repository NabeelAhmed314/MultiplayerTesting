using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class GameManagementForPlayer : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        OnJoinedRoom();
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("In Game Scene");
        PhotonNetwork.Instantiate("Player",transform.position,Quaternion.identity);
    }
}
