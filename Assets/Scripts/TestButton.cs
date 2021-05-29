using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using UnityEngine.UI;
using Network;

/// <summary>
/// 実験用ボタン
/// 後で消すやつ
/// </summary>
public class TestButton : MonoBehaviour
{
    /// <summary>
    /// 接続オブジェクト
    /// </summary>
    [SerializeField]
    private Connection Conn = null;

    void Awake()
    {
        GetComponent<Button>().OnClickAsObservable()
            .Subscribe((_) => Conn.Connect())
            .AddTo(gameObject);
    }
}
