using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aperion.RubeyHands
{
    public class ReplayManager : MonoBehaviour
    {
        #region EVENTS

        public static event Action OnStartRecording = delegate { };
        public static event Action OnStopRecording = delegate { };
        
        public static event Action OnRewindToPoint = delegate { };

        public static event Action OnStartPlayback = delegate { };
        public static event Action OnStopPlayback = delegate { };

        #endregion

        private bool isRecording;
        private bool playbackStarted;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!isRecording)
                {
                    isRecording = true;
                    OnStartRecording();
                }
                else
                {
                    isRecording = false;
                    OnStopRecording();
                }
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (isRecording)
                {
                    OnStopRecording();
                }

                if (!playbackStarted)
                {
                    playbackStarted = true;
                    OnStartPlayback();
                }
                else
                {
                    playbackStarted = false;
                    OnStopRecording();
                }
            }
        }
    }
}