using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GridBrushBase;

public class PlayerRotation : MonoBehaviour
{
    public bool CanRotate = true;
    private float _elapsedTime;
    private int _angleLimit = 45;
    private int _turnDirection = 1;
    private float _angle = 0;

    [SerializeField]
    private float _duration = 10f;
    private void Update()
    {
        if (CanRotate)
        {
            //transform.rotation = Quaternion.Euler(new Vector3(0f, _angle, 0f));
            _elapsedTime += Time.deltaTime * _duration;
            //float percentageComplete = _elapsedTime / _duration;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, _angleLimit * _turnDirection,0), _elapsedTime);

            if (Quaternion.Angle(transform.rotation, Quaternion.Euler(0, _angleLimit * _turnDirection, 0)) <= 0.01f)
            {
                _turnDirection = -_turnDirection;
                _elapsedTime = 0;
            }

           /* _angle = Mathf.Lerp(_angle, _angleLimit * _turnDirection, percentageComplete);
           
            if(_angleLimit - Mathf.Abs(_angle) <= 0.1f)
            {
                _turnDirection = -_turnDirection;
                _elapsedTime = 0;
            }*/
           
        }
    }
}
