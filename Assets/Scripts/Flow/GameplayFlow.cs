using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Game.Flow
{
    /// <summary>
    /// ゲームプレイフロー
    /// </summary>
    public class GameplayFlow : MonoBehaviourPunCallbacks
    {
        void Awake()
        {
            PhotonNetwork.Instantiate("Prefabs/Player", Vector3.zero, Quaternion.identity);
        }
    }
}
