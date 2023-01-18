namespace CleanArchitectureAccountingApp.Domain.Abstractions;

public abstract class Entity
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? RemovedDate { get; set; }
}