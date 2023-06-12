namespace Common
{
    public interface IHave<out TTool>
    {
        TTool Tool { get; }
    }
}
