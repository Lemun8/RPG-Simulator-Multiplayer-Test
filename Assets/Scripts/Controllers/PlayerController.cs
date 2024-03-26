using UnityEngine.EventSystems;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public Interactable focus;
    public LayerMask movementMask;
    Camera cam;
    PlayerMotor motor;
    PhotonView view;

    private bool isMobile;

    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
        view = GetComponent<PhotonView>();

        // Check if the current platform is mobile
        isMobile = Application.platform == RuntimePlatform.Android;
    }

    void Update()
    {
        if (view.IsMine)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (isMobile)
            {
                HandleMobileInput();
            }
            else
            {
                HandlePCInput();
            }
        }
    }

    void HandleMobileInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = cam.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    if (interactable != null)
                    {
                        SetFocus(interactable);
                    }
                    else
                    {
                        if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                        {
                            if (Physics.Raycast(ray, out hit, 100, movementMask))
                            {
                                motor.MoveToPoint(hit.point);
                                RemoveFocus();
                            }
                        }
                    }
                }
            }
        }
    }

    void HandlePCInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);
                RemoveFocus();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();

            focus = newFocus;
            motor.FollowTarget(newFocus);
        }

        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
        motor.StopFollowingTarget();
    }
}