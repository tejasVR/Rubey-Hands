using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aperion.RubeyHands
{
    public class HandReplay : MonoBehaviour
    {
        [SerializeField] GameObject nonReplayHand;

        [SerializeField] Collider fingerCollider;

        [SerializeField] OVRHand ovrHand;
        [SerializeField] OVRCustomSkeleton ovrCustomSkeleton;

        private void Start()
        {
            nonReplayHand.SetActive(false);
        }

        private void OnEnable()
        {
            ReplayManager.OnStartRecording += EnableHandScripts;

            ReplayManager.OnStartPlayback += DisableHandsScripts;
        }

        private void OnDisable()
        {
            ReplayManager.OnStartRecording -= EnableHandScripts;

            ReplayManager.OnStartPlayback -= DisableHandsScripts;
        }
       
        private void EnableHandScripts()
        {
            fingerCollider.enabled = true;
            ovrHand.enabled = true;
            ovrCustomSkeleton.enabled = true;

            nonReplayHand.SetActive(false);
        }
        private void DisableHandsScripts()
        {
            fingerCollider.enabled = false;
            ovrHand.enabled = false;
            ovrCustomSkeleton.enabled = false;

            nonReplayHand.SetActive(true);
        }

    }
}


