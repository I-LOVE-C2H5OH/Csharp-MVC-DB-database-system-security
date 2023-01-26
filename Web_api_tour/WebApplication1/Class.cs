namespace WebApplication1
{
    class Person
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public Person(string email, string password, Role role)
        {
            Email = email;
            Password = password;
            Role = role;
        }
    }
    class Role
    {
        public string Name { get; set; }
        public Role(string name) => Name = name;
    }
}
