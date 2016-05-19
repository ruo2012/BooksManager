namespace BM.DAL.Core.Specifications
{
    public class NotSpecification<T> : CompositeSpecification<T>
    {
        ISpecification<T> specification;

        public NotSpecification(ISpecification<T> spec)
        {
            this.specification = spec;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return !this.specification.IsSatisfiedBy(o);
        }
    }
}