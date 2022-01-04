using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public Weapons weapons;
    private bool hookActivated;
    public GameObject blanket;
    public float range = 20f;
    public Camera cam;
    private Vector2 lookDirection;
    public LayerMask objectsToCollide;
    public LayerMask Material;
    public LayerMask Ground;
    public SpringJoint2D  m_springJoint2D;
    [HideInInspector] public Vector2 grapplePoint;
    [HideInInspector] public Vector2 grappleDistanceVector;
    public LineRenderer Lr;
    private bool grappleGround;
    private bool grappleMaterial;
    private DistanceJoint2D Dj;
    private RaycastHit2D hit;
    private GameObject CurrentMaterial;
    private bool isShooting;
    public float shootingCooldown;



    void Awake()
    {
        m_springJoint2D.enabled = false;
        isShooting = false;
    }


    void Update()
    {

        lookDirection = cam.ScreenToWorldPoint(Input.mousePosition) - blanket.transform.position;
        hit = Physics2D.Raycast(blanket.transform.position, lookDirection , range, objectsToCollide);

        if(weapons.activatedHook == true)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                ShotActivated();
            }

            if(Input.GetKey(KeyCode.Mouse0))
            {
                if(grappleGround)
                {
                    Lr.SetPosition(0, blanket.transform.position);
                }
                if(grappleMaterial)
                {
                    Lr.SetPosition(0, blanket.transform.position);
                    Lr.SetPosition(1, CurrentMaterial.transform.position);
                    Dj.connectedAnchor = blanket.transform.position;
                    Dj.enabled = true;
                }
            }
        }

        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            m_springJoint2D.enabled = false;
            Lr.enabled = false;
            grappleGround = false;
            grappleMaterial = false;

            if(Dj != null)
            {
                Dj.enabled = false;
                Lr.enabled = false;
            }
        }
        
    }

    private void ShotActivated()
    {       
        if(hit == true)
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Ground") && isShooting == false) 
            {
               StartCoroutine(GrapplingShot());
            }

            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Material")) 
            { 
                grappleGround = false;
                grappleMaterial = true;
                if(hit.transform.gameObject != null)
                {
                    Lr.enabled = true;
                    Dj = hit.transform.gameObject.GetComponent<DistanceJoint2D>();
                    CurrentMaterial = hit.transform.gameObject;
                }
            }
        }
    }

    private IEnumerator GrapplingShot()
    {
        isShooting = true;
        grapplePoint = hit.point;
        m_springJoint2D.connectedAnchor = grapplePoint;
        m_springJoint2D.enabled = true;
        grappleDistanceVector = grapplePoint - (Vector2)blanket.transform.position;
        Lr.enabled = true;
        Lr.SetPosition(1, grapplePoint);
        grappleGround = true;
        grappleMaterial = false;
        yield return new WaitForSeconds(shootingCooldown);
        isShooting = false;
    }
}


