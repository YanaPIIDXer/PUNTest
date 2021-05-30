using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

namespace Game.Player
{
    public class ImageReceiver : MonoBehaviour, IOnEventCallback
    {
        /// <summary>
        /// PhotonView
        /// </summary>
        private PhotonView View = null;

        /// <summary>
        /// レンダラ
        /// </summary>
        private MeshRenderer Renderer = null;

        /// <summary>
        /// テクスチャの幅
        /// </summary>
        private int TextureWidth = 0;

        /// <summary>
        /// テクスチャの高さ
        /// </summary>
        private int TextureHeight = 0;

        /// <summary>
        /// 受信バッファ
        /// </summary>
        private byte[] RecvBuffer = null;

        /// <summary>
        /// 受信済みのデータ長
        /// </summary>
        private int CurrentLength = 0;

        /// <summary>
        /// ストリーミング受信中？
        /// </summary>
        private bool bIsStreaming = false;

        void Awake()
        {
            View = GetComponent<PhotonView>();
            Renderer = GetComponent<MeshRenderer>();
        }

        void OnEnable()
        {
            PhotonNetwork.AddCallbackTarget(this);
        }

        void OnDisable()
        {
            PhotonNetwork.RemoveCallbackTarget(this);
        }

        public void OnEvent(EventData photonEvent)
        {
            switch (photonEvent.Code)
            {
                case ImageSender.BeginStreamEventCode:

                    BeginStream(photonEvent.CustomData as int[]);
                    break;

                case ImageSender.StreamingEventCode:

                    if (bIsStreaming)
                    {
                        RecvStream(photonEvent.CustomData as byte[]);
                    }
                    break;
            }
        }

        /// <summary>
        /// ストリーム開始
        /// </summary>
        /// <param name="Info">情報</param>
        private void BeginStream(int[] Info)
        {
            if (View.ViewID != Info[0]) { return; }

            TextureWidth = Info[1];
            TextureHeight = Info[2];
            RecvBuffer = new byte[Info[3]];
            CurrentLength = 0;

            bIsStreaming = true;
        }

        /// <summary>
        /// ストリーム受信
        /// </summary>
        /// <param name="Data">データ</param>
        private void RecvStream(byte[] Data)
        {
            Data.CopyTo(RecvBuffer, CurrentLength);
            CurrentLength += Data.Length;
            if (CurrentLength >= RecvBuffer.Length)
            {
                bIsStreaming = false;

                Texture2D Tex = new Texture2D(TextureWidth, TextureHeight, TextureFormat.RGB24, false);
                Tex.LoadRawTextureData(RecvBuffer);
                Tex.Apply();

                Renderer.material.mainTexture = Tex;
            }
        }
    }
}
