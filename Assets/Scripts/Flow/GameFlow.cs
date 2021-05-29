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
            Debug.Log("On Connected!");
        }
    }
}
