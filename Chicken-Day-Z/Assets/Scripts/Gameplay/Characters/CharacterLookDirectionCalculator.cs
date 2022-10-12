using System;
using UnityEngine;

using ChickenDayZ.General;

public enum CharacterLookDirection { BACK_RIGHT, BACK, BACK_LEFT, FRONT_LEFT, FRONT, FRONT_RIGHT}

public class CharacterLookDirectionCalculator : MonoBehaviour
{
    private CharacterLookDirection _characterCurrentLookDirection;

    private CharacterLookDirection _characterOldLookDirection;

    public event Action OnCharacterLookDirectionChanged;

    private Vector3 _targetPosition;

    private float _angle;

    private Camera _camera;

    public CharacterLookDirection CharacterLookDirection 
    {
        get 
        {
            return _characterCurrentLookDirection;
        }
    }

    public Vector3 TargetPosition 
    {
        set 
        {
            _targetPosition = value;
        }
    }    

    void Start()
    {
        _camera = Camera.main;        

        CalculateCharacterLookDirection();

        _characterOldLookDirection = _characterCurrentLookDirection;

        OnCharacterLookDirectionChanged?.Invoke();
    }

    private void Update()
    {
        CalculateCharacterLookDirection();

        CharacterDirectionChanged();
    }

    public void CalculateCharacterLookDirection()
    {
        _targetPosition = _camera.ScreenToWorldPoint(Input.mousePosition);

        _angle = MathFunctions.AngleBetweenTwoPositions(gameObject.transform.position, _targetPosition);

        if (_angle > 0 && _angle < 60)
        {
            _characterCurrentLookDirection = CharacterLookDirection.BACK_RIGHT;
        }
        else if (_angle > 61 && _angle < 120)
        {
            _characterCurrentLookDirection = CharacterLookDirection.BACK;
        }
        else if (_angle > 121 && _angle < 180)
        {
            _characterCurrentLookDirection = CharacterLookDirection.BACK_LEFT;
        }
        else if (_angle > -180 && _angle < -120)
        {
            _characterCurrentLookDirection = CharacterLookDirection.FRONT_LEFT;
        }
        else if (_angle > -119 && _angle < -61)
        {
            _characterCurrentLookDirection = CharacterLookDirection.FRONT;
        }
        else 
        {
            _characterCurrentLookDirection = CharacterLookDirection.FRONT_RIGHT;
        }
    }

    public void CharacterDirectionChanged() 
    {
        if (_characterOldLookDirection != _characterCurrentLookDirection) 
        {
            OnCharacterLookDirectionChanged?.Invoke();

            _characterOldLookDirection = _characterCurrentLookDirection;
        }        
    }
}
