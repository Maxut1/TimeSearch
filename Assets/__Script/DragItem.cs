using System.Transactions;
using System.Diagnostics.Tracing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SortItems
{
    
    public class DragItem : MonoBehaviour, IPointerDownHandler,  IPointerUpHandler, IDragHandler
    {
        private Rigidbody _rigidbody;
        public bool isDraggable {get; private set;}
        [SerializeField] private ItemType _type;
        public ItemType Type {get => _type;}

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        public void OnDrag(PointerEventData eventData)
        {
            var pos = eventData.pointerCurrentRaycast.worldPosition;
            var delta = pos - transform.position;
            delta.y = 0;

            transform.position += delta;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _rigidbody.isKinematic = true;
            isDraggable = true;
        }
        
        public void OnPointerUp(PointerEventData eventData)
        {
            _rigidbody.isKinematic = false;
             isDraggable = false;
        }
    }
}

