using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Chickens
{
    public class Model
    {
        public int _points;

        //[Tooltip("Time limit of the game")]
        public float _timer = 120f;
        //[Tooltip("Timer for every interval")]
        public float _timePerInterval;
        //[Tooltip("Mimimum # of object in a row")]
        public int _minObj = 1;
        //[Tooltip("Maximum # of object in a row")]
        public int _maxObj = 3;
        //[Tooltip("Minimum # of spacing per x number of seconds")]
        public int _minInterval = 1;
        //[Tooltip("Minimum # of spacing per x number of seconds")]
        public int _maxInterval = 2;



        /*public int Points
        {
            get { return _points; }
            set { _points = value; }
        }

        public void RandomFallingObj()
        {
            int _randomNumInRow = Random.Range(_minObj, _maxObj + 1); //the random amount of objects in a row
            int _randomInterval = Random.Range(_minInterval, _maxInterval + 1); //the random amount of intervals per x amount of timne    
        }
        /*private void Update()
        {
            _timer -= Time.deltaTime;
            _timePerInterval -= Time.deltaTime;
        }*/
        /*public void pointsDisplay()
        {
            _totalPoints.GetComponent<Text>().text = "Points: " + _points;
        }*/

    }
}
