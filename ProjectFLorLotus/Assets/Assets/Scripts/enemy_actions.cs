using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemy_actions : MonoBehaviour
{

    public float _enemySpeed = 2.5f;
    private Vector2 _golemDirection;
    private Rigidbody2D _golemR2DB;
    public detection_controller _detectionArea;

    private Animator _enemyAnimator ;
    private SpriteRenderer _spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {

        _golemR2DB = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _enemyAnimator = GetComponent<Animator>(); 

        
    }

    // Update is called once per frame
    void Update()
    {
        _golemDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        
        if (_golemDirection.sqrMagnitude > 0)
        {

            _enemyAnimator.SetInteger("Movement", 1);

        }
        else
         {

            _enemyAnimator.SetInteger("Movement",0);

        }



    }


    private void FixedUpdate() {
        
        if(_detectionArea.detectedObjs.Count > 0)
        {
            _golemDirection = (_detectionArea.detectedObjs[0].transform.position - transform.position).normalized;

            _golemR2DB.MovePosition(_golemR2DB.position + _golemDirection * _enemySpeed * Time.fixedDeltaTime);

        }

        if (_golemDirection.x < 0){

            _spriteRenderer.flipX = false;
        }

        else if (_golemDirection.x > 0){

            _spriteRenderer.flipX = true;
        }
    }

}
