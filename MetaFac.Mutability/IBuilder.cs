namespace MetaFac.Mutability
{
    public interface IBuilder<TImmutable, TBuilder>
        where TBuilder : IBuild<TImmutable>
    {
        TBuilder ToBuilder();
    }
}
