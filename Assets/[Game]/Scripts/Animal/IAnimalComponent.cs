public interface IAnimalComponent
{
    public bool IsActive { get; }

    public void Init(Animal animal);
    public void Activate();
    public void Deactivate();
}