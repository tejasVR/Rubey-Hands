using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace XREngine.Common
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField] UnityEvent SelectEvent;
        //[SerializeField] UnityEvent UnselectEvent;

        public virtual void Select()
        {
            SelectEvent?.Invoke();
        }

        //public virtual void Unselect()
        //{
        //    UnselectEvent?.Invoke();
        //}
    }
}


