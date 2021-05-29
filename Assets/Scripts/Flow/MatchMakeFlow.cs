﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

namespace Game.Flow
{
    /// <summary>
    /// マッチメイクフロー管理クラス
    /// </summary>
    public class MatchMakeFlow : MonoBehaviourPunCallbacks
    {
        void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        // ↓本当はこんな残し方しちゃダメ
        //  Pun2Taskとの比較用にあえて残してある
#if false
        public override void OnDisconnected(DisconnectCause cause)
        {
            if (cause != DisconnectCause.DisconnectByClientLogic)       // ←PlayModeを終了した時もコレが飛んでくる
            {
                Debug.LogError("Disconnected... Reason:" + cause.ToString());
            }
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
                SceneManager.LoadScene("Game");
                PhotonNetwork.CreateRoom("TestRoom");
            }
        }

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            Debug.Log("OnUpdateRoomList Count:" + roomList.Count);
            RoomInfo Join = null;
            foreach (var Room in roomList)
            {
                Debug.Log(Room.Name);
                if (Join == null)
                {
                    // とりあえず最初の部屋に突っ込む
                    Join = Room;
                }
            }

            if (Join != null)
            {
                SceneManager.LoadScene("Game");
                PhotonNetwork.JoinRoom(Join.Name);
            }
        }

        public override void OnCreatedRoom()
        {
            Debug.Log("Room Create Success!");
            Debug.Log("Name:" + PhotonNetwork.CurrentRoom.Name);
            // ↓注意：OnCreatedRoomの直後、勝手にOnJoinedRoomが呼ばれるフロー
            //SceneManager.LoadScene("Game");
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            Debug.LogError("Create Room Failed. Message:" + message);
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("Room Join Success!");
            Debug.Log("Name:" + PhotonNetwork.CurrentRoom.Name);
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            Debug.LogError("Join Room Failed. Message:" + message);
        }
#endif
    }
}
