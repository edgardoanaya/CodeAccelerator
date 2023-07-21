namespace SoftwareOne.BaseLine.Core.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public int State { get; set; } = 1!;
    }
}