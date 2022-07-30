using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SortItems
{
    public class LevelChanger : MonoBehaviour
    {
        [SerializeField] private GameObject currentLevel;
        [SerializeField] private GameObject nextlevel;

        public void NextLevels()
        {
            currentLevel.SetActive(false);
            Instantiate(nextlevel);
            Destroy(currentLevel);
        }
    }
}
