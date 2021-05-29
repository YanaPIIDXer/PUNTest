using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Network
{
    /// <summary>
    /// 接続クラス
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// 接続
        /// </summary>
        public void Connect()
        {
        }

        #region Singleton
        public static Connection Instance { get { return _Instance; } }
        private static Connection _Instance = new Connection();
        private Connection() { }
        #endregion
    }
}
