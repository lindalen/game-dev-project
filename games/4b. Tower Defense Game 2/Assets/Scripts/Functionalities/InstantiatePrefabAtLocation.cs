using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiatePrefabAtLocation : MonoBehaviour
{
    [SerializeField] private GameObject prefabToPlace;
    [SerializeField] private TowerConfig config;
    private GameObject button;

    private PrefabSpriteAttacher attacher;

    private void Awake()
    {
        button = GameObject.Find("DummyTowerButton");
        attacher = button.GetComponent<PrefabSpriteAttacher>();
    }
    public void PlaceObjectAtCurrentLocation()
    {
        Instantiate(prefabToPlace, transform.position, Quaternion.identity);
        ResourceController.Instance.SpendMoney(config.price);
        attacher.DisableAttachment();

    }
}
