using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string FRONT_ARM_TAG = "Front_Arm";
    private const string BACK_ARM_TAG = "Back_Arm";

    [field: SerializeField] public ArmHandler FrontArmController { get; private set; }
    [field: SerializeField] public ArmHandler BackArmController { get; private set; }

    [field: SerializeField] public WeaponHolderHandler FrontWeaponHolder { get; private set; }
    [field: SerializeField] public WeaponHolderHandler BackWeaponHolder { get; private set; }

    private void Awake()
    {
        FrontArmController ??= GameObject.FindGameObjectWithTag(FRONT_ARM_TAG).GetComponent<ArmHandler>();
        FrontWeaponHolder ??= FrontArmController.GetComponentInChildren(typeof(WeaponHolderHandler)) as WeaponHolderHandler;

        BackArmController ??= GameObject.FindGameObjectWithTag(BACK_ARM_TAG).GetComponent<ArmHandler>();
        BackWeaponHolder ??= BackArmController.GetComponentInChildren(typeof(WeaponHolderHandler)) as WeaponHolderHandler;
    }

}