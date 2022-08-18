using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SortItems
{
    public class itemTrail : MonoBehaviour, IBeginDragHandler, IEndDragHandler
    {
        [SerializeField] private TrailRenderer _trailRenderer;

        private void Awake()
        {
            _trailRenderer.emitting = false;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _trailRenderer.emitting = true;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _trailRenderer.emitting = false;
        }
    }
    
}

