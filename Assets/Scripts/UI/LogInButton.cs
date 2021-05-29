using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UniRx;
using UniRx.Triggers;
using System;
using Photon.Realtime;

namespace Game.UI
{
    /// <summary>
    /// ログインボタン
    /// </summary>
    public class LogInButton : MonoBehaviourPunCallbacks
    {
        /// <summary>
        /// ボタン
        /// </summary>
        private Button MyButton = null;

        void Awake()
        {
            MyButton = GetComponent<Button>();
            MyButton.OnClickAsObservable()
                .Subscribe((_) =>
                {
                    PhotonNetwork.ConnectUsingSettings();
                    MyButton.interactable = false;
                })
                .AddTo(gameObject);
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            MyButton.interactable = true;
        }
    }
}
