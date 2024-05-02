using UnityEngine;
using System.Collections.Generic;
using EndlessRunner.Player;
using EndlessRunner.Shared;
using EndlessRunner.Targets;

namespace EndlessRunner.Level
{
    public class TileSpawnManager : MonoBehaviour
    {
        [SerializeField] private int noOfTilesOnScreen;
        [SerializeField] private TileManager[] tilePrefabs;
        [SerializeField] private BaseTarget[] spawnItems;
        private float currentZPos = 0;
        private Queue<TileManager> tileQueue = new();
        private int currentIndex = 1;
        private Transform player;
        private bool canSpawnItems = false;

        public BaseTarget[] SpawnItems => spawnItems;

        private void Start()
        {
            var tilePrefabIndex = 0;
            ShuffleArray(tilePrefabs);
            for(int i=0;i<noOfTilesOnScreen;i++)
            {
                SpawnRandomTile(tilePrefabIndex);
                tilePrefabIndex++;
                if(tilePrefabIndex >= tilePrefabs.Length)
                {
                    tilePrefabIndex = 0;
                }
            }
            player = PlayerService.Instance.PlayerTransform;
        }

        private void Update()
        {
            CheckToAddNewTile();
        }
        private void SpawnRandomTile(int index)
        {
            if(tilePrefabs == null || tilePrefabs.Length ==0 )
            {
                Debug.LogError("Tile prefabs not found");
                return;
            }           
            var tilePos = new Vector3(0, 0, currentZPos);
            var tileGO = Instantiate(tilePrefabs[index], tilePos, Quaternion.identity);
            tileGO.transform.SetParent(this.transform);
            var tileManager = tileGO.GetComponent<TileManager>();
            tileQueue.Enqueue(tileManager);
            currentZPos += GameConstants.TILE_LENGTH; 
            if(canSpawnItems)
            {
                tileManager.SpawnItems();
            }
            else
            {
                canSpawnItems = true;
            }
        }

        private void CheckToAddNewTile()
        {
            if (player == null)
            {
                player = PlayerService.Instance.PlayerTransform;
            }
            if (player.position.z > currentIndex * GameConstants.TILE_LENGTH)
            {
                AddTileToFront();
                currentIndex++;
            }
        }

        private void AddTileToFront()
        {
            var tileToAdd = tileQueue.Dequeue();
            tileToAdd.SpawnItems();
            tileToAdd.transform.position = new Vector3(0, 0, currentZPos);
            tileQueue.Enqueue(tileToAdd);
            currentZPos+= GameConstants.TILE_LENGTH;
        }

        public static void ShuffleArray<T>(T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = Random.Range(0, n);
                T temp = array[k];
                array[k] = array[n];
                array[n] = temp;
            }
        }
    }
}
