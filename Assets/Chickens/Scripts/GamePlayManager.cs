using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chickens 
{
    public class GamePlayManager : MonoBehaviour
    {
        Model model;

        [SerializeField] GameObject _chicken;

        List<GameObject> pooledObjects = new List<GameObject>();

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
            DefaultChicken();
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
                GameObject chick = ChickenPooling();
                Vector2 pos = new Vector2(Random.Range(-widthPosition,widthPosition),heightPosition);
                //int interval = Random.Range(model._minInterval, model._maxInterval + 1);

                if (chick == null)
                    chick = AddChicken();
                chick.transform.position = pos;
                chick.SetActive(true);

                
                //print(interval);
                yield return new WaitForSeconds(2f);
            }
        }


        /// <summary>
        /// Adding of chicken in pool
        /// </summary>
        GameObject AddChicken()
        {
            GameObject obj = Instantiate(_chicken);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            return obj;
        }

        /// <summary>
        /// Reusing chickens that is disabled
        /// </summary>
        GameObject ChickenPooling()
        {
            foreach (GameObject chicken in pooledObjects)
            {
                if (!chicken.activeInHierarchy)
                    return chicken;
            }

            return null;
        }

        /// <summary>
        /// default value of chicken in hierarchy
        /// </summary>
        void DefaultChicken()
        {
            for (int x = 0; x < 5; x++)
            {
                GameObject obj = Instantiate(_chicken);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }
}

