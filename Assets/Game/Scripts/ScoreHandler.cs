using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SortItems
{
    public class ScoreHandler : MonoBehaviour
    {
        [SerializeField] private GetterParameters[] getters;

        public UnityEvent onFull;
        private void Start()
        {
            if (getters == null)
            {
                Debug.LogError("Getters is null");
                return;
            }

            foreach (var getter in getters)
            {
                getter.getter.SetCount(getter.targetCount);
                getter.getter.onCountChanged.AddListener(OnCountChanged);
            }
        }

        private void OnDestroy()
        {
            foreach (var getter in getters)
            {
                getter.getter.onCountChanged.RemoveListener(OnCountChanged);
            }
        }

        private void OnCountChanged(Getter trashCanGetter)
        {
            for (int i = 0; i < getters.Length; i++)
            {
                ref var item = ref getters[i];

                if (item.getter != trashCanGetter)
                {
                    continue;
                }

                item.count++;
            }

            bool full = true;

            foreach (GetterParameters item in getters)
            {
                if (item.count < item.targetCount)
                {
                    full = false;

                    break;
                }
            }

            if (full)
            {
                Debug.Log("win");
                onFull.Invoke();
            }
        }
    }

    [System.Serializable]
    public struct GetterParameters
    {
        public Getter getter;
        public int targetCount;
        [HideInInspector] public int count;
    }
}
