using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Golf
{
    public class Stick : MonoBehaviour
    {
        public UnityEvent<Collider> onCollider;
        private void OnCollisionEnter(Collision collision)
        {
            onCollider.Invoke(collision.collider);
        }
    }
}