using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SortItems
{
    public class ScoreHandler : MonoBehaviour
    {
        [SerializeField] private GetterParameters[] _getters;
        public UnityEvent onFull; 
        private void Start()
        {
            if (_getters == null)
            {
                return;
            }
            foreach (var getter in _getters)
            {
                getter.getter.SetCount(getter.targetCount);
                getter.getter.onCountChanget.AddListener(OnCountChanget);
            }

        }

        private void OnDestroy()
        {
            foreach (var getter in _getters)
            {
                getter.getter.onCountChanget.RemoveListener(OnCountChanget);
            }
        }
        

        private void OnCountChanget(Getter getter)
        {
            for (int idx = 0; idx < _getters.Length; idx++)
            {
                ref var item = ref _getters[idx];

                if (item.getter != getter)
                {
                    continue;
                }

                 item.count++;                                                                                            
            }

             bool full = true;

            foreach (GetterParameters item in _getters)
            {
                if (item.count < item.targetCount)
                {
                    full = false;

                    break;
                }
            }

            if (full)
            {
                onFull.Invoke();
            }
        }
    }

        [System.Serializable]
        public struct GetterParameters
        {
            public Getter getter;
            public int targetCount;
            [HideInInspector]public int count;
            
        }

}

