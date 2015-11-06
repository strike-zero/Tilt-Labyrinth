#pragma strict
var missile : Rigidbody2D;
function Update () {
    if(Input.GetButtonDown("Fire1"))
    {
        Instantiate(missile, transform.position,transform.rotation);
    }

    if(Input.touchCount > 0)
    {
        var touch = Input.GetTouch(0);
        switch(touch.phase)
        {
            case TouchPhase.Began:
                Instantiate(missile, transform.position,transform.rotation);
                break;
            case TouchPhase.Moved:
                break;
            case TouchPhase.Ended:
                break;
        }
            
        
    }
}