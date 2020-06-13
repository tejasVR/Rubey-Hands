using HighlightPlus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XREngine.Common;

namespace XREngine.VR.HandTracking
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

        public override void Select()
        {
            if (selected)
            {                
                Unhighlight();
                selected = false;
            }
            else
            {
                Highlight();
                selected = true;
            }

            //selected = true;
            //highlight.enabled = true;
            //highlight.outlineColor = selectedColor;
        }

        private void Highlight()
        {
            highlight.enabled = true;
            highlight.outlineColor = selectedColor;
        }

        private void Unhighlight()
        {           
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
            Unhighlight();
        }
    }
}