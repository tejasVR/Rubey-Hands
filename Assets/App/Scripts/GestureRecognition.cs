using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Aperion.RubeyHands
{
    public class GestureRecognition : MonoBehaviour
    {
        public OVRHand leftHand;
        public OVRHand rightHand;

        [SerializeField] TextMeshProUGUI handRecognitionText;
        [SerializeField] TextMeshProUGUI leftHandDotProduct;

        private void Update()
        {
            PinchRecognition();
            OrientationRecognition();
        }

        private void SetText(string _text)
        {
            handRecognitionText.text = _text;
        }

        private void PinchRecognition()
        {
            // Left Hand
            if (leftHand.GetFingerIsPinching(OVRHand.HandFinger.Index))
            {
                SetText("Left Hand Pinching Using Index Finger");
            }
            else if (leftHand.GetFingerIsPinching(OVRHand.HandFinger.Middle))
            {
                SetText("Left Hand Pinching Using Middle Finger");
            }
            else if (leftHand.GetFingerIsPinching(OVRHand.HandFinger.Pinky))
            {
                SetText("Left Hand Pinching Using Pinky Finger");
            }
            else if (leftHand.GetFingerIsPinching(OVRHand.HandFinger.Ring))
            {
                SetText("Left Hand Pinching Using Ring Finger");
            }
            else if (leftHand.GetFingerIsPinching(OVRHand.HandFinger.Thumb))
            {
                SetText("Left Hand Pinching Using Thumb");
            }

            // Right Hand
            if (rightHand.GetFingerIsPinching(OVRHand.HandFinger.Index))
            {
                SetText("Right Hand Pinching Using Index Finger");
            }
            else if (rightHand.GetFingerIsPinching(OVRHand.HandFinger.Middle))
            {
                SetText("Right Hand Pinching Using Middle Finger");
            }
            else if (rightHand.GetFingerIsPinching(OVRHand.HandFinger.Pinky))
            {
                SetText("Right Hand Pinching Using Pinky Finger");
            }
            else if (rightHand.GetFingerIsPinching(OVRHand.HandFinger.Ring))
            {
                SetText("Right Hand Pinching Using Ring Finger");
            }
            else if (rightHand.GetFingerIsPinching(OVRHand.HandFinger.Thumb))
            {
                SetText("Right Hand Pinching Using Thumb");
            }
        }

        private void OrientationRecognition()
        {
            float leftHandDot = Vector3.Dot(leftHand.transform.up, Vector3.down);
            float rightHandDot = Vector3.Dot(rightHand.transform.up, Vector3.down);
            leftHandDotProduct.text = leftHandDot.ToString();


            // Left Hand
            if (leftHandDot < .2F && leftHandDot > -.2f)
            {
                SetText("Left Hand Palm Facing Right");
            }
            
            if (leftHandDot > .8F)
            {
                SetText("Left Hand Palm Down");
            }

            if (leftHandDot < -.8F)
            {
                SetText("Left Hand Palm Up");
            }


            // Right Hand
            if (rightHandDot < .2F && rightHandDot > -.2f)
            {
                SetText("Right Hand Palm Facing Right");
            }

            if (rightHandDot > .8F)
            {
                SetText("Right Hand Palm Up");
            }

            if (rightHandDot < -.8F)
            {
                SetText("Right Hand Palm Down");
            }
        }

    }
}


