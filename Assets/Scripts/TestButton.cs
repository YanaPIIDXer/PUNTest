using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using UnityEngine.UI;
using Network;
using Photon.Pun;

/// <summary>
/// 実験用ボタン
/// 後で消すやつ
/// </summary>
public class TestButton : MonoBehaviour
{
    void Awake()
    {
        GetComponent<Button>().OnClickAsObservable()
            .Subscribe((_) => PhotonNetwork.ConnectUsingSettings())
            .AddTo(gameObject);
    }
}
