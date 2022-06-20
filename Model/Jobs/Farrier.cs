namespace PersonnelAccounting.Model.Jobs
{
    public class Farrier : Job
    {
        public override string? Name { get => nameof(Farrier); }
        public override decimal Salary { get => 100; }
    }
}
