using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Network
{
    /// <summary>
    /// 接続クラス
    /// </summary>
    public class Connection : MonoBehaviourPunCallbacks
    {
        /// <summary>
        /// 接続
        /// </summary>
        public void Connect()
        {
            if (!PhotonNetwork.ConnectUsingSettings())
            {
                Debug.LogError("Fuck!!");
            }
        }

        public override void OnConnected()
        {
            Debug.Log("OnConnected()");
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("OnConnectedToMaster()");
        }
    }
}
