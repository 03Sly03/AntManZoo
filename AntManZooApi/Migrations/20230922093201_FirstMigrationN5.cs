using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AntManZooApi.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigrationN5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Species = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "Description", "ImageLink", "Name", "Species" },
                values: new object[,]
                {
                    { 1, 6, "Balto le héros !", "https://www.sciencesetavenir.fr/assets/img/2023/04/25/cover-r4x3w1200-6447e451a984d-balto-kasson.jpg", "Balto", 1 },
                    { 2, 12, "Très beau cheval de feu", "https://i.ytimg.com/vi/vbb0oUNE65o/sddefault.jpg", "Ponyta", 4 },
                    { 3, 3, "Un ours originaire de Springfield", "https://media.gq.com/photos/596cf8527bf9083f8bf881b8/16:9/w_1280,c_limit/winnie-the-pooh-ban-china.jpg", "Winnie", 2 },
                    { 4, 41, "Un très beau lion à qui il manque une patte", "https://cdn.images.express.co.uk/img/dynamic/20/590x/secondary/Game-of-Thrones-Jaime-was-trapped-with-his-cousin-1864452.jpg?r=1558125976497", "Jamie", 3 },
                    { 5, 110, "Il bouffe tout", "https://static.cnews.fr/sites/default/files/000_8vq76v_5fbcea50c8137.jpg", "Bouftou", 5 },
                    { 6, 2, "Une belle perruche dedju !", "https://www.fermeexotique.fr/public/img/medium/nos-animaux-afrique53eb4cd7bb705.jpg", "Parrot", 6 }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "Email", "Firstname", "Lastname", "Password" },
                values: new object[] { 1, "anthony.douchet@hotmail.fr", "Anthony", "DOUCHET", "UEFzczEyMyEhY2zDqSBzdXBlciBzZWNyw6h0ZQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Staffs");
        }
    }
}
