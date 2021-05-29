using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Game.Player
{
    /// <summary>
    /// プレイヤー移動Component
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMove : MonoBehaviour
    {
        /// <summary>
        /// 移動ベクトル
        /// </summary>
        private Vector2 MoveVector = Vector2.zero;

        /// <summary>
        /// Rigidbody
        /// </summary>
        private Rigidbody Body = null;

        /// <summary>
        /// PhotonView
        /// </summary>
        private PhotonView View = null;

        void Awake()
        {
            Body = GetComponent<Rigidbody>();
            View = GetComponent<PhotonView>();
        }

        void Update()
        {
            MoveVector.x = Input.GetAxis("Horizontal");
            MoveVector.y = Input.GetAxis("Vertical");
        }

        void FixedUpdate()
        {
            if (View.IsMine)
            {
                Body.velocity = new Vector3(MoveVector.x, 0.0f, MoveVector.y);
            }
        }
    }
}
