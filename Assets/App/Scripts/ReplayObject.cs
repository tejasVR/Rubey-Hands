using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aperion.RubeyHands
{
    public class ReplayObject : MonoBehaviour
    {
        [SerializeField] List<GameObject> gameObjectsToTrack;

        private List<ReplayFrame> frames = new List<ReplayFrame>();

        private bool isRecording;
        private bool playbackStarted;
        private int currentFrame;

        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            ReplayManager.OnStartRecording += StartRecording;
            ReplayManager.OnStopRecording += StopRecording;
            //ReplayManager.RewindToPointCallback += RewindToPoint;

            ReplayManager.OnStartPlayback += StartPlayback;
            ReplayManager.OnStopPlayback += StopPlayback;
        }

        private void OnDisable()
        {
            ReplayManager.OnStartRecording -= StartRecording;
            ReplayManager.OnStopRecording -= StopRecording;
            //ReplayManager.RewindToPointCallback -= RewindToPoint;

            ReplayManager.OnStartPlayback -= StartPlayback;
            ReplayManager.OnStopPlayback -= StopPlayback;
        }

        private void FixedUpdate()
        {
            if (isRecording)
            {
                Record();
            }

            if (playbackStarted)
            {
                if (currentFrame > frames.Count)
                    return;

                currentFrame += 1;

                ReplayFrame f = frames[currentFrame];
                //transform.position = Vector3.Lerp(transform.position, f.position, Time.deltaTime * 3F);
                //transform.rotation = Quaternion.Slerp(transform.rotation, f.rotation, Time.deltaTime * 3F);

                for (int i = 0; i < f.gameObjectFrames.Count; i++)
                {
                    f.gameObjectFrames[i].gameObject.transform.position = f.gameObjectFrames[i].position;
                    f.gameObjectFrames[i].gameObject.transform.rotation = f.gameObjectFrames[i].rotation;
                }
            }
        }

        private void Record()
        {
            //if (frames.Count > 10F)
            //{
            //    frames.RemoveAt(frames.Count - 1);
            //}

            frames.Insert(frames.Count, new ReplayFrame(gameObjectsToTrack));
        }

        private void StartRecording()
        {
            frames.Clear();
            isRecording = true;
        }

        private void StopRecording()
        {
            isRecording = false;
        }

        private void StartPlayback()
        {
            currentFrame = 0;
            playbackStarted = true;

            rb.useGravity = false;
        }

        private void StopPlayback()
        {
            playbackStarted = false;

            rb.useGravity = false;
        }
    }
}