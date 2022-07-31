using System;
using UnityEngine;
using SortItems;

namespace SortItems
{
    public class LevelChanger : MonoBehaviour
    {
        [SerializeField] private GameObject currentLevel;
        [SerializeField] private GameObject nextlevel;

        public void NextLevels()
        {
            currentLevel.SetActive(false);
            ItemsSpawn.DestroyItems();
            Instantiate(nextlevel);
            Destroy(currentLevel);
        }
    }
}
