using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using Photon.Pun;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;
using Photon.Realtime;
using ExitGames.Client.Photon;

namespace Game.Player
{
    /// <summary>
    /// 画像送信
    /// </summary>
    public class ImageSender : MonoBehaviour
    {
        /// <summary>
        /// PhotonView
        /// </summary>
        private PhotonView View = null;

        /// <summary>
        /// ストリーム開始イベントコード
        /// </summary>
        public const int BeginStreamEventCode = 10;

        /// <summary>
        /// ストリーミングイベントコード
        /// </summary>
        public const int StreamingEventCode = 11;

        /// <summary>
        /// ストリーム送信中？
        /// </summary>
        private bool bIsStreaming = false;

        void Awake()
        {
            View = GetComponent<PhotonView>();
            this.UpdateAsObservable()
                .Where(_ => View.IsMine && Input.GetKeyDown(KeyCode.I) && !bIsStreaming)
                .Subscribe(_ => Execute());
        }

        /// <summary>
        /// 実行
        /// </summary>
        private async void Execute()
        {
            var DownloadedTexture = await DownloadImage();

            int Width = DownloadedTexture.width;
            int Height = DownloadedTexture.height;
            byte[] RawData = DownloadedTexture.GetRawTextureData();
            int DataLength = RawData.Length;

            int[] TexInfo = new int[] { View.ViewID, Width, Height, DataLength };

            RaiseEventOptions EventOps = new RaiseEventOptions
            {
                CachingOption = EventCaching.DoNotCache,
                Receivers = ReceiverGroup.All,
            };

            SendOptions SendOps = new SendOptions
            {
                Reliability = true,
            };
            PhotonNetwork.RaiseEvent(BeginStreamEventCode, TexInfo, EventOps, SendOps);

            bIsStreaming = true;
            RawData.ToObservable()
                   .Buffer(1024 * 5)
                   .Subscribe(async (Data) =>
                   {
                       byte[] SendData = new byte[Data.Count];
                       Data.CopyTo(SendData, 0);
                       PhotonNetwork.RaiseEvent(StreamingEventCode, SendData, EventOps, SendOps);
                       await UniTask.Delay(10);
                   }).AddTo(gameObject);
            bIsStreaming = false;
        }

        /// <summary>
        /// 画像のダウンロード
        /// </summary>
        /// <returns>テクスチャ</returns>
        private async UniTask<Texture2D> DownloadImage()
        {
            var Request = UnityWebRequestTexture.GetTexture("https://pbs.twimg.com/profile_images/1181428975328841729/Jaqmb94s_400x400.jpg");
            await Request.SendWebRequest();
            return DownloadHandlerTexture.GetContent(Request);
        }

        public void OnEvent(EventData photonEvent)
        {
            switch (photonEvent.Code)
            {
                case 10:

                    Debug.Log("Start Streaming.");
                    break;
            }
        }
    }
}
