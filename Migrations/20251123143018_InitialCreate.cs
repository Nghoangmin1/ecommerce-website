using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fahasa.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    LoyaltyPoints = table.Column<int>(type: "int", nullable: false),
                    MemberTier = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BirthYear = table.Column<int>(type: "int", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    PublicationYear = table.Column<int>(type: "int", nullable: true),
                    Language = table.Column<int>(type: "int", nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    Width = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Depth = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CoverType = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPercent = table.Column<int>(type: "int", nullable: false),
                    FinalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    SoldCount = table.Column<int>(type: "int", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    RatingAverage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RatingCount = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, defaultValue: "/images/books/default.png"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    IsBestseller = table.Column<bool>(type: "bit", nullable: false),
                    IsNewRelease = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "AvatarUrl", "Biography", "BirthYear", "CreatedAt", "Name", "Nationality" },
                values: new object[,]
                {
                    { 1, "/images/authors/jk-rowling.jpg", "British author best known for the Harry Potter series", 1965, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "J.K. Rowling", "United Kingdom" },
                    { 2, "/images/authors/stephen-king.jpg", "American author of horror, supernatural fiction, and suspense", 1947, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Stephen King", "United States" },
                    { 3, "/images/authors/agatha-christie.jpg", "English writer known for detective novels", 1890, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Agatha Christie", "United Kingdom" },
                    { 4, "/images/authors/dan-brown.jpg", "American author of thriller fiction", 1964, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Dan Brown", "United States" },
                    { 5, "/images/authors/haruki-murakami.jpg", "Japanese writer known for surreal fiction", 1949, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Haruki Murakami", "Japan" },
                    { 6, "/images/authors/margaret-atwood.jpg", "Canadian poet, novelist, and literary critic", 1939, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Margaret Atwood", "Canada" },
                    { 7, "/images/authors/george-martin.jpg", "American novelist and screenwriter, author of A Song of Ice and Fire", 1948, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "George R.R. Martin", "United States" },
                    { 8, "/images/authors/paulo-coelho.jpg", "Brazilian lyricist and novelist", 1947, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Paulo Coelho", "Brazil" },
                    { 9, "/images/authors/chimamanda-adichie.jpg", "Nigerian writer of novels, short stories, and nonfiction", 1977, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Chimamanda Ngozi Adichie", "Nigeria" },
                    { 10, "/images/authors/neil-gaiman.jpg", "English author of short fiction, novels, and graphic novels", 1960, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Neil Gaiman", "United Kingdom" },
                    { 11, "/images/authors/gabriel-marquez.jpg", "Colombian novelist and Nobel Prize winner, known for magical realism", 1927, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gabriel García Márquez", "Colombia" },
                    { 12, "/images/authors/jane-austen.jpg", "English novelist known for her works of romantic fiction", 1775, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Jane Austen", "United Kingdom" },
                    { 13, "/images/authors/ernest-hemingway.jpg", "American novelist and journalist, Nobel Prize winner", 1899, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ernest Hemingway", "United States" },
                    { 14, "/images/authors/toni-morrison.jpg", "American novelist and Nobel Prize winner", 1931, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Toni Morrison", "United States" },
                    { 15, "/images/authors/leo-tolstoy.jpg", "Russian writer regarded as one of the greatest authors of all time", 1828, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Leo Tolstoy", "Russia" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "DisplayOrder", "ImageUrl", "IsActive", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Fiction books and novels", 1, "/images/categories/fiction.jpg", true, "Fiction", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Non-fiction and educational books", 2, "/images/categories/non-fiction.jpg", true, "Non-Fiction", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Books for children and young readers", 3, "/images/categories/children.jpg", true, "Children", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mystery and thriller books", 5, "/images/categories/mystery.jpg", true, "Mystery", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Biographies and memoirs", 6, "/images/categories/biography.jpg", true, "Biography", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 7, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Historical books and documentaries", 7, "/images/categories/history.jpg", true, "History", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 8, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Self-improvement and motivational books", 8, "/images/categories/selfhelp.jpg", true, "Self-Help", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 9, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Romance and love story books", 9, "/images/categories/romance.jpg", true, "Romance", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 10, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Cooking and recipe books", 10, "/images/categories/cooking.jpg", true, "Cooking", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 11, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Travel guides and adventure books", 11, "/images/categories/travel.jpg", true, "Travel", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 12, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Business and economics books", 12, "/images/categories/business.jpg", true, "Business", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 13, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Technology and computer science books", 13, "/images/categories/technology.jpg", true, "Technology", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 55, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Science fiction and fantasy books", 4, "/images/categories/scifi.jpg", true, "Science Fiction", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Address", "CreatedAt", "Description", "Email", "LogoUrl", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "1745 Broadway, New York, NY 10019, USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Global trade book publisher", "info@penguinrandomhouse.com", "/images/publishers/penguin.jpg", "Penguin Random House", "+1-212-782-9000" },
                    { 2, "195 Broadway, New York, NY 10007, USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "One of the Big Five English-language publishers", "contact@harpercollins.com", "/images/publishers/harpercollins.jpg", "HarperCollins", "+1-212-207-7000" },
                    { 3, "1230 Avenue of the Americas, New York, NY 10020, USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "American publishing company", "info@simonandschuster.com", "/images/publishers/simonschuster.jpg", "Simon & Schuster", "+1-212-698-7000" },
                    { 4, "The Smithson, 6 Briset Street, London EC1M 5NR, UK", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "British publishing company", "contact@macmillan.com", "/images/publishers/macmillan.jpg", "Macmillan Publishers", "+44-20-7014-6000" },
                    { 5, "1290 Avenue of the Americas, New York, NY 10104, USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Publishing company owned by Hachette Livre", "info@hbgusa.com", "/images/publishers/hachette.jpg", "Hachette Book Group", "+1-212-364-1100" },
                    { 6, "557 Broadway, New York, NY 10012, USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "American multinational publishing company", "contact@scholastic.com", "/images/publishers/scholastic.jpg", "Scholastic Corporation", "+1-212-343-6100" },
                    { 7, "Great Clarendon Street, Oxford OX2 6DP, UK", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "University press of the University of Oxford", "enquiry@oup.com", "/images/publishers/oxford.jpg", "Oxford University Press", "+44-1865-556767" },
                    { 8, "50 Bedford Square, London WC1B 3DP, UK", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "British worldwide publishing house", "contact@bloomsbury.com", "/images/publishers/bloomsbury.jpg", "Bloomsbury Publishing", "+44-20-7631-5600" },
                    { 9, "111 River Street, Hoboken, NJ 07030, USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Global publishing company specializing in academic publishing", "info@wiley.com", "/images/publishers/wiley.jpg", "Wiley", "+1-201-748-6000" },
                    { 10, "80 Strand, London WC2R 0RL, UK", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "British educational publishing and assessment service", "contact@pearson.com", "/images/publishers/pearson.jpg", "Pearson Education", "+44-20-7010-2000" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CoverType", "CreatedAt", "Depth", "Description", "DiscountPercent", "FinalPrice", "Height", "ImageUrl", "IsActive", "IsBestseller", "IsFeatured", "IsNewRelease", "Language", "Name", "Pages", "Price", "PublicationYear", "PublisherId", "RatingAverage", "RatingCount", "SoldCount", "StockQuantity", "UpdatedAt", "ViewCount", "Weight", "Width" },
                values: new object[,]
                {
                    { 1, 1, 1, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2.5m, "Cuốn sách đầu tiên trong series Harry Potter nổi tiếng", 15, 127500m, 20.5m, "/images/books/default.png", true, false, false, false, 1, "Harry Potter và Hòn đá Phù thủy", 320, 150000m, 1997, 1, 4.8m, 120, 250, 100, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1500, 450, 14.5m },
                    { 2, 2, 5, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3m, "A horror novel by Stephen King", 10, 252000m, 23m, "/images/books/default.png", true, false, false, false, 2, "The Shining", 447, 280000m, 1977, 2, 4.6m, 95, 180, 50, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 890, 520, 15m },
                    { 3, 3, 2, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2m, "Classic mystery novel by Agatha Christie", 20, 96000m, 20m, "/images/books/default.png", true, false, false, false, 1, "Murder on the Orient Express", 256, 120000m, 1934, 2, 4.7m, 150, 320, 75, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1200, 350, 13m },
                    { 4, 4, 2, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3.2m, "Mystery thriller novel by Dan Brown", 12, 281600m, 23.5m, "/images/books/default.png", true, false, false, false, 2, "The Da Vinci Code", 489, 320000m, 2003, 1, 4.5m, 200, 280, 60, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1450, 580, 15.5m },
                    { 5, 5, 1, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2.3m, "Novel by Haruki Murakami", 18, 147600m, 21m, "/images/books/default.png", true, false, false, false, 1, "Norwegian Wood", 296, 180000m, 1987, 1, 4.4m, 88, 210, 85, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 980, 400, 14m },
                    { 6, 6, 1, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2.5m, "Dystopian novel by Margaret Atwood", 15, 187000m, 21m, "/images/books/default.png", true, false, false, false, 2, "The Handmaid's Tale", 311, 220000m, 1985, 2, 4.6m, 110, 190, 70, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 850, 420, 14m },
                    { 7, 7, 1, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4m, "First book in A Song of Ice and Fire series", 10, 405000m, 24m, "/images/books/default.png", true, false, false, false, 1, "A Game of Thrones", 694, 450000m, 1996, 1, 4.9m, 280, 350, 45, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2100, 750, 16m },
                    { 8, 8, 1, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1.8m, "Novel by Paulo Coelho", 25, 101250m, 19.5m, "/images/books/default.png", true, false, false, false, 1, "The Alchemist", 208, 135000m, 1988, 2, 4.7m, 195, 420, 120, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1800, 300, 13m },
                    { 9, 9, 1, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3m, "Novel by Chimamanda Ngozi Adichie", 8, 266800m, 23m, "/images/books/default.png", true, false, false, false, 2, "Americanah", 477, 290000m, 2013, 1, 4.5m, 78, 145, 55, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 720, 550, 15m },
                    { 10, 10, 1, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3m, "Fantasy novel by Neil Gaiman", 12, 272800m, 23m, "/images/books/default.png", true, false, false, false, 2, "American Gods", 465, 310000m, 2001, 2, 4.6m, 135, 220, 65, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1100, 530, 15m },
                    { 11, 11, 1, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2.8m, "Novel by Gabriel García Márquez", 20, 192000m, 22m, "/images/books/default.png", true, false, false, false, 1, "One Hundred Years of Solitude", 417, 240000m, 1967, 1, 4.8m, 165, 290, 80, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1350, 480, 14.5m },
                    { 12, 12, 1, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2.2m, "Classic novel by Jane Austen", 15, 140250m, 20m, "/images/books/default.png", true, false, false, false, 2, "Pride and Prejudice", 279, 165000m, 1813, 1, 4.7m, 220, 380, 95, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1650, 380, 13.5m },
                    { 13, 13, 1, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1.2m, "Novella by Ernest Hemingway", 10, 85500m, 18m, "/images/books/default.png", true, false, false, false, 1, "The Old Man and the Sea", 127, 95000m, 1952, 3, 4.5m, 145, 340, 110, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1420, 200, 12m },
                    { 14, 14, 1, 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2.5m, "Novel by Toni Morrison", 18, 172200m, 21m, "/images/books/default.png", true, false, false, false, 2, "Beloved", 324, 210000m, 1987, 1, 4.6m, 92, 175, 70, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 820, 430, 14m },
                    { 15, 15, 1, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 6m, "Epic novel by Leo Tolstoy", 15, 493000m, 25m, "/images/books/default.png", true, false, false, false, 1, "War and Peace", 1225, 580000m, 1869, 1, 4.9m, 85, 125, 30, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 650, 1200, 17m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
