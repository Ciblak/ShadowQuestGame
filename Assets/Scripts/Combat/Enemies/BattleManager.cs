using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    //private Vector3 spawn = new Vector3(5.03999996f,0.289999992f,0f); // set in prefab now
    void Start()
    {
        int room=GameManager.Instance.currentRoom;
        if(room>5) SpawnRandomEnemy();
        else 
        {
            foreach (GameObject enemyPrefab in enemyPrefabs)
            {
                Enemy enemyScript = enemyPrefab.GetComponent<Enemy>();

                if (enemyScript != null && enemyScript.enemyIndex == room) 
                {
                    Instantiate(enemyPrefab);
                    return;
                }
            }
        }
    }

    void SpawnRandomEnemy()
    {
        //Transform enemySpawnPoint=spawn;
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        if(GameManager.Instance.currentRoom % 5 == 0) randomIndex=4;
        Instantiate(enemyPrefabs[randomIndex]);
    }
}