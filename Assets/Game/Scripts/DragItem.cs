using UnityEngine;
using UnityEngine.EventSystems;

namespace SortItems
{
    public class DragItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        private Rigidbody rigidbody;
        [SerializeField]
        private ItemType type;
        public ItemType Type { get => type; }
        public bool isDraggable { get; private set; }

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            var position = eventData.pointerCurrentRaycast.worldPosition;
            var delta = position - transform.position;
            delta.y = 0;

            transform.position += delta;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            rigidbody.isKinematic = true;
            isDraggable = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            rigidbody.isKinematic = false;
            isDraggable = false;

        }
    }
}
