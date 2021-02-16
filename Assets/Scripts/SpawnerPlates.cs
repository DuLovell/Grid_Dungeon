using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlates : MonoBehaviour
{
    #region Fields

    [SerializeField]
    GameObject prefabPlate;

    Vector2 spawnPosition = new Vector2(-5.76f, 2.56f);

    private float halfWidthCollider;
    private float halfHeightCollider;

    #endregion

    #region Methods

    private void Awake()
    {
        halfWidthCollider = prefabPlate.GetComponent<BoxCollider2D>().size.x;
        halfHeightCollider = prefabPlate.GetComponent<BoxCollider2D>().size.y;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Instantiate(prefabPlate, spawnPosition, Quaternion.identity);
                spawnPosition.x += halfWidthCollider;
            }
            spawnPosition.x = -5.76f;
            spawnPosition.y -= halfHeightCollider;
        }
        spawnPosition = new Vector2(-5.76f, 2.56f);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    #endregion

}
