namespace KovanCaseStudy.SharedKernel.SeedWork;

public interface IEntity<out TId>
{
    TId Id { get; }
}
public interface IEntity
{ }