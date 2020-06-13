using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XREngine.Common;

namespace Aperion.RubeyHands
{
    public class PlaybackButton : Interactable
    {
        private bool playbackStarted;

        public override void Select()
        {
            base.Select();
            //TogglePlayback();
        }
    }
}


