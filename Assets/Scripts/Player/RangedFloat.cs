[System.Serializable]
public class RangedFloat
{
    public float Max, Min;

    public bool Contains(float num) => !(num < Min || Max < num);
}
