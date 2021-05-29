using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Network
{
    /// <summary>
    /// 接続クラス
    /// ※恐らくMonoBehaviourPunCallbacksなオブジェクトが登場すると、「PhotonMono」というシーンを跨いでも死なないオブジェクトが生成され、
    /// 　そいつが実際のコネクションを管理しているのかと思われる。
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
