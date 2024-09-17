using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Golf
{
    public static class GameEvents
    {
        public static Action onCollisionStone;
        public static Action onStickHit;
        public static void CollisionStoneInvoke(Collision collision)
        {
            onCollisionStone?.Invoke();
        }

        public static void StickHit()
        {
            onStickHit?.Invoke();
        }
    }
}