using Aperion.RubeyHands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XREngine.VR.HandTracking
{
    public class HandTrackingHands : MonoBehaviour
    {
        [SerializeField] Transform grabPoint;

        private HandsGrabbable objectToGrab;

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
            if (other.GetComponent<HandsGrabbable>())
            {
                var grabbable = other.GetComponent<HandsGrabbable>();

                if (grabbable == objectToGrab)
                {
                    objectToGrab = null;
                    grabbable.Unselect();
                }
                else
                {
                    SetObjectGrabbableObject(grabbable);
                    grabbable.Select();
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


