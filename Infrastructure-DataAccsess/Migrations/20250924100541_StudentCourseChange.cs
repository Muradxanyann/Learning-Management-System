using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure___Persistence.Migrations
{
    /// <inheritdoc />
    public partial class StudentCourseChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_student_course_students_student_id",
                table: "student_course");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropPrimaryKey(
                name: "pk_student_course",
                table: "student_course");

            migrationBuilder.DropIndex(
                name: "ix_student_course_student_id",
                table: "student_course");

            migrationBuilder.DropColumn(
                name: "full_name",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "student_id",
                table: "student_course",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_student_course",
                table: "student_course",
                columns: new[] { "student_id", "course_id" });

            migrationBuilder.CreateIndex(
                name: "ix_student_course_course_id",
                table: "student_course",
                column: "course_id");

            migrationBuilder.AddForeignKey(
                name: "fk_student_course_users_student_id",
                table: "student_course",
                column: "student_id",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_student_course_users_student_id",
                table: "student_course");

            migrationBuilder.DropPrimaryKey(
                name: "pk_student_course",
                table: "student_course");

            migrationBuilder.DropIndex(
                name: "ix_student_course_course_id",
                table: "student_course");

            migrationBuilder.AlterColumn<Guid>(
                name: "student_id",
                table: "student_course",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "full_name",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_student_course",
                table: "student_course",
                columns: new[] { "course_id", "student_id" });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    student_id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    student_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_students", x => x.student_id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_student_course_student_id",
                table: "student_course",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "ix_students_email",
                table: "students",
                column: "email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_student_course_students_student_id",
                table: "student_course",
                column: "student_id",
                principalTable: "students",
                principalColumn: "student_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
