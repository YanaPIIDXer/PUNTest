using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

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
                PhotonNetwork.JoinRoom(Join.Name);
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

        public override void OnJoinedRoom()
        {
            Debug.Log("Room Join Success!");
            Debug.Log("Name:" + PhotonNetwork.CurrentRoom.Name);
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            Debug.LogError("Join Room Failed. Message:" + message);
        }
    }
}
