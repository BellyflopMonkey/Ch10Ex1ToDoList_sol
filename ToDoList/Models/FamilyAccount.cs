namespace ToDoList.Models
{
    public class FamilyAccount
    {
        public int Id { get; set; }
        public string FamilyName { get; set; }
        public string Password { get; set; }
        public List<FamilyMember> Members { get; set; }
    }
}
