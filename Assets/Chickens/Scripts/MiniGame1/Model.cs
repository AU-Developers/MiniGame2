using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Chickens
{
    [CreateAssetMenu(menuName = "Inputs", fileName = "New Inputs.asset")]
    public class Model : ScriptableObject
    {
        public int _points;

        [Tooltip("Time limit of the game")]
        public float _timer = 120f;
        [Tooltip("Timer for every interval")]
        public float _timePerInterval;
        [Tooltip("Mimimum # of object in a row")]
        public int _minObj = 1;
        [Tooltip("Maximum # of object in a row")]
        public int _maxObj = 3;
        [Tooltip("Minimum # of spacing per x number of seconds")]
        public int _minInterval = 1;
        [Tooltip("Minimum # of spacing per x number of seconds")]
        public int _maxInterval = 2;

    }
}
