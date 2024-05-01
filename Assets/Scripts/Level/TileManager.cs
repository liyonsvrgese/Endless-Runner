using UnityEngine;
using System.Collections.Generic;
using EndlessRunner.Player;
using EndlessRunner.Shared;

namespace EndlessRunner.Level
{
    public class TileManager : MonoBehaviour
    {
        [SerializeField] private int noOfTilesOnScreen;
        [SerializeField] private GameObject[] tilePrefabs;
        private float currentZPos = 0;
        private Queue<Transform> tileQueue = new();
        private int currentIndex = 1;
        private Transform player;

        private void Start()
        {
            var index = 0;
            ShuffleArray(tilePrefabs);
            for(int i=0;i<noOfTilesOnScreen;i++)
            {
                SpawnRandomTile(index);
                index++;
                if(index >= tilePrefabs.Length)
                {
                    index = 0;
                }
            }
            player = PlayerService.Instance.PlayerPos;
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
            tileQueue.Enqueue(tileGO.transform);

            currentZPos += GameConstants.TILE_LENGTH; 
        }

        private void CheckToAddNewTile()
        {
            if (player == null)
            {
                player = PlayerService.Instance.PlayerPos;
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
            tileToAdd.position = new Vector3(0, 0, currentZPos);
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
