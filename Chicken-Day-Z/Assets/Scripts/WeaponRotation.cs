using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    [SerializeField] private float _offset;

    private SpriteRenderer _spriteRenderer;

    private Camera _camera;

    private Vector3 _mouseLocation;

    private Vector3 _direction;

    private float _angle;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        SetPosition();

        SetRotation();

        FlipSprite();

        //transform.Translate(direction, Space.World);
    }

    private void SetPosition()     
    {
        _mouseLocation = _camera.ScreenToWorldPoint(Input.mousePosition);

        _mouseLocation.z = 0f;

        _direction = _mouseLocation - transform.parent.localPosition;

        _direction = _direction.normalized * _offset;

        transform.position = _direction + transform.parent.localPosition;
    }

    void SetRotation() 
    {
        _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(-_angle, -Vector3.forward);    
    }

    void FlipSprite() 
    {
        if (transform.rotation.eulerAngles.z >= 90f && transform.rotation.eulerAngles.z <= 270f) 
        {            
            _spriteRenderer.flipY = true;
        }
        else 
        {
            _spriteRenderer.flipY = false;
        }
    }
}
