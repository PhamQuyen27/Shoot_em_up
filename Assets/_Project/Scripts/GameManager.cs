using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Shmup
{
    public class GameManager :MonoBehaviour
    {
        
        [SerializeField] SceneReference mainMenuScene;
        [SerializeField] GameObject gameOverUi;
        public static GameManager Instance { get; private set; }
        public Player Player => player;
        public GameObject bossPrefab;
        private bool bossActivated = false;
        public GameObject bossObject;

        bool bossSpawned = false;
        Player player;
        Boss boss;
        int score;
        float restartTime = 3f;
        public bool IsGameOver()
        {
            return player.GetHealthNormalized() <= 0 || player.GetFuelNormalized() <= 0;
        }

        void Awake()
        {
            Instance = this;

            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

            //boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
        }
        void Update()
        {
            if (IsGameOver())
            {
                restartTime -= Time.deltaTime;
                if(gameOverUi.activeSelf == false)
                {
                    gameOverUi.SetActive(true);
                }

                if(restartTime <= 0)
                {
                    Loader.Load(mainMenuScene);
                }
            }

            if(score >= 300 && !bossSpawned)
            {
/*                SpawnBoss();
                bossSpawned = true;*/

                bossObject.SetActive(true); // Kích hoạt bossObject
                bossActivated = true;
            }
        }
        public void AddScore(int amount)
        {
            score += amount;
        }

        public int GetScore() { return score; }

        public void SpawnBoss()
        {
            Vector3 playerPosition = player.transform.position;
            Vector3 offset = new Vector3(0f, 2f, 0f); // Đây là ví dụ offset (x, y, z)

            // Tính toán vị trí để spawn boss liên quan đến player
            Vector3 spawnPosition = playerPosition + offset;
            Instantiate(bossPrefab, spawnPosition, Quaternion.identity);

        }

    }
}
