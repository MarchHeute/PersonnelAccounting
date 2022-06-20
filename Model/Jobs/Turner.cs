namespace PersonnelAccounting.Model.Jobs
{
    public class Turner : Job
    {
        public override string? Name { get => nameof(Turner); }
        public override decimal Salary { get => 150; }
    }
}
