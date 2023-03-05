using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItems : MonoBehaviour
{
    public enum CollectableType
    {
        Coin,
        Gem
    }

    public class Collectable : MonoBehaviour
    {
        public CollectableType type;

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                switch (type)
                {
                    case CollectableType.Coin:
                        Debug.Log("Score: 1");
                        break;
                    case CollectableType.Gem:
                        Debug.Log("Gems: 1");
                        break;
                }

                Destroy(gameObject);
            }
        }
    }
}
