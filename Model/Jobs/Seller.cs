namespace PersonnelAccounting.Model.Jobs
{
    public class Seller : Job
    {
        public override string? Name { get => nameof(Seller); }
        public override decimal Salary { get => 200; }
    }
}
