namespace ToDoList.Models
{
    public class FamilyMember
    {
        public int Id { get; set; }
        public string MemberName { get; set; }
        public int FamilyAccountId { get; set; }
        public FamilyAccount FamilyAccount { get; set; }
    }

}
