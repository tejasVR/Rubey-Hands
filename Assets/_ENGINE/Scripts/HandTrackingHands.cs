using Aperion.RubeyHands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XREngine.Common;

namespace XREngine.VR.HandTracking
{
    public class HandTrackingHands : MonoBehaviour
    {
        [SerializeField] Transform grabPoint;

        private Interactable interactable;
        private HandsGrabbable objectToGrab;

        private OVRHand ovrHand;
        private SkinnedMeshRenderer handMesh;

        private void Awake()
        {
            ovrHand = GetComponent<OVRHand>();
            handMesh = GetComponentInChildren<SkinnedMeshRenderer>();
        }

        private void OnEnable()
        {
            GestureRecognition.OnRightHandIndexPinching += GrabObject;
            GestureRecognition.OnRightHandIndexNotPinching += ReleaseObject;
        }

        private void OnDisable()
        {
            GestureRecognition.OnRightHandIndexPinching -= GrabObject;
            GestureRecognition.OnRightHandIndexNotPinching -= ReleaseObject;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Interactable>())
            {
                var interacted = other.GetComponent<Interactable>();

                if (interacted.GetComponent<HandsGrabbable>())
                {
                    SetObjectGrabbableObject(interacted.GetComponent<HandsGrabbable>());
                }

                interacted.Select();

                //if (interacted == interactable)
                //{
                //    objectToGrab = null;
                //    interacted.Unselect();
                //}
                //else
                //{
                //    if (interacted.GetComponent<HandsGrabbable>())
                //    {
                //        SetObjectGrabbableObject(interacted.GetComponent<HandsGrabbable>());
                //    }
                //    interacted.Select();
                //}               
            }
        }

        private void Update()
        {
            // Hide the Hands mesh depending on the tracking confidence level
            if (ovrHand.HandConfidence < OVRHand.TrackingConfidence.Low)
            {
                if (handMesh.enabled)
                {
                    handMesh.enabled = false;
                }
            }
            else
            {
                if (!handMesh.enabled)
                {
                    handMesh.enabled = true;
                }
            }
        }

        private void GrabObject()
        {
            if (objectToGrab != null)
            {
                objectToGrab.Grab(grabPoint);
            }
        }

        private void ReleaseObject()
        {
            if (objectToGrab != null)
            {
                objectToGrab.Release();
            }

            objectToGrab = null;
        }

        private void SetObjectGrabbableObject(HandsGrabbable _grabbableObject)
        {
            objectToGrab = _grabbableObject;
        }


    }
}


