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

        public static ReplayManager Instance;

        private bool isRecording;
        //private bool playbackStarted;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

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

                OnStartPlayback();


                //if (!playbackStarted)
                //{
                //    playbackStarted = true;
                //    OnStartPlayback();
                //}
                //else
                //{
                //    playbackStarted = false;
                //    OnStopPlayback();
                //}
            }
        }

        public void StartRecording()
        {
            OnStartRecording();
        }

        public void StopRecording()
        {
            OnStopRecording();
        }

        public void StartPlayback()
        {
            OnStartPlayback();
        }
    }
}