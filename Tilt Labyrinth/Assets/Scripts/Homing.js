#pragma strict
 
var missileVelocity : float = 100;
var turn : float = 20;
var homingMissile : Rigidbody2D;
var fuseDelay : float;
var delay : float;
//var missileMod : GameObject;
//var SmokePrefab : ParticleSystem;
//var missileClip : AudioClip;
 
private var target : Transform;
 
function Start () {
 
    Fire();
    transform.rotation = new Quaternion.Euler(0,0,90f);
    //transform.rotation = transform.rotation * player.transform.rotation;
    SelfDestruct();
 
}
 
function FixedUpdate ()
 
{
    if(target == null || homingMissile == null)
        return;
 
    homingMissile.velocity = transform.right * missileVelocity;
 
    //var targetRotation = Quaternion.LookRotation(target.position - transform.position);
 
    //homingMissile.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, turn));
 
    var vectorToTarget : Vector3  = target.position - transform.position;
    var angle : float  = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
    var q : Quaternion  = Quaternion.AngleAxis(angle, Vector3.forward);
    transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * turn);
}
 
function Fire ()
 
{
    yield WaitForSeconds (fuseDelay);
    //AudioSource.PlayClipAtPoint(missileClip, transform.position);
 
    var distance = Mathf.Infinity;
 
    for (var go : GameObject in GameObject.FindGameObjectsWithTag("Enemy"))
    {
            var diff = (go.transform.position - transform.position).sqrMagnitude;
 
            if(diff < distance)
    {
                distance = diff;
                target = go.transform;
    }
 
}
 
}
 
function OnTriggerEnter2D (other : Collider2D)
    {
 
        if(other .gameObject.tag == "Enemy")
        {
            //SmokePrefab.emissionRate = 0.0f;
            //Destroy(missileMod.gameObject);
            //yield WaitForSeconds(5);
            Destroy(gameObject);
            Destroy(other.gameObject);

        }
 
    }

    function SelfDestruct() {
        yield WaitForSeconds(delay);
        Destroy(gameObject);
    }