using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace XREngine.Common
{
    public class Interactable : MonoBehaviour
    {
        #region EVENTS

        public event Action OnSelected = delegate { };

        #endregion

        [FoldoutGroup("Events")]
        [SerializeField] UnityEvent SelectEvent;
        //[SerializeField] UnityEvent UnselectEvent;

        public virtual void Select()
        {
            OnSelected();
            SelectEvent?.Invoke();
        }

        //public virtual void Unselect()
        //{
        //    UnselectEvent?.Invoke();
        //}
    }
}


