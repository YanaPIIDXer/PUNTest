using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Game.Flow
{
    /// <summary>
    /// ゲームフロー管理クラス
    /// </summary>
    public class GameFlow : MonoBehaviourPunCallbacks
    {
        void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("On Connected Server!");
            PhotonNetwork.JoinLobby();
        }

        public override void OnJoinedLobby()
        {
            Debug.Log("On Joined Lobby!");
            Debug.Log("RoomCount:" + PhotonNetwork.CountOfRooms);
            if (PhotonNetwork.CountOfRooms == 0)
            {
                PhotonNetwork.CreateRoom("TestRoom");
            }
            else
            {
                // TOOD:適当に入る処理
            }
        }

        public override void OnCreatedRoom()
        {
            Debug.Log("Room Create Success!");
            Debug.Log("Name:" + PhotonNetwork.CurrentRoom.Name);
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            Debug.LogError("Create Room Failed. Message:" + message);
        }
    }
}
