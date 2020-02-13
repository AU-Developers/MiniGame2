using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chickens 
{
    public class GamePlayManager : MonoBehaviour
    {
        [SerializeField] Model _model;

        public Model _Model { get { return _model; } }

        [SerializeField] GameObject _chicken;
        [SerializeField] GameObject _hazard;

        List<GameObject> chickenPooledObjects = new List<GameObject>();
        List<GameObject> hazardPooledObjects = new List<GameObject>();

        private static GamePlayManager _instance;
        public static GamePlayManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<GamePlayManager>();

                return _instance;
            }
        }

        /// <summary>
        /// if true then start the game
        /// </summary>
        public bool _gameStart;

        /// <summary>
        /// x value of chicken's position
        /// </summary>    
        float widthPosition = 7f;

        /// <summary>
        /// y value of chicken's position
        /// </summary>
        float heightPosition = 5.5f;

        // Start is called before the first frame update
        void Start()
        {
            ResetValue();
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
            yield return new WaitUntil( ()=> _gameStart);

            while (_gameStart)
            {
                int objectsToDropAtTheSameTime = Random.Range(_model._minObj, _model._maxObj);
                
                for (int x = 0; x < objectsToDropAtTheSameTime; x++)
                {
                    GameObject obj = null;
                    Vector2 pos = pos = new Vector2(Random.Range(-widthPosition, widthPosition), heightPosition);
                    int interval = Random.Range(_model._minInterval, _model._maxInterval + 1);

                    if (Random.value < 0.2f)
                    {
                        obj = ObjectPooling(hazardPooledObjects);

                        if (obj == null)
                            obj = AddObject(hazardPooledObjects, _hazard);
                    }
                    else
                    {
                        obj = ObjectPooling(chickenPooledObjects);

                        if (obj == null)
                            obj = AddObject(chickenPooledObjects, _chicken);
                    }

                    obj.transform.position = pos;
                    obj.SetActive(true);

                    yield return new WaitForSeconds(interval);
                }
            }
        }

        void ResetValue()
        {
            _model._timer = 120;
            _model._points = 0;
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

