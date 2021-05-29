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
            PhotonNetwork.Instantiate("Prefabs/Player", new Vector3(0.0f, 0.5f, 0.0f), Quaternion.identity);
        }
    }
}
