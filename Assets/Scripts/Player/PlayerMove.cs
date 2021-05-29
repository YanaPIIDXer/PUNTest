using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        void Awake()
        {
            Body = GetComponent<Rigidbody>();
        }

        void Update()
        {
            MoveVector.x = Input.GetAxis("Horizontal");
            MoveVector.y = Input.GetAxis("Vertical");
        }

        void FixedUpdate()
        {
            Body.velocity = new Vector3(MoveVector.x, 0.0f, MoveVector.y);
        }
    }
}
