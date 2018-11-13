namespace ElectronicRX2._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Prescriptions", name: "Doctor_ID", newName: "DoctorId");
            RenameColumn(table: "dbo.Prescriptions", name: "Patient_ID", newName: "PatientId");
            RenameColumn(table: "dbo.Prescriptions", name: "Pharmacy_ID", newName: "PharmacyId");
            RenameIndex(table: "dbo.Prescriptions", name: "IX_Patient_ID", newName: "IX_PatientId");
            RenameIndex(table: "dbo.Prescriptions", name: "IX_Pharmacy_ID", newName: "IX_PharmacyId");
            RenameIndex(table: "dbo.Prescriptions", name: "IX_Doctor_ID", newName: "IX_DoctorId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Prescriptions", name: "IX_DoctorId", newName: "IX_Doctor_ID");
            RenameIndex(table: "dbo.Prescriptions", name: "IX_PharmacyId", newName: "IX_Pharmacy_ID");
            RenameIndex(table: "dbo.Prescriptions", name: "IX_PatientId", newName: "IX_Patient_ID");
            RenameColumn(table: "dbo.Prescriptions", name: "PharmacyId", newName: "Pharmacy_ID");
            RenameColumn(table: "dbo.Prescriptions", name: "PatientId", newName: "Patient_ID");
            RenameColumn(table: "dbo.Prescriptions", name: "DoctorId", newName: "Doctor_ID");
        }
    }
}
