namespace GetBooksProject.Entity
{
    class StorageBook : Book
    {
        public StorageBook(int id, string name) : base(name)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
