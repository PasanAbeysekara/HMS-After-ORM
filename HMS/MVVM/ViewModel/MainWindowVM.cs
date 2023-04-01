using HMS.MVVM.Model;
using HMS.MVVM.Model.InsidePrescription;
using HMS.MVVM.Model.InsidePrescription.insideDrug;
using HMS.MVVM.Model.InsidePrescription.insideTest;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HMS.MVVM.ViewModel
{
	public class MainWindowVM
	{
		public MainWindowVM()
		{
			Random random = new Random();

			// Create some dummy for bill data
			//using (var context = new DataContext())
			//{
			//	for (int i = 0; i < 4; i++)
			//	{
			//		// -----------DRUGS---------------

			//		string randomString1 = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 6).Select(s => s[random.Next(s.Length)]).ToArray());
			//		string randomString2 = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 6).Select(s => s[random.Next(s.Length)]).ToArray());
			//		Drug tmpDrug = new Drug { GenericName = randomString1, TradeName = randomString2 };
			//		context.Drugs.Add(tmpDrug);

			//		// -----------TESTS---------------

			//		string randomString3 = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 6).Select(s => s[random.Next(s.Length)]).ToArray());
			//		string randomString4 = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 20).Select(s => s[random.Next(s.Length)]).ToArray());
			//		int randomFee = random.Next(1, 10) * 100;
			//		Test tmptest = new Test { TestName = randomString3, Description = randomString4, Fee = randomFee };
			//		context.Tests.Add(tmptest);

			//		// -----------DOCTORS---------------

			//		int randomFee2 = random.Next(1, 10) * 100;
			//		string randomString5 = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 6).Select(s => s[random.Next(s.Length)]).ToArray());
			//		Doctor tmpDoc = new Doctor { Name = "Dr. " + randomString5, Fee = randomFee2 };
			//		context.Doctors.Add(tmpDoc);

			//	}
			//	context.SaveChanges();

			//	// -----------PATIENTS---------------
			//	for(int i = 0; i < 4; i++)
			//	{
			//		var patient = new Patient
			//		{
			//			FullName = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 4)
			//		  .Select(s => s[random.Next(s.Length)]).ToArray()),
			//			Email = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 4)
			//		  .Select(s => s[random.Next(s.Length)]).ToArray()) + "@gmail.com",
			//			BirthDay = "10/24/2000",
			//			Phone = "011" + new string(Enumerable.Repeat("0123456789", 7)
			//		  .Select(s => s[random.Next(s.Length)]).ToArray()),
			//			Gender = (random.Next(2) == 0) ? 'M' : 'F',
			//			BloodGroup = (random.Next(2) == 0) ? "O+" : "B+",
			//			Address = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 14)
			//		  .Select(s => s[random.Next(s.Length)]).ToArray()),
			//			Weight = random.Next(60, 100),
			//			Height = random.Next(150, 190),
			//			AdmittedDate = DateTime.Now.AddDays(random.Next(7))
			//		};

			//		context.Patients.Add(patient);
			//	}
			//	context.SaveChanges();

			//	// -----------PRESCRIPTIONS---------------
			//	for (int i = 0; i < 4; i++)
			//	{
			//		var presc = new Prescription
			//		{
			//			PrescribedDate = DateTime.Now.AddDays(random.Next(7, 14)),
			//			PatientId = context.Patients.ToList()[random.Next(context.Patients.Count())].Id
			//		};
			//		context.Prescriptions.Add(presc);
			//	}
			//	context.SaveChanges();


			//	// -----------APPOINTMENTS---------------
			//	for (int i = 0; i < 4; i++)
			//	{
			//		var app = new Appointment
			//		{
			//			AppointedDate = DateTime.Now.AddDays(random.Next(7)),
			//			DoctorId = context.Doctors.ToList()[random.Next(context.Doctors.Count())].Id,
			//			PatientId = context.Patients.ToList()[random.Next(context.Patients.Count())].Id
			//		};
			//		context.Appointments.Add(app);
			//	}
			//	context.SaveChanges();

			//	// -----------BILL---------------
			//	for (int i = 0; i < 4; i++)
			//	{
			//		var bill = new Bill
			//		{
			//			BillAmount = 6900,
			//			PaymentMode = "Cash",
			//			Status = true,
			//			PaymentDate = DateTime.Now.AddDays(random.Next(7, 14)),
			//			PatientId = context.Patients.ToList()[random.Next(context.Patients.Count())].Id
			//		};
			//		context.Bills.Add(bill);
			//	}
			//	context.SaveChanges();

			//	// -----------MEDICAL_TESTS---------------
			//	for (int i = 0; i < 4; i++)
			//	{
			//		var mTest = new MedicalTest
			//		{
			//			Description = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 14).Select(s => s[random.Next(s.Length)]).ToArray()),
			//			TestId = context.Tests.ToList()[random.Next(context.Tests.Count())].Id,
			//			PrescriptionId = context.Prescriptions.ToList()[random.Next(context.Prescriptions.Count())].Id
			//		};
			//		context.MedicalTests.Add(mTest);
			//	}
			//	context.SaveChanges();

			//	// -----------DOSAGES---------------
			//	for (int i = 0; i < 4; i++)
			//	{
			//		var _dosages = new Dosage
			//		{
			//			DrugType = (random.Next(2) == 0) ? "Syrup" : "Tablets",
			//			Dose = (random.Next(3)),
			//			Duration = random.Next(3, 14),
			//			Comments = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 10).Select(s => s[random.Next(s.Length)]).ToArray()),
			//			DrugId = context.Drugs.ToList()[random.Next(context.Drugs.Count())].Id,
			//			PrescriptionId = context.Prescriptions.ToList()[random.Next(context.Prescriptions.Count())].Id
			//		};
			//		context.Dosages.Add(_dosages);
			//	}
			//	context.Savanges();

			//}

			// Access a Bill object's related Patient details
			//using (var context = new DataContext())
			//{
			//	var bill = context.Bills.Include(b => b.Patient).FirstOrDefault();
			//	//Console.WriteLine("Bill Amount: {0}", bill.Amount);
			//	//Console.WriteLine("Patient Name: {0}", bill.Patient.Name);
			//	//Console.WriteLine("Patient Address: {0}", bill.Patient.Address);
			//	//Console.WriteLine("Patient Phone: {0}", bill.Patient.Phone);
			//	MessageBox.Show($"Bill Amount: {0} , Patient Name: {1}, Patient Address: {2}, Patient Phone: {3}", bill.BillAmount.ToString(), bill.Patient.FullName, bill.Patient.Address, bill.Patient.Phone);
			//}

		}
	}
}
