namespace PersonnelAccounting.Model.Jobs
{
    public class Barista : Job
    {
        public override string? Name { get => nameof(Barista); }
        public override decimal Salary { get => 300; }
    }
}
