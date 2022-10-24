using UnityEngine;
using UnityEngine.Events;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private Vector2Variable aimVector;

    [SerializeField]
    private UnityEvent onPositionChanged;
    //[SerializeField]
    //private Listener<bool> validPositionListener; 

    private Weapon currentWeapon;

    private Vector3 pos, rot = Vector3.zero;
    private Vector3 prevPos, prevRot = Vector3.zero;

    private void OnEnable()
    {
        aimVector.OnValueChanged += BeginAimHandler;
        WeaponManager.OnWeaponChanged += WeaponChangeHandler;
    }

    private void OnDisable()
    {
        EndAimHandler();
        WeaponManager.OnWeaponChanged -= WeaponChangeHandler;
    }

    private void BeginAimHandler(Vector2 aim)
    {
        if (currentWeapon == null) return;

        aimVector.OnValueChanged -= BeginAimHandler;

        aimVector.OnValueChanged += AimHandler;

        AimHandler(aim);
    }
    private void AimHandler(Vector2 aim)
    {
        if (aim == Vector2.zero) return;

        aim.Normalize();
        SetWeaponPosition(aim);
    }
    private void EndAimHandler()
    {
        if (currentWeapon == null)
        {
            // This was never called if currentWeapon was always null
            aimVector.OnValueChanged -= BeginAimHandler;
            return;
        }

        aimVector.OnValueChanged -= AimHandler;
    }

    private void WeaponChangeHandler(Weapon weapon)
    {
        currentWeapon = weapon;
        SetWeaponPosition(aimVector.Value);
    }

    private void SetWeaponPosition(Vector2 aim)
    {
        pos.Set(
            currentWeapon.Pivot.Value.x + aim.x * currentWeapon.Radius.Value,
            currentWeapon.Pivot.Value.y + aim.y * currentWeapon.Radius.Value,
            currentWeapon.Pivot.Value.z);
        rot.z = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg;

        transform.position = pos;
        transform.eulerAngles = rot;

        onPositionChanged.Invoke();
    }
}
