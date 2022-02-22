using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public Tools tools;
    public GameObject blanket;
    public float range = 20f;
    public Camera cam;
    private Vector3 worldMousePos;
    private Vector2 direction;
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
    // [SerializeField] private int percision = 40;
    float moveTime = 0f;

    // [Header("Rope Animation Settings:")]
    // public AnimationCurve ropeAnimationCurve;
    // [Range(0.01f, 4)] [SerializeField] private float StartWaveSize = 2;
    // float waveSize = 0;

    // [Header("Rope Progression:")]
    // public AnimationCurve ropeProgressionCurve;
    // [SerializeField] [Range(1, 50)] private float ropeProgressionSpeed = 1;

    





    void Awake()
    {
        m_springJoint2D.enabled = false;
        isShooting = false;
    }


    void Update()
    {
        Vector3 worldMousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (Vector2)((worldMousePos - blanket.transform.position));
        hit = Physics2D.Raycast(blanket.transform.position, Vector2.down, range, objectsToCollide);
        
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
        
        moveTime += Time.deltaTime;

        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            UnGrapple();
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
                    Dj.enabled = true;
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
        grappleGround = true;
        grappleMaterial = false;
        Lr.SetPosition(1, grapplePoint);
        yield return new WaitForSeconds(shootingCooldown);
        isShooting = false;
    }

    private void UnGrapple()
    {
        m_springJoint2D.enabled = false;
        Lr.enabled = false;
        grappleGround = false;
        grappleMaterial = false;
        if(Dj != null)
        {
            Dj.enabled = false;
        }
    }
}


