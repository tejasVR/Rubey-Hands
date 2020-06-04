using Aperion.RubeyHands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XREngine.Common;

public class StartRecording : Interactable
{
    private bool isRecording;

    public override void Select()
    {
        if (isRecording)
        {
            ReplayManager.Instance.StopRecording();
            isRecording = false;
        }
        else
        {
            ReplayManager.Instance.StartRecording();
            isRecording = true;
        }
    }
}
