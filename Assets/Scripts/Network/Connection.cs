using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Game.Network
{
    /// <summary>
    /// 接続クラス
    /// ※恐らくMonoBehaviourPunCallbacksなオブジェクトが登場すると、「PhotonMono」というシーンを跨いでも死なないオブジェクトが生成され、
    /// 　そいつが実際のコネクションを管理しているのかと思われる。
    /// 　　→コイツをシーンから消してもPhotonMonoが生成された。PUNを導入すると勝手に生成されるようになってる・・・？
    /// </summary>
    public class Connection : MonoBehaviourPunCallbacks
    {
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
