namespace Redis.Entities
{
    public class Person
    {
        public Person(int id, string name, int age, bool isValid)
        {
            Id = id;
            Name = name;
            Age = age;
            IsValid = isValid;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public bool IsValid { get; private set; }

        public void Update(string name, int age, bool isValid)
        {
            Name = name;
            Age = age;
            IsValid = isValid;
        }
    }
}
