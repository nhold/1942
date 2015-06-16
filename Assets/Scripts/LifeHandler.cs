using UnityEngine;
using System.Collections;

public class LifeHandler : MonoBehaviour 
{
    [SerializeField]
    private GameObject LifePrefab;

    private PlayerController playerController;

    void Awake()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        playerController = playerObject.GetComponent<PlayerController>();
        playerController.OnLivesChanged += UpdateLives;
        UpdateLives(playerController.Lives);
    }

    void Start()
    {
        UpdateLives(playerController.Lives);
    }

    private void UpdateLives(uint newLives)
    {
        while(transform.childCount < newLives)
        {
            GameObject newLifePrefab = GameObject.Instantiate(LifePrefab);
            newLifePrefab.transform.SetParent(transform);
            newLifePrefab.transform.localScale = new Vector3(1, 1, 1);
        }

        int childCount = transform.childCount;
        while (childCount > newLives)
        {
            GameObject.Destroy(transform.GetChild(transform.childCount - 1).gameObject);
            childCount--;
        }
    }

}
