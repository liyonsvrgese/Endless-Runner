using UnityEngine;
using EndlessRunner.Targets;
using System.Collections.Generic;

namespace EndlessRunner.Level
{
    class TileManager : MonoBehaviour
    {       
        [SerializeField] private Transform[] SpawnPoints;

        private BaseTarget[] targets;
        private List<BaseTarget> activeItemsList;
        private void Start()
        {
            activeItemsList = new();
            SpawnItems();
        }

        public void SpawnItems()
        {
            ClearActiveList();
            var manager = GetComponentInParent<TileSpawnManager>();
            if (manager != null)
            {
                targets = manager.SpawnItems;
            }
            else
            {
                Debug.Log("TileManager-Start- Tile Spawn manager not found ");
            }
            var noOfItems = Random.Range((int)SpawnPoints.Length / 3, SpawnPoints.Length);
            for (int i = 0; i < noOfItems; i++)
            {
                SpawnRandomItemOnTile(i);
            }
        }

        private void ClearActiveList()
        {
            if(activeItemsList.Count == 0)
            {
                return;
            }
            foreach(var item in activeItemsList)
            {
                if (item != null)
                {
                    Destroy(item.gameObject);
                }
            }
            activeItemsList.Clear();
        }
        private void SpawnRandomItemOnTile(int pointIndex)
        {
            var index = Random.Range(0, targets.Length);
            var item = Instantiate(targets[index],transform);
            activeItemsList.Add(item);
            item.transform.position = SpawnPoints[pointIndex].position;
        }
    }
}
