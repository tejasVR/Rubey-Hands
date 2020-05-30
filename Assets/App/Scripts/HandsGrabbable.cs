using HighlightPlus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XREngine.Common;

namespace Aperion.RubeyHands
{
    public class HandsGrabbable : Interactable
    {
        [SerializeField] Color selectedColor;
        [SerializeField] Color grabColor;

        private bool selected;
        private bool isGrabbed;

        private Transform followPoint;
        private HighlightEffect highlight;
        private void Awake()
        {
            highlight = GetComponentInChildren<HighlightEffect>();
        }

        private void LateUpdate()
        {
            if (isGrabbed && followPoint != null)
            {
                transform.position = Vector3.Lerp(transform.position, followPoint.position, Time.deltaTime * 10F);
                transform.rotation = Quaternion.Slerp(transform.rotation, followPoint.rotation, Time.deltaTime * 10F);
            }
        }

        public void Select()
        {
            selected = true;
            highlight.enabled = true;
            highlight.outlineColor = selectedColor;
        }

        public void Unselect()
        {
            selected = false;
            highlight.enabled = false;
        }

        public void Grab(Transform _pointToFollow)
        {
            if (!isGrabbed && selected)
            {
                followPoint = _pointToFollow;
                highlight.outlineColor = grabColor;

                isGrabbed = true;
            }
            
        }

        public void Release()
        {
            followPoint = null;
            highlight.enabled = false;

            isGrabbed = false;
            Unselect();
        }


    }
}