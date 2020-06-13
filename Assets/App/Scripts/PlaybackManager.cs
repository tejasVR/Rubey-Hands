using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XREngine.Common;

namespace Aperion.RubeyHands
{
    /// <summary>
    /// Controls the playback of game elements like marbles and froze game objects. Is not currently responsible for replays or time loops
    /// </summary>
    /// 

    public class PlaybackManager : MonoBehaviour
    {
        #region EVETNS

        public static event Action OnPlaybackStarted = delegate { };
        public static event Action OnPlaybackStopped = delegate { };

        #endregion

        [SerializeField] Interactable playbackButton;

        private bool playbackStarted;

        private void OnEnable()
        {
            playbackButton.OnSelected += TogglePlayback;
        }

        private void OnDisable()
        {
            playbackButton.OnSelected -= TogglePlayback;
        }

        private void TogglePlayback()
        {
            if (playbackStarted)
            {
                StopPlayback();
                
            }
            else
            {
                StartPlayback();
            }
        }

        private void StartPlayback()
        {
            OnPlaybackStarted();
            playbackStarted = true;
        }

        private void StopPlayback()
        {
            OnPlaybackStopped();
            playbackStarted = false;
        }


    }
}

