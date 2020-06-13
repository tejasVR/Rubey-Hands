using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aperion.RubeyHands
{
    [RequireComponent(typeof(Rigidbody))]
    public class Marble : MonoBehaviour
    {
        private Rigidbody rb;
        private Vector3 origin;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            origin = transform.position;
        }

        private void OnEnable()
        {
            PlaybackManager.OnPlaybackStarted += StartPlayback;
            PlaybackManager.OnPlaybackStopped += StopPlayback;
        }

        private void OnDisable()
        {
            PlaybackManager.OnPlaybackStarted -= StartPlayback;
            PlaybackManager.OnPlaybackStopped -= StopPlayback;
        }

        private void Start()
        {
            DisablePhysics();
        }

        private void StartPlayback()
        {
            EnablePhysics();
        }

        private void StopPlayback()
        {
            DisablePhysics();
            transform.position = origin;
        }

        private void EnablePhysics()
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }

        private void DisablePhysics()
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }
    }
}


