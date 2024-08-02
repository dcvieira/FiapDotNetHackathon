using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class alter_appointments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "AppointmentDateTime",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Appointments",
                newName: "AppointmentScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                newName: "IX_Appointments_AppointmentScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AvailableSchedules_AppointmentScheduleId",
                table: "Appointments",
                column: "AppointmentScheduleId",
                principalTable: "AvailableSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AvailableSchedules_AppointmentScheduleId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "AppointmentScheduleId",
                table: "Appointments",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_AppointmentScheduleId",
                table: "Appointments",
                newName: "IX_Appointments_DoctorId");

            migrationBuilder.AddColumn<DateTime>(
                name: "AppointmentDateTime",
                table: "Appointments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
