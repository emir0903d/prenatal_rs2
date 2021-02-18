using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prenatal.webapi.Database
{
    public class DbInit
    {
        public static void Seed(Context context)
        {
            AddAppointments(context);
            AddVitalSigns(context);
            AddUltrasounds(context);
            AddTherapies(context);
            AddSubstances(context);
            AddReferrals(context);
            AddPreviousPregnancies(context);
            AddPrescriptions(context);
            context.Dispose();
        }
        public static void AddAppointments(Context context)
        {
            if (context.Appointments.ToList().Count() > 0) return;

            Users myDoc = context.Users.AsQueryable().Where(x => x.Username == "doctor").SingleOrDefault();
            Users myPat = context.Users.AsQueryable().Where(x => x.Username == "patient").SingleOrDefault();

            context.Appointments.AddRange(
                
                new Appointments { DoctorId = myDoc.Id, PatientId = myPat.Id, Date = new DateTime(2021,2,20,8,0,0,0), Time = new DateTime(2021, 2, 20, 8, 0, 0, 0), Note = "Test data", Status = Appointments.SlotStatus.Reserved },
                new Appointments { DoctorId = myDoc.Id, PatientId = myPat.Id, Date = new DateTime(2021, 2, 20, 8, 0, 0, 0), Time = new DateTime(2021, 2, 20, 8, 0, 0, 0), Note = "Test data", Status = Appointments.SlotStatus.Reserved },
                new Appointments { DoctorId = myDoc.Id, PatientId = myPat.Id, Date = new DateTime(2021, 2, 20, 9, 0, 0, 0), Time = new DateTime(2021, 2, 20, 9, 0, 0, 0), Note = "Test data", Status = Appointments.SlotStatus.Reserved },
                new Appointments { DoctorId = myDoc.Id, PatientId = myPat.Id, Date = new DateTime(2021, 2, 20, 10, 0, 0, 0), Time = new DateTime(2021, 2, 20, 10, 0, 0, 0), Note = "Test data", Status = Appointments.SlotStatus.Reserved },
                new Appointments { DoctorId = myDoc.Id, PatientId = myPat.Id, Date = new DateTime(2021, 2, 20, 11, 0, 0, 0), Time = new DateTime(2021, 2, 20, 11, 0, 0, 0), Note = "Test data", Status = Appointments.SlotStatus.Reserved },
                new Appointments { DoctorId = myDoc.Id, PatientId = myPat.Id, Date = new DateTime(2021, 2, 20, 14, 0, 0, 0), Time = new DateTime(2021, 2, 20, 14, 0, 0, 0), Note = "Test data", Status = Appointments.SlotStatus.Reserved },
                new Appointments { DoctorId = myDoc.Id, PatientId = myPat.Id, Date = new DateTime(2021, 2, 20, 15, 0, 0, 0), Time = new DateTime(2021, 2, 20, 15, 0, 0, 0), Note = "Test data", Status = Appointments.SlotStatus.Reserved },
                new Appointments { DoctorId = myDoc.Id, PatientId = myPat.Id, Date = new DateTime(2021, 2, 20, 16, 0, 0, 0), Time = new DateTime(2021, 2, 20, 16, 0, 0, 0), Note = "Test data", Status = Appointments.SlotStatus.Reserved }        

                );
            context.SaveChanges();
            
            
        }
        public static void AddVitalSigns(Context context)
        {
            if (context.VitalSigns.ToList().Count() > 0) return;
            Users myPat = context.Users.AsQueryable().Where(x => x.Username == "patient").SingleOrDefault();

            context.VitalSigns.AddRange(
                new VitalSigns { MedicalRecordsId = myPat.Id, Date = DateTime.Today.AddMonths(-1), Height = 173.5F, Weight = 77.9F, Temperature = 37.5F, DiastolicPressure = 110, SystolicPressure = 90, HeartBeats = 99, RespiratoryRate = 79, Note = "Test data" },
                new VitalSigns { MedicalRecordsId = myPat.Id, Date = DateTime.Today.AddMonths(-2), Height = 173.5F, Weight = 77.9F, Temperature = 37.5F, DiastolicPressure = 110, SystolicPressure = 90, HeartBeats = 99, RespiratoryRate = 79, Note = "Test data" },
                new VitalSigns { MedicalRecordsId = myPat.Id, Date = DateTime.Today.AddMonths(-3), Height = 173.5F, Weight = 77.9F, Temperature = 37.5F, DiastolicPressure = 110, SystolicPressure = 90, HeartBeats = 99, RespiratoryRate = 79, Note = "Test data" },
                new VitalSigns { MedicalRecordsId = myPat.Id, Date = DateTime.Today.AddMonths(-4), Height = 173.5F, Weight = 77.9F, Temperature = 37.5F, DiastolicPressure = 110, SystolicPressure = 90, HeartBeats = 99, RespiratoryRate = 79, Note = "Test data" },
                new VitalSigns { MedicalRecordsId = myPat.Id, Date = DateTime.Today.AddMonths(-5), Height = 173.5F, Weight = 77.9F, Temperature = 37.5F, DiastolicPressure = 110, SystolicPressure = 90, HeartBeats = 99, RespiratoryRate = 79, Note = "Test data" },
                new VitalSigns { MedicalRecordsId = myPat.Id, Date = DateTime.Today.AddMonths(-6), Height = 173.5F, Weight = 77.9F, Temperature = 37.5F, DiastolicPressure = 110, SystolicPressure = 90, HeartBeats = 99, RespiratoryRate = 79, Note = "Test data" },
                new VitalSigns { MedicalRecordsId = myPat.Id, Date = DateTime.Today.AddMonths(-7), Height = 173.5F, Weight = 77.9F, Temperature = 37.5F, DiastolicPressure = 110, SystolicPressure = 90, HeartBeats = 99, RespiratoryRate = 79, Note = "Test data" },
                new VitalSigns { MedicalRecordsId = myPat.Id, Date = DateTime.Today.AddMonths(-8), Height = 173.5F, Weight = 77.9F, Temperature = 37.5F, DiastolicPressure = 110, SystolicPressure = 90, HeartBeats = 99, RespiratoryRate = 79, Note = "Test data" },
                new VitalSigns { MedicalRecordsId = myPat.Id, Date = DateTime.Today.AddMonths(-9), Height = 173.5F, Weight = 77.9F, Temperature = 37.5F, DiastolicPressure = 110, SystolicPressure = 90, HeartBeats = 99, RespiratoryRate = 79, Note = "Test data" },
                new VitalSigns { MedicalRecordsId = myPat.Id, Date = DateTime.Today.AddMonths(-10), Height = 173.5F, Weight = 78.9F, Temperature = 39.5F, DiastolicPressure = 90, SystolicPressure = 56, HeartBeats = 39, RespiratoryRate = 39, Note = "Test data" }
                );
            context.SaveChanges();
        }
        public static void AddUltrasounds(Context context)
        {
            if (context.Ultrasounds.ToList().Count() > 0) return;
            Users myPat = context.Users.AsQueryable().Where(x => x.Username == "patient").SingleOrDefault();

            context.Ultrasounds.AddRange(
                new Ultrasounds { MedicalRecordsId=myPat.Id, Note="Test data", NuchalScan=false, Movement=true, Length=110F, HeartBeats=110, HeadDiameter=10.787F, HeadCircumference=17.981F, FemurLength=47.76F, Anomalies=false, AbdominalCircumference=1.987F, Date=DateTime.Now.AddMonths(-10)},
                new Ultrasounds { MedicalRecordsId = myPat.Id, Note = "Test data", NuchalScan = false, Movement = true, Length = 110F, HeartBeats = 110, HeadDiameter = 10.787F, HeadCircumference = 17.981F, FemurLength = 47.76F, Anomalies = false, AbdominalCircumference = 1.987F, Date = DateTime.Now.AddMonths(-8) },
                new Ultrasounds { MedicalRecordsId = myPat.Id, Note = "Test data", NuchalScan = false, Movement = true, Length = 110F, HeartBeats = 110, HeadDiameter = 10.787F, HeadCircumference = 17.981F, FemurLength = 47.76F, Anomalies = false, AbdominalCircumference = 1.987F, Date = DateTime.Now.AddMonths(-7) },
                new Ultrasounds { MedicalRecordsId = myPat.Id, Note = "Test data", NuchalScan = false, Movement = true, Length = 110F, HeartBeats = 110, HeadDiameter = 10.787F, HeadCircumference = 17.981F, FemurLength = 47.76F, Anomalies = false, AbdominalCircumference = 1.987F, Date = DateTime.Now.AddMonths(-6) },
                new Ultrasounds { MedicalRecordsId = myPat.Id, Note = "Test data", NuchalScan = false, Movement = true, Length = 110F, HeartBeats = 110, HeadDiameter = 10.787F, HeadCircumference = 17.981F, FemurLength = 47.76F, Anomalies = false, AbdominalCircumference = 1.987F, Date = DateTime.Now.AddMonths(-5) },
                new Ultrasounds { MedicalRecordsId = myPat.Id, Note = "Test data", NuchalScan = false, Movement = true, Length = 110F, HeartBeats = 110, HeadDiameter = 10.787F, HeadCircumference = 17.981F, FemurLength = 47.76F, Anomalies = false, AbdominalCircumference = 1.987F, Date = DateTime.Now.AddMonths(-4) },
                new Ultrasounds { MedicalRecordsId = myPat.Id, Note = "Test data", NuchalScan = false, Movement = true, Length = 110F, HeartBeats = 110, HeadDiameter = 10.787F, HeadCircumference = 17.981F, FemurLength = 47.76F, Anomalies = false, AbdominalCircumference = 1.987F, Date = DateTime.Now.AddMonths(-3) },
                new Ultrasounds { MedicalRecordsId = myPat.Id, Note = "Test data", NuchalScan = false, Movement = true, Length = 110F, HeartBeats = 110, HeadDiameter = 10.787F, HeadCircumference = 17.981F, FemurLength = 47.76F, Anomalies = false, AbdominalCircumference = 1.987F, Date = DateTime.Now.AddMonths(-2) },
                new Ultrasounds { MedicalRecordsId = myPat.Id, Note = "Test data", NuchalScan = false, Movement = true, Length = 110F, HeartBeats = 110, HeadDiameter = 10.787F, HeadCircumference = 17.981F, FemurLength = 47.76F, Anomalies = false, AbdominalCircumference = 1.987F, Date = DateTime.Now.AddMonths(-1) },
                new Ultrasounds { MedicalRecordsId = myPat.Id, Note = "Test data", NuchalScan = false, Movement = true, Length = 110F, HeartBeats = 110, HeadDiameter = 10.787F, HeadCircumference = 17.981F, FemurLength = 47.76F, Anomalies = false, AbdominalCircumference = 1.987F, Date = DateTime.Now.AddMonths(-9) }

                );
            context.SaveChanges();
        }
        public static void AddTherapies(Context context)
        {
            if (context.Therapies.ToList().Count() > 0) return;
            Users myPat = context.Users.AsQueryable().Where(x => x.Username == "patient").SingleOrDefault();

            context.Therapies.AddRange(
                new Therapies {MedicalRecordsId=myPat.Id, BeginningDate=DateTime.Now.AddMonths(-9), EndingDate=DateTime.Now, Medicaments="Medicaments 01", Note="Test data"},
                new Therapies { MedicalRecordsId = myPat.Id, BeginningDate = DateTime.Now.AddMonths(-9), EndingDate = DateTime.Now, Medicaments = "Medicaments 01", Note = "Test data" },
                new Therapies { MedicalRecordsId = myPat.Id, BeginningDate = DateTime.Now.AddMonths(-9), EndingDate = DateTime.Now, Medicaments = "Medicaments 02", Note = "Test data" },
                new Therapies { MedicalRecordsId = myPat.Id, BeginningDate = DateTime.Now.AddMonths(-9), EndingDate = DateTime.Now, Medicaments = "Medicaments 03", Note = "Test data" },
                new Therapies { MedicalRecordsId = myPat.Id, BeginningDate = DateTime.Now.AddMonths(-9), EndingDate = DateTime.Now, Medicaments = "Medicaments 04", Note = "Test data" }
                );

            context.SaveChanges();
        }
        public static void AddSubstances(Context context)
        {
            if (context.SubstancesUse.ToList().Count() > 0) return;
            Users myPat = context.Users.AsQueryable().Where(x => x.Username == "patient").SingleOrDefault();

            context.SubstancesUse.AddRange(
                new SubstancesUse { MedicalRecordsId = myPat.Id, Description="Tabacco", NumberOfYears=10, PriorToPregnancy=false, StillUsing=false, Note="Test data"},
                new SubstancesUse { MedicalRecordsId = myPat.Id, Description = "Alcohol", NumberOfYears = 10, PriorToPregnancy = false, StillUsing = false, Note = "Test data" },
                new SubstancesUse { MedicalRecordsId = myPat.Id, Description = "MDMA", NumberOfYears = 10, PriorToPregnancy = false, StillUsing = false, Note = "Test data" }
                );

            context.SaveChanges();
        }
        public static void AddReferrals(Context context)
        {
            if (context.Referrals.ToList().Count() > 0) return;
            Users myPat = context.Users.AsQueryable().Where(x => x.Username == "patient").SingleOrDefault();

            context.Referrals.AddRange(
                new Referrals { MedicalRecordsId=myPat.Id, Note="Test data", Facility="KCUCS", Date=DateTime.Now.AddMonths(-9), Description="TO-DO-EXAM01"},
                new Referrals { MedicalRecordsId = myPat.Id, Note = "Test data", Facility = "KCUCS", Date = DateTime.Now.AddMonths(-9), Description = "TO-DO-EXAM02" },
                new Referrals { MedicalRecordsId = myPat.Id, Note = "Test data", Facility = "KCUCS", Date = DateTime.Now.AddMonths(-9), Description = "TO-DO-EXAM03" },
                new Referrals { MedicalRecordsId = myPat.Id, Note = "Test data", Facility = "KCUCS", Date = DateTime.Now.AddMonths(-9), Description = "TO-DO-EXAM04" },
                new Referrals { MedicalRecordsId = myPat.Id, Note = "Test data", Facility = "KCUCS", Date = DateTime.Now.AddMonths(-9), Description = "TO-DO-EXAM05" },
                new Referrals { MedicalRecordsId = myPat.Id, Note = "Test data", Facility = "KCUCS", Date = DateTime.Now.AddMonths(-9), Description = "TO-DO-EXAM06" },
                new Referrals { MedicalRecordsId = myPat.Id, Note = "Test data", Facility = "KCUCS", Date = DateTime.Now.AddMonths(-9), Description = "TO-DO-EXAM07" },
                new Referrals { MedicalRecordsId = myPat.Id, Note = "Test data", Facility = "KCUCS", Date = DateTime.Now.AddMonths(-9), Description = "TO-DO-EXAM08" },
                new Referrals { MedicalRecordsId = myPat.Id, Note = "Test data", Facility = "KCUCS", Date = DateTime.Now.AddMonths(-9), Description = "TO-DO-EXAM09" }
                );

            context.SaveChanges();
        }
        public static void AddPreviousPregnancies(Context context)
        {
            if (context.PreviousPregnancies.ToList().Count() > 0) return;
            Users myPat = context.Users.AsQueryable().Where(x => x.Username == "patient").SingleOrDefault();

            context.PreviousPregnancies.AddRange(
                new PreviousPregnancies {MedicalRecordsId=myPat.Id, PregnancyDate=DateTime.Now.AddYears(-7), Complications="None", DeliveryType="Normal", GestationWeeks=9, Outcome="Boy"},
                new PreviousPregnancies { MedicalRecordsId = myPat.Id, PregnancyDate = DateTime.Now.AddYears(-4), Complications = "None", DeliveryType = "Normal", GestationWeeks = 9, Outcome = "Boy" },
                new PreviousPregnancies { MedicalRecordsId = myPat.Id, PregnancyDate = DateTime.Now.AddYears(-2), Complications = "None", DeliveryType = "Normal", GestationWeeks = 9, Outcome = "Girl" }
                );
            context.SaveChanges();
        }
        public static void AddPrescriptions(Context context)
        {
            if (context.Prescriptions.ToList().Count() > 0) return;
            Users myPat = context.Users.AsQueryable().Where(x => x.Username == "patient").SingleOrDefault();

            context.Prescriptions.AddRange(
                new Prescriptions { MedicalRecordsId=myPat.Id, Date=DateTime.Now.AddMonths(-3), Description="Antibiotics", Dose="10mg", Usage="1x1", Note="Test Data"},
                new Prescriptions { MedicalRecordsId = myPat.Id, Date = DateTime.Now.AddMonths(-6), Description = "Antibiotics", Dose = "10mg", Usage = "1x1", Note = "Test Data" },
                new Prescriptions { MedicalRecordsId = myPat.Id, Date = DateTime.Now.AddMonths(-7), Description = "Probiotics", Dose = "10mg", Usage = "1x1", Note = "Test Data" },
                new Prescriptions { MedicalRecordsId = myPat.Id, Date = DateTime.Now.AddMonths(-9), Description = "Herbs", Dose = "10mg", Usage = "1x1", Note = "Test Data" },
                new Prescriptions { MedicalRecordsId = myPat.Id, Date = DateTime.Now.AddMonths(-11), Description = "Bla bla bla", Dose = "10mg", Usage = "1x1", Note = "Test Data" }
                );

            context.SaveChanges();
        }


    }
}
