
using System.Data;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SortItems
{
    public class Getter : MonoBehaviour
    {
        [SerializeField] private ItemType type;
        private DragItem _item;
        private void OnTriggerStay(Collider other)
        {
            var item = other.attachedRigidbody.GetComponent<DragItem>();

            if (item != null && item.isDraggable == true) 
            {
                _item = item;
                return;
            }

            if (item.isDraggable == false && _item == item)
            {
                TryGetItem();
                _item = null;
                return;
            }


            
        }

        private void TryGetItem()
        {
            if(_item.Type == type)
            {
                Destroy(_item.gameObject);
            }
        }
        
        public enum ItemType
        {
            Blue,

            Yellow
        }

    }

}

