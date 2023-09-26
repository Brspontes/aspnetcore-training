namespace DevFreela.Application.Queries.Outputs
{
    public class SkillDto
    {
        public SkillDto(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; private set; }
        public string Description { get; private set; }
    }
}
