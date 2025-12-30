using Fahasa.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace Fahasa.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Author>().ToTable("Authors");

            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    Name = "J.K. Rowling",
                    Biography = "British author best known for the Harry Potter series",
                    Nationality = "United Kingdom",
                    BirthYear = 1965,

                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Author
                {
                    Id = 2,
                    Name = "Stephen King",
                    Biography = "American author of horror, supernatural fiction, and suspense",
                    Nationality = "United States",
                    BirthYear = 1947,

                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Author
                {
                    Id = 3,
                    Name = "Agatha Christie",
                    Biography = "English writer known for detective novels",
                    Nationality = "United Kingdom",
                    BirthYear = 1890,

                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Author
                {
                    Id = 4,
                    Name = "Dan Brown",
                    Biography = "American author of thriller fiction",
                    Nationality = "United States",
                    BirthYear = 1964,

                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Author
                {
                    Id = 5,
                    Name = "Haruki Murakami",
                    Biography = "Japanese writer known for surreal fiction",
                    Nationality = "Japan",
                    BirthYear = 1949,

                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Author
                {
                    Id = 6,
                    Name = "Margaret Atwood",
                    Biography = "Canadian poet, novelist, and literary critic",
                    Nationality = "Canada",
                    BirthYear = 1939,

                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Author
                {
                    Id = 7,
                    Name = "George R.R. Martin",
                    Biography = "American novelist and screenwriter, author of A Song of Ice and Fire",
                    Nationality = "United States",
                    BirthYear = 1948,

                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Author
                {
                    Id = 8,
                    Name = "Paulo Coelho",
                    Biography = "Brazilian lyricist and novelist",
                    Nationality = "Brazil",
                    BirthYear = 1947,

                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Author
                {
                    Id = 9,
                    Name = "Chimamanda Ngozi Adichie",
                    Biography = "Nigerian writer of novels, short stories, and nonfiction",
                    Nationality = "Nigeria",
                    BirthYear = 1977,

                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Author
                {
                    Id = 10,
                    Name = "Neil Gaiman",
                    Biography = "English author of short fiction, novels, and graphic novels",
                    Nationality = "United Kingdom",
                    BirthYear = 1960,

                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Author
                {
                    Id = 11,
                    Name = "Gabriel García Márquez",
                    Biography = "Colombian novelist and Nobel Prize winner, known for magical realism",
                    Nationality = "Colombia",
                    BirthYear = 1927,

                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Author
                {
                    Id = 12,
                    Name = "Jane Austen",
                    Biography = "English novelist known for her works of romantic fiction",
                    Nationality = "United Kingdom",
                    BirthYear = 1775,

                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Author
                {
                    Id = 13,
                    Name = "Ernest Hemingway",
                    Biography = "American novelist and journalist, Nobel Prize winner",
                    Nationality = "United States",
                    BirthYear = 1899,

                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Author
                {
                    Id = 14,
                    Name = "Toni Morrison",
                    Biography = "American novelist and Nobel Prize winner",
                    Nationality = "United States",
                    BirthYear = 1931,

                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Author
                {
                    Id = 15,
                    Name = "Leo Tolstoy",
                    Biography = "Russian writer regarded as one of the greatest authors of all time",
                    Nationality = "Russia",
                    BirthYear = 1828,

                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Author { Id = 16, Name = "F. Scott Fitzgerald", Biography = "American novelist of the Jazz Age.", Nationality = "USA", BirthYear = 1896, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 17, Name = "George Orwell", Biography = "English novelist, essayist, journalist and critic.", Nationality = "UK", BirthYear = 1903, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 18, Name = "Harper Lee", Biography = "American novelist best known for To Kill a Mockingbird.", Nationality = "USA", BirthYear = 1926, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 19, Name = "J.D. Salinger", Biography = "American writer known for The Catcher in the Rye.", Nationality = "USA", BirthYear = 1919, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 20, Name = "J.R.R. Tolkien", Biography = "English writer, poet, philologist, and academic.", Nationality = "UK", BirthYear = 1892, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 21, Name = "Frank Herbert", Biography = "American science fiction author.", Nationality = "USA", BirthYear = 1920, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 22, Name = "Orson Scott Card", Biography = "American novelist, critic, public speaker.", Nationality = "USA", BirthYear = 1951, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 23, Name = "Isaac Asimov", Biography = "American writer and professor of biochemistry.", Nationality = "USA", BirthYear = 1920, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 24, Name = "Delia Owens", Biography = "American author and zoologist.", Nationality = "USA", BirthYear = 1949, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 25, Name = "Gillian Flynn", Biography = "American author, comic book writer, and screenwriter.", Nationality = "USA", BirthYear = 1971, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 26, Name = "Stieg Larsson", Biography = "Swedish journalist and writer.", Nationality = "Sweden", BirthYear = 1954, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 27, Name = "James Clear", Biography = "American author and speaker.", Nationality = "USA", BirthYear = 1986, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 28, Name = "Mark Manson", Biography = "American self-help author and blogger.", Nationality = "USA", BirthYear = 1984, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 29, Name = "Robert Kiyosaki", Biography = "American businessman and author.", Nationality = "USA", BirthYear = 1947, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 30, Name = "Peter Thiel", Biography = "German-American billionaire entrepreneur and venture capitalist.", Nationality = "USA", BirthYear = 1967, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 31, Name = "Eric Ries", Biography = "American entrepreneur, blogger, and author.", Nationality = "USA", BirthYear = 1978, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 32, Name = "Robert C. Martin", Biography = "American software engineer and author.", Nationality = "USA", BirthYear = 1952, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 33, Name = "David Thomas", Biography = "Computer programmer and author.", Nationality = "UK", BirthYear = 1956, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 34, Name = "Thomas H. Cormen", Biography = "American computer scientist.", Nationality = "USA", BirthYear = 1956, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 35, Name = "Erich Gamma", Biography = "Swiss computer scientist.", Nationality = "Switzerland", BirthYear = 1961, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 36, Name = "Walter Isaacson", Biography = "American author and journalist.", Nationality = "USA", BirthYear = 1952, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 37, Name = "Ashlee Vance", Biography = "American business columnist and author.", Nationality = "USA", BirthYear = 1977, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 38, Name = "Michelle Obama", Biography = "American attorney and author.", Nationality = "USA", BirthYear = 1964, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 39, Name = "Yuval Noah Harari", Biography = "Israeli historian and author.", Nationality = "Israel", BirthYear = 1976, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 40, Name = "Tara Westover", Biography = "American memoirist and historian.", Nationality = "USA", BirthYear = 1986, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 41, Name = "Rick Riordan", Biography = "American author known for Percy Jackson.", Nationality = "USA", BirthYear = 1964, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 42, Name = "E.B. White", Biography = "American writer.", Nationality = "USA", BirthYear = 1899, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 43, Name = "Roald Dahl", Biography = "British novelist and short story writer.", Nationality = "UK", BirthYear = 1916, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 44, Name = "Suzanne Collins", Biography = "American television writer and author.", Nationality = "USA", BirthYear = 1962, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 45, Name = "Jon Krakauer", Biography = "American writer and mountaineer.", Nationality = "USA", BirthYear = 1954, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 46, Name = "Elizabeth Gilbert", Biography = "American journalist and author.", Nationality = "USA", BirthYear = 1969, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 47, Name = "Anthony Bourdain", Biography = "American celebrity chef and author.", Nationality = "USA", BirthYear = 1956, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 48, Name = "Samin Nosrat", Biography = "American chef and food writer.", Nationality = "USA", BirthYear = 1979, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 49, Name = "Mark Twain", Biography = "American writer, humorist, entrepreneur, publisher, and lecturer.", Nationality = "USA", BirthYear = 1835, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 50, Name = "Herman Melville", Biography = "American novelist, short story writer, and poet.", Nationality = "USA", BirthYear = 1819, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
            );

            modelBuilder.Entity<Category>().ToTable("Categories");
            
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Fiction",
                    Description = "Fiction books and novels",

                    DisplayOrder = 1,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Category
                {
                    Id = 2,
                    Name = "Non-Fiction",
                    Description = "Non-fiction and educational books",

                    DisplayOrder = 2,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Category
                {
                    Id = 3,
                    Name = "Children",
                    Description = "Books for children and young readers",

                    DisplayOrder = 3,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Category
                {
                    Id = 55,
                    Name = "Science Fiction",
                    Description = "Science fiction and fantasy books",

                    DisplayOrder = 4,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Category
                {
                    Id = 5,
                    Name = "Mystery",
                    Description = "Mystery and thriller books",

                    DisplayOrder = 5,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Category
                {
                    Id = 6,
                    Name = "Biography",
                    Description = "Biographies and memoirs",

                    DisplayOrder = 6,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Category
                {
                    Id = 7,
                    Name = "History",
                    Description = "Historical books and documentaries",

                    DisplayOrder = 7,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Category
                {
                    Id = 8,
                    Name = "Self-Help",
                    Description = "Self-improvement and motivational books",

                    DisplayOrder = 8,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Category
                {
                    Id = 9,
                    Name = "Romance",
                    Description = "Romance and love story books",

                    DisplayOrder = 9,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Category
                {
                    Id = 10,
                    Name = "Cooking",
                    Description = "Cooking and recipe books",

                    DisplayOrder = 10,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Category
                {
                    Id = 11,
                    Name = "Travel",
                    Description = "Travel guides and adventure books",

                    DisplayOrder = 11,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Category
                {
                    Id = 12,
                    Name = "Business",
                    Description = "Business and economics books",

                    DisplayOrder = 12,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Category
                {
                    Id = 13,
                    Name = "Technology",
                    Description = "Technology and computer science books",

                    DisplayOrder = 13,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }

            );

            modelBuilder.Entity<Publisher>().ToTable("Publishers");
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher
                {
                    Id = 1,
                    Name = "Penguin Random House",
                    Description = "Global trade book publisher",

                    Email = "info@penguinrandomhouse.com",
                    Phone = "+1-212-782-9000",
                    Address = "1745 Broadway, New York, NY 10019, USA",
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Publisher
                {
                    Id = 2,
                    Name = "HarperCollins",
                    Description = "One of the Big Five English-language publishers",

                    Email = "contact@harpercollins.com",
                    Phone = "+1-212-207-7000",
                    Address = "195 Broadway, New York, NY 10007, USA",
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Publisher
                {
                    Id = 3,
                    Name = "Simon & Schuster",
                    Description = "American publishing company",

                    Email = "info@simonandschuster.com",
                    Phone = "+1-212-698-7000",
                    Address = "1230 Avenue of the Americas, New York, NY 10020, USA",
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Publisher
                {
                    Id = 4,
                    Name = "Macmillan Publishers",
                    Description = "British publishing company",

                    Email = "contact@macmillan.com",
                    Phone = "+44-20-7014-6000",
                    Address = "The Smithson, 6 Briset Street, London EC1M 5NR, UK",
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Publisher
                {
                    Id = 5,
                    Name = "Hachette Book Group",
                    Description = "Publishing company owned by Hachette Livre",

                    Email = "info@hbgusa.com",
                    Phone = "+1-212-364-1100",
                    Address = "1290 Avenue of the Americas, New York, NY 10104, USA",
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Publisher
                {
                    Id = 6,
                    Name = "Scholastic Corporation",
                    Description = "American multinational publishing company",

                    Email = "contact@scholastic.com",
                    Phone = "+1-212-343-6100",
                    Address = "557 Broadway, New York, NY 10012, USA",
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Publisher
                {
                    Id = 7,
                    Name = "Oxford University Press",
                    Description = "University press of the University of Oxford",

                    Email = "enquiry@oup.com",
                    Phone = "+44-1865-556767",
                    Address = "Great Clarendon Street, Oxford OX2 6DP, UK",
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Publisher
                {
                    Id = 8,
                    Name = "Bloomsbury Publishing",
                    Description = "British worldwide publishing house",

                    Email = "contact@bloomsbury.com",
                    Phone = "+44-20-7631-5600",
                    Address = "50 Bedford Square, London WC1B 3DP, UK",
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Publisher
                {
                    Id = 9,
                    Name = "Wiley",
                    Description = "Global publishing company specializing in academic publishing",

                    Email = "info@wiley.com",
                    Phone = "+1-201-748-6000",
                    Address = "111 River Street, Hoboken, NJ 07030, USA",
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Publisher
                {
                    Id = 10,
                    Name = "Pearson Education",
                    Description = "British educational publishing and assessment service",

                    Email = "contact@pearson.com",
                    Phone = "+44-20-7010-2000",
                    Address = "80 Strand, London WC2R 0RL, UK",
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }
            );


            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Book>().Property(b => b.ImageUrl).HasDefaultValue("/images/books/default.png");
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Name = "Harry Potter và Hòn đá Phù thủy",
                    Description = "Cuốn sách đầu tiên trong series Harry Potter nổi tiếng",
                    CategoryId = 1, // Fiction
                    AuthorId = 1, // J.K. Rowling
                    PublisherId = 1, // Penguin Random House
                    ImageUrl = "/customer/img/product/book_1.jpg",
                    PublicationYear = 1997,
                    Language = 1, // Tiếng Việt
                    Pages = 320,
                    Weight = 450,
                    Width = 14.5m,
                    Height = 20.5m,
                    Depth = 2.5m,
                    CoverType = 0, // Paperback
                    Price = 150000,
                    DiscountPercent = 15,
                    // FinalPrice = 127500,
                    StockQuantity = 100,
                    SoldCount = 250,
                    ViewCount = 1500,
                    RatingAverage = 4.8m,
                    RatingCount = 120,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Book
                {
                    Id = 2,
                    Name = "The Shining",
                    Description = "A horror novel by Stephen King",
                    CategoryId = 5, // Thriller
                    AuthorId = 2, // Stephen King
                    PublisherId = 2, // HarperCollins
                    ImageUrl = "/customer/img/product/book_2.jpg",
                    PublicationYear = 1977,
                    Language = 2, // Tiếng Anh
                    Pages = 447,
                    Weight = 520,
                    Width = 15m,
                    Height = 23m,
                    Depth = 3m,
                    CoverType = 0,
                    Price = 280000,
                    DiscountPercent = 10,
                    // FinalPrice = 252000,
                    StockQuantity = 50,
                    SoldCount = 180,
                    ViewCount = 890,
                    RatingAverage = 4.6m,
                    RatingCount = 95,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Book
                {
                    Id = 3,
                    Name = "Murder on the Orient Express",
                    Description = "Classic mystery novel by Agatha Christie",
                    CategoryId = 2, // Mystery
                    AuthorId = 3, // Agatha Christie
                    PublisherId = 2, // HarperCollins
                    ImageUrl = "/customer/img/product/book_3.jpg",
                    PublicationYear = 1934,
                    Language = 1,
                    Pages = 256,
                    Weight = 350,
                    Width = 13m,
                    Height = 20m,
                    Depth = 2m,
                    CoverType = 0,
                    Price = 120000,
                    DiscountPercent = 20,
                    // FinalPrice = 96000,
                    StockQuantity = 75,
                    SoldCount = 320,
                    ViewCount = 1200,
                    RatingAverage = 4.7m,
                    RatingCount = 150,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Book
                {
                    Id = 4,
                    Name = "The Da Vinci Code",
                    Description = "Mystery thriller novel by Dan Brown",
                    CategoryId = 2, // Mystery
                    AuthorId = 4, // Dan Brown
                    PublisherId = 1, // Penguin Random House
                    ImageUrl = "/customer/img/product/book_4.jpg",
                    PublicationYear = 2003,
                    Language = 2,
                    Pages = 489,
                    Weight = 580,
                    Width = 15.5m,
                    Height = 23.5m,
                    Depth = 3.2m,
                    CoverType = 0,
                    Price = 320000,
                    DiscountPercent = 12,
                    // FinalPrice = 281600,
                    StockQuantity = 60,
                    SoldCount = 280,
                    ViewCount = 1450,
                    RatingAverage = 4.5m,
                    RatingCount = 200,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Book
                {
                    Id = 5,
                    Name = "Norwegian Wood",
                    Description = "Novel by Haruki Murakami",
                    CategoryId = 1, // Fiction
                    AuthorId = 5, // Haruki Murakami
                    PublisherId = 1, // Penguin Random House
                    ImageUrl = "/customer/img/product/book_5.jpg",
                    PublicationYear = 1987,
                    Language = 1,
                    Pages = 296,
                    Weight = 400,
                    Width = 14m,
                    Height = 21m,
                    Depth = 2.3m,
                    CoverType = 0,
                    Price = 180000,
                    DiscountPercent = 18,
                    // FinalPrice = 147600,
                    StockQuantity = 85,
                    SoldCount = 210,
                    ViewCount = 980,
                    RatingAverage = 4.4m,
                    RatingCount = 88,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Book
                {
                    Id = 6,
                    Name = "The Handmaid's Tale",
                    Description = "Dystopian novel by Margaret Atwood",
                    CategoryId = 1, // Fiction
                    AuthorId = 6, // Margaret Atwood
                    PublisherId = 2, // HarperCollins
                    ImageUrl = "/customer/img/product/book_6.jpg",
                    PublicationYear = 1985,
                    Language = 2,
                    Pages = 311,
                    Weight = 420,
                    Width = 14m,
                    Height = 21m,
                    Depth = 2.5m,
                    CoverType = 0,
                    Price = 220000,
                    DiscountPercent = 15,
                    // FinalPrice = 187000,
                    StockQuantity = 70,
                    SoldCount = 190,
                    ViewCount = 850,
                    RatingAverage = 4.6m,
                    RatingCount = 110,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Book
                {
                    Id = 7,
                    Name = "A Game of Thrones",
                    Description = "First book in A Song of Ice and Fire series",
                    CategoryId = 1, // Fiction
                    AuthorId = 7, // George R.R. Martin
                    PublisherId = 1, // Penguin Random House
                    ImageUrl = "/customer/img/product/book_7.jpg",
                    PublicationYear = 1996,
                    Language = 1,
                    Pages = 694,
                    Weight = 750,
                    Width = 16m,
                    Height = 24m,
                    Depth = 4m,
                    CoverType = 1, // Hardcover
                    Price = 450000,
                    DiscountPercent = 10,
                    // FinalPrice = 405000,
                    StockQuantity = 45,
                    SoldCount = 350,
                    ViewCount = 2100,
                    RatingAverage = 4.9m,
                    RatingCount = 280,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Book
                {
                    Id = 8,
                    Name = "The Alchemist",
                    Description = "Novel by Paulo Coelho",
                    CategoryId = 1, // Fiction
                    AuthorId = 8, // Paulo Coelho
                    PublisherId = 2, // HarperCollins
                    ImageUrl = "/customer/img/product/book_8.jpg",
                    PublicationYear = 1988,
                    Language = 1,
                    Pages = 208,
                    Weight = 300,
                    Width = 13m,
                    Height = 19.5m,
                    Depth = 1.8m,
                    CoverType = 0,
                    Price = 135000,
                    DiscountPercent = 25,
                    // FinalPrice = 101250,
                    StockQuantity = 120,
                    SoldCount = 420,
                    ViewCount = 1800,
                    RatingAverage = 4.7m,
                    RatingCount = 195,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Book
                {
                    Id = 9,
                    Name = "Americanah",
                    Description = "Novel by Chimamanda Ngozi Adichie",
                    CategoryId = 1, // Fiction
                    AuthorId = 9, // Chimamanda Ngozi Adichie
                    PublisherId = 1, // Penguin Random House
                    ImageUrl = "/customer/img/product/book_9.jpg",
                    PublicationYear = 2013,
                    Language = 2,
                    Pages = 477,
                    Weight = 550,
                    Width = 15m,
                    Height = 23m,
                    Depth = 3m,
                    CoverType = 0,
                    Price = 290000,
                    DiscountPercent = 8,
                    // FinalPrice = 266800,
                    StockQuantity = 55,
                    SoldCount = 145,
                    ViewCount = 720,
                    RatingAverage = 4.5m,
                    RatingCount = 78,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Book
                {
                    Id = 10,
                    Name = "American Gods",
                    Description = "Fantasy novel by Neil Gaiman",
                    CategoryId = 1, // Fiction
                    AuthorId = 10, // Neil Gaiman
                    PublisherId = 2, // HarperCollins
                    ImageUrl = "/customer/img/product/book_10.jpg",
                    PublicationYear = 2001,
                    Language = 2,
                    Pages = 465,
                    Weight = 530,
                    Width = 15m,
                    Height = 23m,
                    Depth = 3m,
                    CoverType = 0,
                    Price = 310000,
                    DiscountPercent = 12,
                    // FinalPrice = 272800,
                    StockQuantity = 65,
                    SoldCount = 220,
                    ViewCount = 1100,
                    RatingAverage = 4.6m,
                    RatingCount = 135,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Book
                {
                    Id = 11,
                    Name = "One Hundred Years of Solitude",
                    Description = "Novel by Gabriel García Márquez",
                    CategoryId = 1, // Fiction
                    AuthorId = 11, // Gabriel García Márquez
                    PublisherId = 1, // Penguin Random House
                    ImageUrl = "/customer/img/product/book_11.jpg",
                    PublicationYear = 1967,
                    Language = 1,
                    Pages = 417,
                    Weight = 480,
                    Width = 14.5m,
                    Height = 22m,
                    Depth = 2.8m,
                    CoverType = 0,
                    Price = 240000,
                    DiscountPercent = 20,
                    // FinalPrice = 192000,
                    StockQuantity = 80,
                    SoldCount = 290,
                    ViewCount = 1350,
                    RatingAverage = 4.8m,
                    RatingCount = 165,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Book
                {
                    Id = 12,
                    Name = "Pride and Prejudice",
                    Description = "Classic novel by Jane Austen",
                    CategoryId = 1, // Fiction
                    AuthorId = 12, // Jane Austen
                    PublisherId = 1, // Penguin Random House
                    ImageUrl = "/customer/img/product/book_12.jpg",
                    PublicationYear = 1813,
                    Language = 2,
                    Pages = 279,
                    Weight = 380,
                    Width = 13.5m,
                    Height = 20m,
                    Depth = 2.2m,
                    CoverType = 0,
                    Price = 165000,
                    DiscountPercent = 15,
                    // FinalPrice = 140250,
                    StockQuantity = 95,
                    SoldCount = 380,
                    ViewCount = 1650,
                    RatingAverage = 4.7m,
                    RatingCount = 220,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Book
                {
                    Id = 13,
                    Name = "The Old Man and the Sea",
                    Description = "Novella by Ernest Hemingway",
                    CategoryId = 1, // Fiction
                    AuthorId = 13, // Ernest Hemingway
                    PublisherId = 3, // Simon & Schuster
                    ImageUrl = "/customer/img/product/book_13.jpg",
                    PublicationYear = 1952,
                    Language = 1,
                    Pages = 127,
                    Weight = 200,
                    Width = 12m,
                    Height = 18m,
                    Depth = 1.2m,
                    CoverType = 0,
                    Price = 95000,
                    DiscountPercent = 10,
                    // FinalPrice = 85500,
                    StockQuantity = 110,
                    SoldCount = 340,
                    ViewCount = 1420,
                    RatingAverage = 4.5m,
                    RatingCount = 145,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Book
                {
                    Id = 14,
                    Name = "Beloved",
                    Description = "Novel by Toni Morrison",
                    CategoryId = 1, // Fiction
                    AuthorId = 14, // Toni Morrison
                    PublisherId = 1, // Penguin Random House
                    ImageUrl = "/customer/img/product/book_14.jpg",
                    PublicationYear = 1987,
                    Language = 2,
                    Pages = 324,
                    Weight = 430,
                    Width = 14m,
                    Height = 21m,
                    Depth = 2.5m,
                    CoverType = 0,
                    Price = 210000,
                    DiscountPercent = 18,
                    // FinalPrice = 172200,
                    StockQuantity = 70,
                    SoldCount = 175,
                    ViewCount = 820,
                    RatingAverage = 4.6m,
                    RatingCount = 92,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Book
                {
                    Id = 15,
                    Name = "War and Peace",
                    Description = "Epic novel by Leo Tolstoy",
                    CategoryId = 1, // Fiction
                    AuthorId = 15, // Leo Tolstoy
                    PublisherId = 1, // Penguin Random House
                    ImageUrl = "/customer/img/product/book_15.jpg",
                    PublicationYear = 1869,
                    Language = 1,
                    Pages = 1225,
                    Weight = 1200,
                    Width = 17m,
                    Height = 25m,
                    Depth = 6m,
                    CoverType = 1, // Hardcover
                    Price = 580000,
                    DiscountPercent = 15,
                    // FinalPrice = 493000,
                    StockQuantity = 30,
                    SoldCount = 125,
                    ViewCount = 650,
                    RatingAverage = 4.9m,
                    RatingCount = 85,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Book { Id = 16, Name = "The Great Gatsby", Description = "A novel set in the Jazz Age.", CategoryId = 1, AuthorId = 16, PublisherId = 3, PublicationYear = 1925, Language = 2, Pages = 180, Weight = 200, Width = 13, Height = 20, Depth = 1.5m, Price = 120000, DiscountPercent = 10, StockQuantity = 100, SoldCount = 500, ViewCount = 3000, RatingAverage = 4.8m, RatingCount = 450, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_16.jpg" },
                new Book { Id = 17, Name = "1984", Description = "Dystopian social science fiction novel.", CategoryId = 1, AuthorId = 17, PublisherId = 1, PublicationYear = 1949, Language = 2, Pages = 328, Weight = 300, Width = 14, Height = 21, Depth = 2, Price = 150000, DiscountPercent = 15, StockQuantity = 150, SoldCount = 600, ViewCount = 4000, RatingAverage = 4.9m, RatingCount = 600, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_17.jpg" },
                new Book { Id = 18, Name = "To Kill a Mockingbird", Description = "Novel about racial injustice.", CategoryId = 1, AuthorId = 18, PublisherId = 2, PublicationYear = 1960, Language = 2, Pages = 281, Weight = 350, Width = 14, Height = 21, Depth = 2.2m, Price = 160000, DiscountPercent = 10, StockQuantity = 120, SoldCount = 400, ViewCount = 2500, RatingAverage = 4.8m, RatingCount = 350, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_18.jpg" },
                new Book { Id = 19, Name = "The Catcher in the Rye", Description = "Novel about teen anguish.", CategoryId = 1, AuthorId = 19, PublisherId = 4, PublicationYear = 1951, Language = 2, Pages = 277, Weight = 250, Width = 13, Height = 20, Depth = 1.8m, Price = 140000, DiscountPercent = 5, StockQuantity = 80, SoldCount = 300, ViewCount = 2000, RatingAverage = 4.3m, RatingCount = 280, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_19.jpg" },
                new Book { Id = 20, Name = "The Hobbit", Description = "Fantasy novel prelude to LOTR.", CategoryId = 55, AuthorId = 20, PublisherId = 2, PublicationYear = 1937, Language = 2, Pages = 310, Weight = 400, Width = 15, Height = 22, Depth = 2.5m, Price = 200000, DiscountPercent = 20, StockQuantity = 200, SoldCount = 800, ViewCount = 5000, RatingAverage = 4.9m, RatingCount = 1000, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_20.jpg" },
                new Book { Id = 21, Name = "The Lord of the Rings", Description = "High fantasy epic.", CategoryId = 55, AuthorId = 20, PublisherId = 2, PublicationYear = 1954, Language = 2, Pages = 1178, Weight = 1500, Width = 16, Height = 24, Depth = 6, Price = 600000, DiscountPercent = 15, StockQuantity = 50, SoldCount = 300, ViewCount = 4500, RatingAverage = 5.0m, RatingCount = 1200, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_21.jpg" },
                new Book { Id = 22, Name = "Dune", Description = "Epic science fiction novel.", CategoryId = 55, AuthorId = 21, PublisherId = 6, PublicationYear = 1965, Language = 2, Pages = 412, Weight = 500, Width = 15, Height = 23, Depth = 3.5m, Price = 250000, DiscountPercent = 10, StockQuantity = 100, SoldCount = 450, ViewCount = 3200, RatingAverage = 4.7m, RatingCount = 500, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_22.jpg" },
                new Book { Id = 23, Name = "Ender's Game", Description = "Military science fiction novel.", CategoryId = 55, AuthorId = 22, PublisherId = 7, PublicationYear = 1985, Language = 2, Pages = 324, Weight = 350, Width = 14, Height = 21, Depth = 2.5m, Price = 180000, DiscountPercent = 12, StockQuantity = 80, SoldCount = 350, ViewCount = 2100, RatingAverage = 4.6m, RatingCount = 300, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_23.jpg" },
                new Book { Id = 24, Name = "Foundation", Description = "Sci-fi series starter.", CategoryId = 55, AuthorId = 23, PublisherId = 1, PublicationYear = 1951, Language = 2, Pages = 255, Weight = 300, Width = 13, Height = 20, Depth = 2, Price = 160000, DiscountPercent = 10, StockQuantity = 70, SoldCount = 250, ViewCount = 1800, RatingAverage = 4.5m, RatingCount = 220, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_24.jpg" },
                new Book { Id = 25, Name = "Where the Crawdads Sing", Description = "Mystery and coming-of-age novel.", CategoryId = 5, AuthorId = 24, PublisherId = 1, PublicationYear = 2018, Language = 2, Pages = 368, Weight = 450, Width = 15, Height = 23, Depth = 3, Price = 220000, DiscountPercent = 15, StockQuantity = 200, SoldCount = 900, ViewCount = 5500, RatingAverage = 4.7m, RatingCount = 800, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_25.jpg" },
                new Book { Id = 26, Name = "Gone Girl", Description = "Psychological thriller.", CategoryId = 5, AuthorId = 25, PublisherId = 5, PublicationYear = 2012, Language = 2, Pages = 419, Weight = 480, Width = 15, Height = 23, Depth = 3.2m, Price = 210000, DiscountPercent = 20, StockQuantity = 90, SoldCount = 500, ViewCount = 2800, RatingAverage = 4.2m, RatingCount = 400, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_26.jpg" },
                new Book { Id = 27, Name = "The Girl with the Dragon Tattoo", Description = "Psychological thriller.", CategoryId = 5, AuthorId = 26, PublisherId = 1, PublicationYear = 2005, Language = 2, Pages = 465, Weight = 520, Width = 15, Height = 23, Depth = 3.5m, Price = 230000, DiscountPercent = 10, StockQuantity = 110, SoldCount = 600, ViewCount = 3500, RatingAverage = 4.6m, RatingCount = 550, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_27.jpg" },
                new Book { Id = 28, Name = "Atomic Habits", Description = "Self-help book on habits.", CategoryId = 8, AuthorId = 27, PublisherId = 1, PublicationYear = 2018, Language = 2, Pages = 320, Weight = 400, Width = 15, Height = 23, Depth = 2.5m, Price = 250000, DiscountPercent = 15, StockQuantity = 300, SoldCount = 1500, ViewCount = 8000, RatingAverage = 4.9m, RatingCount = 2000, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_28.jpg" },
                new Book { Id = 29, Name = "The Subtle Art of Not Giving a F*ck", Description = "Self-help guide.", CategoryId = 8, AuthorId = 28, PublisherId = 2, PublicationYear = 2016, Language = 2, Pages = 224, Weight = 300, Width = 14, Height = 21, Depth = 2, Price = 180000, DiscountPercent = 20, StockQuantity = 250, SoldCount = 1200, ViewCount = 6000, RatingAverage = 4.5m, RatingCount = 1500, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_29.jpg" },
                new Book { Id = 30, Name = "Rich Dad Poor Dad", Description = "Personal finance classic.", CategoryId = 12, AuthorId = 29, PublisherId = 10, PublicationYear = 1997, Language = 2, Pages = 336, Weight = 350, Width = 15, Height = 23, Depth = 2.2m, Price = 190000, DiscountPercent = 10, StockQuantity = 200, SoldCount = 1000, ViewCount = 5000, RatingAverage = 4.7m, RatingCount = 1800, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_30.jpg" },
                new Book { Id = 31, Name = "Zero to One", Description = "Notes on startups.", CategoryId = 12, AuthorId = 30, PublisherId = 5, PublicationYear = 2014, Language = 2, Pages = 210, Weight = 300, Width = 14, Height = 21, Depth = 1.8m, Price = 200000, DiscountPercent = 15, StockQuantity = 150, SoldCount = 700, ViewCount = 3500, RatingAverage = 4.6m, RatingCount = 900, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_31.jpg" },
                new Book { Id = 32, Name = "The Lean Startup", Description = "Entrepreneurial guide.", CategoryId = 12, AuthorId = 31, PublisherId = 5, PublicationYear = 2011, Language = 2, Pages = 336, Weight = 400, Width = 15, Height = 23, Depth = 2.5m, Price = 220000, DiscountPercent = 12, StockQuantity = 130, SoldCount = 600, ViewCount = 3000, RatingAverage = 4.5m, RatingCount = 750, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_32.jpg" },
                new Book { Id = 33, Name = "Clean Code", Description = "Handbook of agile software craftsmanship.", CategoryId = 13, AuthorId = 32, PublisherId = 10, PublicationYear = 2008, Language = 2, Pages = 464, Weight = 800, Width = 18, Height = 24, Depth = 3, Price = 500000, DiscountPercent = 5, StockQuantity = 80, SoldCount = 400, ViewCount = 2000, RatingAverage = 4.9m, RatingCount = 600, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_33.jpg" },
                new Book { Id = 34, Name = "The Pragmatic Programmer", Description = "Coding best practices.", CategoryId = 13, AuthorId = 33, PublisherId = 10, PublicationYear = 1999, Language = 2, Pages = 352, Weight = 600, Width = 16, Height = 24, Depth = 2.5m, Price = 480000, DiscountPercent = 10, StockQuantity = 70, SoldCount = 350, ViewCount = 1800, RatingAverage = 4.8m, RatingCount = 500, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_34.jpg" },
                new Book { Id = 35, Name = "Introduction to Algorithms", Description = "Comprehensive algorithm textbook.", CategoryId = 13, AuthorId = 34, PublisherId = 10, PublicationYear = 2009, Language = 2, Pages = 1312, Weight = 2500, Width = 20, Height = 28, Depth = 7, Price = 1200000, DiscountPercent = 0, StockQuantity = 30, SoldCount = 150, ViewCount = 1000, RatingAverage = 4.9m, RatingCount = 300, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_35.jpg" },
                new Book { Id = 36, Name = "Design Patterns", Description = "Elements of reusable object-oriented software.", CategoryId = 13, AuthorId = 35, PublisherId = 10, PublicationYear = 1994, Language = 2, Pages = 395, Weight = 700, Width = 18, Height = 24, Depth = 2.5m, Price = 550000, DiscountPercent = 5, StockQuantity = 60, SoldCount = 300, ViewCount = 1500, RatingAverage = 4.7m, RatingCount = 450, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_36.jpg" },
                new Book { Id = 37, Name = "Steve Jobs", Description = "Biography of Apple co-founder.", CategoryId = 6, AuthorId = 36, PublisherId = 3, PublicationYear = 2011, Language = 2, Pages = 656, Weight = 900, Width = 16, Height = 24, Depth = 4.5m, Price = 350000, DiscountPercent = 20, StockQuantity = 150, SoldCount = 800, ViewCount = 4000, RatingAverage = 4.8m, RatingCount = 1000, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_37.jpg" },
                new Book { Id = 38, Name = "Elon Musk", Description = "Biography of Tesla & SpaceX CEO.", CategoryId = 6, AuthorId = 37, PublisherId = 2, PublicationYear = 2015, Language = 2, Pages = 400, Weight = 600, Width = 15, Height = 23, Depth = 3.5m, Price = 300000, DiscountPercent = 15, StockQuantity = 120, SoldCount = 600, ViewCount = 3200, RatingAverage = 4.7m, RatingCount = 850, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_38.jpg" },
                new Book { Id = 39, Name = "Becoming", Description = "Memoir by Michelle Obama.", CategoryId = 6, AuthorId = 38, PublisherId = 1, PublicationYear = 2018, Language = 2, Pages = 448, Weight = 750, Width = 16, Height = 24, Depth = 4, Price = 320000, DiscountPercent = 25, StockQuantity = 250, SoldCount = 1200, ViewCount = 5500, RatingAverage = 4.9m, RatingCount = 2000, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_39.jpg" },
                new Book { Id = 40, Name = "Sapiens", Description = "Brief history of humankind.", CategoryId = 7, AuthorId = 39, PublisherId = 2, PublicationYear = 2011, Language = 2, Pages = 464, Weight = 600, Width = 15, Height = 23, Depth = 3.5m, Price = 280000, DiscountPercent = 15, StockQuantity = 220, SoldCount = 1000, ViewCount = 5000, RatingAverage = 4.8m, RatingCount = 1500, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_40.jpg" },
                new Book { Id = 41, Name = "Educated", Description = "Memoir of survivalist family.", CategoryId = 6, AuthorId = 40, PublisherId = 1, PublicationYear = 2018, Language = 2, Pages = 352, Weight = 450, Width = 14, Height = 21, Depth = 2.5m, Price = 240000, DiscountPercent = 20, StockQuantity = 180, SoldCount = 900, ViewCount = 4200, RatingAverage = 4.7m, RatingCount = 1200, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_41.jpg" },
                new Book { Id = 42, Name = "Harry Potter and the Chamber of Secrets", Description = "Second HP book.", CategoryId = 3, AuthorId = 1, PublisherId = 1, PublicationYear = 1998, Language = 2, Pages = 341, Weight = 400, Width = 13, Height = 20, Depth = 2.5m, Price = 180000, DiscountPercent = 10, StockQuantity = 200, SoldCount = 1000, ViewCount = 4500, RatingAverage = 4.8m, RatingCount = 1100, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_42.jpg" },
                new Book { Id = 43, Name = "Percy Jackson: The Lightning Thief", Description = "Greek mythology adventure.", CategoryId = 3, AuthorId = 41, PublisherId = 1, PublicationYear = 2005, Language = 2, Pages = 377, Weight = 350, Width = 13, Height = 20, Depth = 2.5m, Price = 160000, DiscountPercent = 15, StockQuantity = 150, SoldCount = 700, ViewCount = 3500, RatingAverage = 4.7m, RatingCount = 900, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_43.jpg" },
                new Book { Id = 44, Name = "Charlotte's Web", Description = "Classic children's book.", CategoryId = 3, AuthorId = 42, PublisherId = 2, PublicationYear = 1952, Language = 2, Pages = 192, Weight = 250, Width = 13, Height = 20, Depth = 1.5m, Price = 120000, DiscountPercent = 10, StockQuantity = 100, SoldCount = 500, ViewCount = 2000, RatingAverage = 4.8m, RatingCount = 400, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_44.jpg" },
                new Book { Id = 45, Name = "Matilda", Description = "Story of a brilliant girl.", CategoryId = 3, AuthorId = 43, PublisherId = 1, PublicationYear = 1988, Language = 2, Pages = 240, Weight = 300, Width = 13, Height = 20, Depth = 2, Price = 140000, DiscountPercent = 15, StockQuantity = 120, SoldCount = 600, ViewCount = 2800, RatingAverage = 4.7m, RatingCount = 500, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_45.jpg" },
                new Book { Id = 46, Name = "The Hunger Games", Description = "Dystopian survival.", CategoryId = 55, AuthorId = 44, PublisherId = 1, PublicationYear = 2008, Language = 2, Pages = 374, Weight = 450, Width = 14, Height = 21, Depth = 3, Price = 190000, DiscountPercent = 20, StockQuantity = 180, SoldCount = 950, ViewCount = 4800, RatingAverage = 4.6m, RatingCount = 1300, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_46.jpg" },
                new Book { Id = 47, Name = "Into the Wild", Description = "True story of survival.", CategoryId = 11, AuthorId = 45, PublisherId = 1, PublicationYear = 1996, Language = 2, Pages = 224, Weight = 300, Width = 13, Height = 20, Depth = 2, Price = 170000, DiscountPercent = 10, StockQuantity = 100, SoldCount = 400, ViewCount = 2200, RatingAverage = 4.5m, RatingCount = 350, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_47.jpg" },
                new Book { Id = 48, Name = "Eat, Pray, Love", Description = "Memoir of travel.", CategoryId = 11, AuthorId = 46, PublisherId = 1, PublicationYear = 2006, Language = 2, Pages = 334, Weight = 400, Width = 14, Height = 21, Depth = 2.5m, Price = 180000, DiscountPercent = 15, StockQuantity = 120, SoldCount = 600, ViewCount = 2900, RatingAverage = 4.2m, RatingCount = 600, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_48.jpg" },
                new Book { Id = 49, Name = "Kitchen Confidential", Description = "Adventures in culinary underbelly.", CategoryId = 10, AuthorId = 47, PublisherId = 2, PublicationYear = 2000, Language = 2, Pages = 312, Weight = 350, Width = 14, Height = 21, Depth = 2, Price = 200000, DiscountPercent = 10, StockQuantity = 150, SoldCount = 700, ViewCount = 3100, RatingAverage = 4.8m, RatingCount = 800, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_49.jpg" },
                new Book { Id = 50, Name = "Salt, Fat, Acid, Heat", Description = "Mastering elements of cooking.", CategoryId = 10, AuthorId = 48, PublisherId = 3, PublicationYear = 2017, Language = 2, Pages = 480, Weight = 1200, Width = 20, Height = 25, Depth = 4, Price = 550000, DiscountPercent = 5, StockQuantity = 100, SoldCount = 500, ViewCount = 2500, RatingAverage = 4.9m, RatingCount = 700, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), ImageUrl = "/customer/img/product/book_50.jpg" }
            );
        }
        
    }
}
