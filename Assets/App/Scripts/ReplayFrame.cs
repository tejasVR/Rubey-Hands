using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aperion.RubeyHands
{
    [System.Serializable]
    public struct ReplayFrame
    {
        public Vector3 position;
        public Quaternion rotation;

        public ReplayFrame(Vector3 _position, Quaternion _rotation)
        {
            position = _position;
            rotation = _rotation;
        }
    }
}