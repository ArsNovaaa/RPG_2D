using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] private int possibleItemDrop;
    [SerializeField] private ItemData[] possibleDrop;
    private List<ItemData> dropList = new List<ItemData>();

    [SerializeField] private GameObject dropPrefab;

    public virtual void GenerateDrop()
    {
        System.Array.Sort(possibleDrop, (x, y) => x.dropChance.CompareTo(y.dropChance));
        int a = 0;
        for (int i = 0; a < possibleItemDrop; i++)
        {
            if (i == possibleDrop.Length)
                i = 0;
            if (Random.Range(0, 100) <= possibleDrop[i].dropChance)
            {
                dropList.Add(possibleDrop[i]);
                //a++;
            }
            a++;
        }


        for (; dropList.Count != 0;) //(int i = 0; i < possibleItemDrop; i++) //
        {
            Debug.Log(dropList.Count);
            ItemData randomItem = dropList[Random.Range(0, dropList.Count - 1)];

            dropList.Remove(randomItem);
            DropItem(randomItem);
        }
    }



    protected void DropItem(ItemData _itemData)
    {
        GameObject newDrop = Instantiate(dropPrefab, transform.position, Quaternion.identity);

        Vector2 randomVelocity = new Vector2(Random.Range(-4, 4), Random.Range(12, 15));

        newDrop.GetComponent<ItemObject>().SetupItem(_itemData, randomVelocity);
    }
}
