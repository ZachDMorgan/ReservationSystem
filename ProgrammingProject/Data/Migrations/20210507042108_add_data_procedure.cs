using Microsoft.EntityFrameworkCore.Migrations;

namespace ProgrammingProject.Data.Migrations
{
    public partial class add_data_procedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[SetInitialData]
	@RestaurantName Varchar(50)
AS
BEGIN
SET NOCOUNT ON;
--Make a restaurant
INSERT INTO Restaurants(Name)
Values(@RestaurantName);

--Make unassigned table area
INSERT INTO Areas(Name, RestaurantId)
Values('UNASSIGNED', 1);

--Make Reservation Statuses
INSERT INTO ReservationStatuses(Description)
Values('Pending');
INSERT INTO ReservationStatuses(Description)
Values('Confirmed');
INSERT INTO ReservationStatuses(Description)
Values('Seated');
INSERT INTO ReservationStatuses(Description)
Values('Completed');
INSERT INTO ReservationStatuses(Description)
Values('Cancelled');

--Make reservation sources
INSERT INTO ReservationSources(Description)
Values('Website');
INSERT INTO ReservationSources(Description)
Values('Phone');
INSERT INTO ReservationSources(Description)
Values('Email');
INSERT INTO ReservationSources(Description)
Values('Walk-in')
INSERT INTO ReservationSources(Description)
Values('App-Phone');
INSERT INTO ReservationSources(Description)
Values('Other');
END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
