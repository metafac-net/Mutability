namespace MetaFac.Mutability
{
    public interface ICopyFrom<T>
    {
        void CopyFrom(T source);
    }

}
