using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fahasa.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "AvatarUrl", "Biography", "BirthYear", "CreatedAt", "Name", "Nationality", "UpdatedAt" },
                values: new object[,]
                {
                    { 16, null, "American novelist of the Jazz Age.", 1896, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "F. Scott Fitzgerald", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 17, null, "English novelist, essayist, journalist and critic.", 1903, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "George Orwell", "UK", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 18, null, "American novelist best known for To Kill a Mockingbird.", 1926, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Harper Lee", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 19, null, "American writer known for The Catcher in the Rye.", 1919, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "J.D. Salinger", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 20, null, "English writer, poet, philologist, and academic.", 1892, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "J.R.R. Tolkien", "UK", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 21, null, "American science fiction author.", 1920, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Frank Herbert", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 22, null, "American novelist, critic, public speaker.", 1951, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Orson Scott Card", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 23, null, "American writer and professor of biochemistry.", 1920, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Isaac Asimov", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 24, null, "American author and zoologist.", 1949, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Delia Owens", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 25, null, "American author, comic book writer, and screenwriter.", 1971, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gillian Flynn", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 26, null, "Swedish journalist and writer.", 1954, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Stieg Larsson", "Sweden", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 27, null, "American author and speaker.", 1986, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "James Clear", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 28, null, "American self-help author and blogger.", 1984, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mark Manson", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 29, null, "American businessman and author.", 1947, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Robert Kiyosaki", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 30, null, "German-American billionaire entrepreneur and venture capitalist.", 1967, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Peter Thiel", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 31, null, "American entrepreneur, blogger, and author.", 1978, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Eric Ries", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 32, null, "American software engineer and author.", 1952, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Robert C. Martin", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 33, null, "Computer programmer and author.", 1956, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "David Thomas", "UK", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 34, null, "American computer scientist.", 1956, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Thomas H. Cormen", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 35, null, "Swiss computer scientist.", 1961, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Erich Gamma", "Switzerland", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 36, null, "American author and journalist.", 1952, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Walter Isaacson", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 37, null, "American business columnist and author.", 1977, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ashlee Vance", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 38, null, "American attorney and author.", 1964, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Michelle Obama", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 39, null, "Israeli historian and author.", 1976, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Yuval Noah Harari", "Israel", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 40, null, "American memoirist and historian.", 1986, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Tara Westover", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 41, null, "American author known for Percy Jackson.", 1964, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Rick Riordan", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 42, null, "American writer.", 1899, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E.B. White", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 43, null, "British novelist and short story writer.", 1916, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Roald Dahl", "UK", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 44, null, "American television writer and author.", 1962, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Suzanne Collins", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 45, null, "American writer and mountaineer.", 1954, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Jon Krakauer", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 46, null, "American journalist and author.", 1969, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Elizabeth Gilbert", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 47, null, "American celebrity chef and author.", 1956, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Anthony Bourdain", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 48, null, "American chef and food writer.", 1979, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Samin Nosrat", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 49, null, "American writer, humorist, entrepreneur, publisher, and lecturer.", 1835, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mark Twain", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 50, null, "American novelist, short story writer, and poet.", 1819, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Herman Melville", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CoverType", "CreatedAt", "Depth", "Description", "DiscountPercent", "Height", "ImageUrl", "IsActive", "IsBestseller", "IsFeatured", "IsNewRelease", "Language", "Name", "Pages", "Price", "PublicationYear", "PublisherId", "RatingAverage", "RatingCount", "SoldCount", "StockQuantity", "UpdatedAt", "ViewCount", "Weight", "Width" },
                values: new object[,]
                {
                    { 42, 1, 3, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2.5m, "Second HP book.", 10, 20m, "/customer/img/product/book_42.jpg", true, false, false, false, 2, "Harry Potter and the Chamber of Secrets", 341, 180000, 1998, 1, 4.8m, 1100, 1000, 200, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4500, 400, 13m },
                    { 16, 16, 1, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1.5m, "A novel set in the Jazz Age.", 10, 20m, "/customer/img/product/book_16.jpg", true, false, false, false, 2, "The Great Gatsby", 180, 120000, 1925, 3, 4.8m, 450, 500, 100, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3000, 200, 13m },
                    { 17, 17, 1, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2m, "Dystopian social science fiction novel.", 15, 21m, "/customer/img/product/book_17.jpg", true, false, false, false, 2, "1984", 328, 150000, 1949, 1, 4.9m, 600, 600, 150, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4000, 300, 14m },
                    { 18, 18, 1, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2.2m, "Novel about racial injustice.", 10, 21m, "/customer/img/product/book_18.jpg", true, false, false, false, 2, "To Kill a Mockingbird", 281, 160000, 1960, 2, 4.8m, 350, 400, 120, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2500, 350, 14m },
                    { 19, 19, 1, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1.8m, "Novel about teen anguish.", 5, 20m, "/customer/img/product/book_19.jpg", true, false, false, false, 2, "The Catcher in the Rye", 277, 140000, 1951, 4, 4.3m, 280, 300, 80, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2000, 250, 13m },
                    { 20, 20, 55, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2.5m, "Fantasy novel prelude to LOTR.", 20, 22m, "/customer/img/product/book_20.jpg", true, false, false, false, 2, "The Hobbit", 310, 200000, 1937, 2, 4.9m, 1000, 800, 200, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 5000, 400, 15m },
                    { 21, 20, 55, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 6m, "High fantasy epic.", 15, 24m, "/customer/img/product/book_21.jpg", true, false, false, false, 2, "The Lord of the Rings", 1178, 600000, 1954, 2, 5.0m, 1200, 300, 50, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4500, 1500, 16m },
                    { 22, 21, 55, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3.5m, "Epic science fiction novel.", 10, 23m, "/customer/img/product/book_22.jpg", true, false, false, false, 2, "Dune", 412, 250000, 1965, 6, 4.7m, 500, 450, 100, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3200, 500, 15m },
                    { 23, 22, 55, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2.5m, "Military science fiction novel.", 12, 21m, "/customer/img/product/book_23.jpg", true, false, false, false, 2, "Ender's Game", 324, 180000, 1985, 7, 4.6m, 300, 350, 80, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2100, 350, 14m },
                    { 24, 23, 55, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2m, "Sci-fi series starter.", 10, 20m, "/customer/img/product/book_24.jpg", true, false, false, false, 2, "Foundation", 255, 160000, 1951, 1, 4.5m, 220, 250, 70, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1800, 300, 13m },
                    { 25, 24, 5, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3m, "Mystery and coming-of-age novel.", 15, 23m, "/customer/img/product/book_25.jpg", true, false, false, false, 2, "Where the Crawdads Sing", 368, 220000, 2018, 1, 4.7m, 800, 900, 200, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 5500, 450, 15m },
                    { 26, 25, 5, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3.2m, "Psychological thriller.", 20, 23m, "/customer/img/product/book_26.jpg", true, false, false, false, 2, "Gone Girl", 419, 210000, 2012, 5, 4.2m, 400, 500, 90, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2800, 480, 15m },
                    { 27, 26, 5, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3.5m, "Psychological thriller.", 10, 23m, "/customer/img/product/book_27.jpg", true, false, false, false, 2, "The Girl with the Dragon Tattoo", 465, 230000, 2005, 1, 4.6m, 550, 600, 110, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3500, 520, 15m },
                    { 28, 27, 8, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2.5m, "Self-help book on habits.", 15, 23m, "/customer/img/product/book_28.jpg", true, false, false, false, 2, "Atomic Habits", 320, 250000, 2018, 1, 4.9m, 2000, 1500, 300, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 8000, 400, 15m },
                    { 29, 28, 8, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2m, "Self-help guide.", 20, 21m, "/customer/img/product/book_29.jpg", true, false, false, false, 2, "The Subtle Art of Not Giving a F*ck", 224, 180000, 2016, 2, 4.5m, 1500, 1200, 250, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 6000, 300, 14m },
                    { 30, 29, 12, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2.2m, "Personal finance classic.", 10, 23m, "/customer/img/product/book_30.jpg", true, false, false, false, 2, "Rich Dad Poor Dad", 336, 190000, 1997, 10, 4.7m, 1800, 1000, 200, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 5000, 350, 15m },
                    { 31, 30, 12, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1.8m, "Notes on startups.", 15, 21m, "/customer/img/product/book_31.jpg", true, false, false, false, 2, "Zero to One", 210, 200000, 2014, 5, 4.6m, 900, 700, 150, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3500, 300, 14m },
                    { 32, 31, 12, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2.5m, "Entrepreneurial guide.", 12, 23m, "/customer/img/product/book_32.jpg", true, false, false, false, 2, "The Lean Startup", 336, 220000, 2011, 5, 4.5m, 750, 600, 130, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3000, 400, 15m },
                    { 33, 32, 13, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3m, "Handbook of agile software craftsmanship.", 5, 24m, "/customer/img/product/book_33.jpg", true, false, false, false, 2, "Clean Code", 464, 500000, 2008, 10, 4.9m, 600, 400, 80, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2000, 800, 18m },
                    { 34, 33, 13, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2.5m, "Coding best practices.", 10, 24m, "/customer/img/product/book_34.jpg", true, false, false, false, 2, "The Pragmatic Programmer", 352, 480000, 1999, 10, 4.8m, 500, 350, 70, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1800, 600, 16m },
                    { 35, 34, 13, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 7m, "Comprehensive algorithm textbook.", 0, 28m, "/customer/img/product/book_35.jpg", true, false, false, false, 2, "Introduction to Algorithms", 1312, 1200000, 2009, 10, 4.9m, 300, 150, 30, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1000, 2500, 20m },
                    { 36, 35, 13, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2.5m, "Elements of reusable object-oriented software.", 5, 24m, "/customer/img/product/book_36.jpg", true, false, false, false, 2, "Design Patterns", 395, 550000, 1994, 10, 4.7m, 450, 300, 60, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1500, 700, 18m },
                    { 37, 36, 6, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4.5m, "Biography of Apple co-founder.", 20, 24m, "/customer/img/product/book_37.jpg", true, false, false, false, 2, "Steve Jobs", 656, 350000, 2011, 3, 4.8m, 1000, 800, 150, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4000, 900, 16m },
                    { 38, 37, 6, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3.5m, "Biography of Tesla & SpaceX CEO.", 15, 23m, "/customer/img/product/book_38.jpg", true, false, false, false, 2, "Elon Musk", 400, 300000, 2015, 2, 4.7m, 850, 600, 120, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3200, 600, 15m },
                    { 39, 38, 6, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4m, "Memoir by Michelle Obama.", 25, 24m, "/customer/img/product/book_39.jpg", true, false, false, false, 2, "Becoming", 448, 320000, 2018, 1, 4.9m, 2000, 1200, 250, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 5500, 750, 16m },
                    { 40, 39, 7, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3.5m, "Brief history of humankind.", 15, 23m, "/customer/img/product/book_40.jpg", true, false, false, false, 2, "Sapiens", 464, 280000, 2011, 2, 4.8m, 1500, 1000, 220, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 5000, 600, 15m },
                    { 41, 40, 6, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2.5m, "Memoir of survivalist family.", 20, 21m, "/customer/img/product/book_41.jpg", true, false, false, false, 2, "Educated", 352, 240000, 2018, 1, 4.7m, 1200, 900, 180, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4200, 450, 14m },
                    { 43, 41, 3, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2.5m, "Greek mythology adventure.", 15, 20m, "/customer/img/product/book_43.jpg", true, false, false, false, 2, "Percy Jackson: The Lightning Thief", 377, 160000, 2005, 1, 4.7m, 900, 700, 150, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3500, 350, 13m },
                    { 44, 42, 3, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1.5m, "Classic children's book.", 10, 20m, "/customer/img/product/book_44.jpg", true, false, false, false, 2, "Charlotte's Web", 192, 120000, 1952, 2, 4.8m, 400, 500, 100, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2000, 250, 13m },
                    { 45, 43, 3, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2m, "Story of a brilliant girl.", 15, 20m, "/customer/img/product/book_45.jpg", true, false, false, false, 2, "Matilda", 240, 140000, 1988, 1, 4.7m, 500, 600, 120, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2800, 300, 13m },
                    { 46, 44, 55, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3m, "Dystopian survival.", 20, 21m, "/customer/img/product/book_46.jpg", true, false, false, false, 2, "The Hunger Games", 374, 190000, 2008, 1, 4.6m, 1300, 950, 180, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4800, 450, 14m },
                    { 47, 45, 11, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2m, "True story of survival.", 10, 20m, "/customer/img/product/book_47.jpg", true, false, false, false, 2, "Into the Wild", 224, 170000, 1996, 1, 4.5m, 350, 400, 100, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2200, 300, 13m },
                    { 48, 46, 11, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2.5m, "Memoir of travel.", 15, 21m, "/customer/img/product/book_48.jpg", true, false, false, false, 2, "Eat, Pray, Love", 334, 180000, 2006, 1, 4.2m, 600, 600, 120, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2900, 400, 14m },
                    { 49, 47, 10, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2m, "Adventures in culinary underbelly.", 10, 21m, "/customer/img/product/book_49.jpg", true, false, false, false, 2, "Kitchen Confidential", 312, 200000, 2000, 2, 4.8m, 800, 700, 150, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3100, 350, 14m },
                    { 50, 48, 10, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4m, "Mastering elements of cooking.", 5, 25m, "/customer/img/product/book_50.jpg", true, false, false, false, 2, "Salt, Fat, Acid, Heat", 480, 550000, 2017, 3, 4.9m, 700, 500, 100, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2500, 1200, 20m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 48);
        }
    }
}
