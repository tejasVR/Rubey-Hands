using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aperion.RubeyHands
{
    [Serializable]
    public struct GameObjectFrame
    {
        public Vector3 position;
        public Quaternion rotation;
        public GameObject gameObject;

        public GameObjectFrame(GameObject _gameObject)
        {
            gameObject = _gameObject;
            position = _gameObject.transform.position;
            rotation = _gameObject.transform.rotation;
        }
    }

    [Serializable]
    public class ReplayFrame
    {
        public List<GameObjectFrame> gameObjectFrames = new List<GameObjectFrame>();

        public ReplayFrame(List<GameObject> _gameObjects)
        {
            for (int i = 0; i < _gameObjects.Count; i++)
            {
                gameObjectFrames.Insert(gameObjectFrames.Count, new GameObjectFrame(_gameObjects[i]));
            }
        }
    }


}