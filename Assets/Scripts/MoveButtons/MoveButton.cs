using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyMine;
using UnityEngine.EventSystems;

namespace CrossyMine
    {
    public class MoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public bool _ispressed = false;

        public void OnPointerDown(PointerEventData eventData)
        {
            _ispressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _ispressed = false;
        }
    }
}
