using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectInitializer : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameObjectsToBeInitializable;
    
    public GameObject instantiateGameObjectMainThread(ObjectToSpawn objectToSpawn)
    {
        var gameObject = Instantiate(getObjectToNumber(1), objectToSpawn.Position, objectToSpawn.Quaternion);
        if (objectToSpawn.TypeObject == 1)
        {
            //_playerGameObjectList.Add(objectToSpawn.Endpoint, gameObject);
        }

        return gameObject;
    }
    
       public GameObject getObjectToNumber(int number)
        {
            if (number == 1)
            {

                return gameObjectsToBeInitializable[0];
            }
            
            return gameObjectsToBeInitializable[0];
        }
        
}
