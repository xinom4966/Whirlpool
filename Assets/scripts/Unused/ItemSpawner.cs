using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.UI;

public class ItemSpawner : MonoBehaviour
{
    [System.Serializable]
    public enum lootType
    {
        weapons = 0,
        armors = 1,
        implants = 2
    }
    public Item item;

    [System.Serializable]
    public struct LootTable
    {
        public Rarity rarity;
        public Item item;
        public float dropChance;
    }

    public List<LootTable> items = new List<LootTable>();
    private Dictionary<int, Rarity> rarityTable = new Dictionary<int, Rarity>()
    {
        {1, Rarity.Commun},
        {2, Rarity.Rare},
        {3, Rarity.Epique}
    };

    public bool isInfinit;
    [SerializeField] private float respawnH;


    [SerializeField] private lootType type;
    private PlayerMovement player;
    private float timer;

    Vector3 spawnPos;
    Quaternion spawnRot;
    private void Start()
    {
        timer = Random.Range(0f, 12f);

        spawnPos = transform.position;
        spawnRot = transform.rotation;

        item = CreateItem();
        player = PlayerMovement.instance;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 12f)
        {
            timer = 0;
        }
    }

    public void Respawn()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = spawnPos + new Vector3(0f, respawnH, 0f);
        transform.rotation = spawnRot;
        item = CreateItem();
    }

    public Item CreateItem()
    {
        float randomValue = Random.Range(0f, 100f);
        float pourcentPasse = 0;
        if (type == lootType.weapons)
        {
            foreach (LootTable item in items)
            {
                if (randomValue >= pourcentPasse && randomValue < (pourcentPasse + item.dropChance))
                {
                    return item.item;
                }
                pourcentPasse += item.dropChance;
            }
            return null;
        }
        else
        {
            int rarity = 1;
            if (randomValue <= 85f && randomValue >= 55f)
            {
                rarity = 2;
            }
            else if (randomValue <= 100f && randomValue >= 85f)
            {
                rarity = 3;
            }
            List<LootTable> droppableItems = new List<LootTable>();
            foreach (LootTable item in items)
            {
                if (item.item.rarity == rarityTable[rarity])
                {
                    droppableItems.Add(item);
                }
            }
            randomValue = Random.Range(0f, 100f);
            pourcentPasse = 0;
            float lootchance = (1f / droppableItems.Count) * 100;
            for (int i = 0; i < droppableItems.Count; i++)
            {
                if (randomValue >= pourcentPasse && randomValue < (pourcentPasse + lootchance))
                {
                    return droppableItems[i].item;
                }
                pourcentPasse += lootchance;
            }

        }

        return null;
    }
}

