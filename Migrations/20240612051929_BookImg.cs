using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace toshokan.Migrations
{
    /// <inheritdoc />
    public partial class BookImg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loan_Book_BookID",
                table: "Loan");

            migrationBuilder.DropForeignKey(
                name: "FK_Loan_Member_MemberID",
                table: "Loan");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Book_BookID",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Member_MemberID",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "BookID",
                table: "Reservation",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_BookID",
                table: "Reservation",
                newName: "IX_Reservation_BookId");

            migrationBuilder.RenameColumn(
                name: "BookID",
                table: "Loan",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Loan_BookID",
                table: "Loan",
                newName: "IX_Loan_BookId");

            migrationBuilder.AlterColumn<int>(
                name: "MemberID",
                table: "Reservation",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Reservation",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "MemberID",
                table: "Loan",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Loan",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "imgURL",
                table: "Book",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Loan_Book_BookId",
                table: "Loan",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Loan_Member_MemberID",
                table: "Loan",
                column: "MemberID",
                principalTable: "Member",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Book_BookId",
                table: "Reservation",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Member_MemberID",
                table: "Reservation",
                column: "MemberID",
                principalTable: "Member",
                principalColumn: "MemberID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loan_Book_BookId",
                table: "Loan");

            migrationBuilder.DropForeignKey(
                name: "FK_Loan_Member_MemberID",
                table: "Loan");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Book_BookId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Member_MemberID",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "imgURL",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Reservation",
                newName: "BookID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_BookId",
                table: "Reservation",
                newName: "IX_Reservation_BookID");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Loan",
                newName: "BookID");

            migrationBuilder.RenameIndex(
                name: "IX_Loan_BookId",
                table: "Loan",
                newName: "IX_Loan_BookID");

            migrationBuilder.AlterColumn<int>(
                name: "MemberID",
                table: "Reservation",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookID",
                table: "Reservation",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MemberID",
                table: "Loan",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookID",
                table: "Loan",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Loan_Book_BookID",
                table: "Loan",
                column: "BookID",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loan_Member_MemberID",
                table: "Loan",
                column: "MemberID",
                principalTable: "Member",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Book_BookID",
                table: "Reservation",
                column: "BookID",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Member_MemberID",
                table: "Reservation",
                column: "MemberID",
                principalTable: "Member",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
