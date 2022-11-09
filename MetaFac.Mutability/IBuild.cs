namespace MetaFac.Mutability
{
    public interface IBuild<TImmutable>
    {
        TImmutable Build();
    }
}
