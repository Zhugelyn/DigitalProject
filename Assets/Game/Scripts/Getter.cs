using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SortItems
{
    public class Getter : MonoBehaviour
    {
        [SerializeField] private ItemType type; 
        private DragItem _item;

        private int targetCount = 1;
        private int count = 0;

        private bool active = true;

        public UnityEvent<Getter> onCountChanged;

        public void SetCount(int value)
        {
            targetCount = value;
        }
        
        private void OnTriggerStay(Collider other)
        {
            if (!active)
                return;

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
            if (_item.Type == type)
            {
                Destroy(_item.gameObject);
                count++;
            }

            onCountChanged.Invoke(this);

            if (targetCount <= count)
            {
                active = false;
            }
        }
    }
}
