﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chickens 
{
    public class GamePlayManager : MonoBehaviour
    {
        Model model;

        [SerializeField] GameObject _chicken;
        [SerializeField] GameObject _hazard;

        List<GameObject> chickenPooledObjects = new List<GameObject>();
        List<GameObject> hazardPooledObjects = new List<GameObject>();

        /// <summary>
        /// x value of chicken's position
        /// </summary>    
        float widthPosition = 8.5f;

        /// <summary>
        /// y value of chicken's position
        /// </summary>
        float heightPosition = 5.5f;

        // Start is called before the first frame update
        void Start()
        {
            //print(model._maxInterval);
            AddObject(chickenPooledObjects, _chicken);
            AddObject(hazardPooledObjects, _hazard);
            StartCoroutine(Play());
        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// Starts dropping Chickens
        /// </summary>
        /// <returns></returns>
        IEnumerator Play()
        {
            while (true)
            {
                int objectsToDropAtTheSameTime = Random.Range(1,4);

                for (int x = 0; x < objectsToDropAtTheSameTime; x++)
                {
                    GameObject obj = null;
                    Vector2 pos = pos = new Vector2(Random.Range(-widthPosition, widthPosition), heightPosition);

                    if (Random.value < 0.2f)
                    {
                        obj = ObjectPooling(hazardPooledObjects);
                        //int interval = Random.Range(model._minInterval, model._maxInterval + 1);

                        if (obj == null)
                            obj = AddObject(hazardPooledObjects, _hazard);
                    }
                    else
                    {
                        obj = ObjectPooling(chickenPooledObjects);
                        //int interval = Random.Range(model._minInterval, model._maxInterval + 1);

                        if (obj == null)
                            obj = AddObject(chickenPooledObjects, _chicken);
                    }

                    obj.transform.position = pos;
                    obj.SetActive(true);
                }
                
                //print(interval);
                yield return new WaitForSeconds(2f);
            }
        }


        /// <summary>
        /// Adding of chicken/hazard in hierarchy and pooledObjects
        /// </summary>
        GameObject AddObject(List<GameObject> objectsToPool, GameObject toInstantiate)
        {
            GameObject obj = Instantiate(toInstantiate);
            obj.SetActive(false);
            objectsToPool.Add(obj);
            return obj;
        }

        /// <summary>
        /// Reusing chickens/hazard that is disabled
        /// </summary>
        GameObject ObjectPooling(List<GameObject> objectsToPool)
        {
            foreach (GameObject obj in objectsToPool)
            {
                if (!obj.activeInHierarchy)
                    return obj;
            }

            return null;
        }
    }
}

