using HMS.MVVM.Model;
using HMS.MVVM.Model.InsidePrescription;
using HMS.MVVM.Model.InsidePrescription.insideDrug;
using HMS.MVVM.Model.InsidePrescription.insideTest;
using HMS.MVVM.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HMS
{
	/// <summary>
	/// Interaction logic for NormalUserWindow.xaml
	/// </summary>
	public partial class NormalUserWindow : Window
	{
		private void Border_Mousedown(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left)
			{
				this.DragMove();
			}
		}
		private bool isMaximized = false;
		private void Border_MouseLeftButtondown(object sender, MouseButtonEventArgs e)
		{
			if (e.ClickCount == 2)
			{
				if (isMaximized)
				{
					this.WindowState = WindowState.Normal;
					this.Width = 1080;
					this.Height = 720;

					isMaximized = false;
				}
				else
				{
					this.WindowState = WindowState.Maximized;
					isMaximized = true;
				}
			}
		}

		public NormalUserWindow()
		{
			DataContext = new NormalUserWindowVM();
			InitializeComponent();
		}

		private void AddMemberButton_Click(object sender, RoutedEventArgs e)
		{
			var window = new AddPatientWindow();
			window.Show();
		}

		private void CloseButton_Clicked(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void MinimizeButton_Clicked(object sender, RoutedEventArgs e)
		{
			WindowState = WindowState.Minimized;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{


			////Access a Bill object's related Patient details
			//using (var context = new DataContext())
			//{
			//	var bill = context.Bills.Include(b => b.Patient).FirstOrDefault();
			//	//Console.WriteLine("Bill Amount: {0}", bill.Amount);
			//	//Console.WriteLine("Patient Name: {0}", bill.Patient.Name);
			//	//Console.WriteLine("Patient Address: {0}", bill.Patient.Address);
			//	//Console.WriteLine("Patient Phone: {0}", bill.Patient.Phone);
			//	MessageBox.Show($"Bill Amount: {bill.BillAmount.ToString()} , Patient Name: {bill.Patient.FullName}, Patient Address: {bill.Patient.Address}, Patient Phone: {bill.Patient.Phone}");
			//}

			MessageBox.Show("clicked !!");
			Random random = new Random();

			//Create some dummy for bill data
			using (var context = new DataContext())
			{
				for (int i = 0; i < 4; i++)
				{
					// -----------DRUGS---------------

					string randomString1 = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 6).Select(s => s[random.Next(s.Length)]).ToArray());
					string randomString2 = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 6).Select(s => s[random.Next(s.Length)]).ToArray());
					Drug tmpDrug = new Drug { GenericName = randomString1, TradeName = randomString2 };
					context.Drugs.Add(tmpDrug);

					// -----------TESTS---------------

					string randomString3 = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 6).Select(s => s[random.Next(s.Length)]).ToArray());
					string randomString4 = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 20).Select(s => s[random.Next(s.Length)]).ToArray());
					int randomFee = random.Next(1, 10) * 100;
					Test tmptest = new Test { TestName = randomString3, Description = randomString4, Fee = randomFee };
					context.Tests.Add(tmptest);

					// -----------DOCTORS---------------

					int randomFee2 = random.Next(1, 10) * 100;
					string randomString5 = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 6).Select(s => s[random.Next(s.Length)]).ToArray());
					Doctor tmpDoc = new Doctor { Name = "Dr. " + randomString5, Fee = randomFee2 };
					context.Doctors.Add(tmpDoc);

				}
				context.SaveChanges();

				// -----------PATIENTS---------------
				for (int i = 0; i < 4; i++)
				{
					var patient = new Patient
					{
						FullName = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 4)
					  .Select(s => s[random.Next(s.Length)]).ToArray()),
						Email = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 4)
					  .Select(s => s[random.Next(s.Length)]).ToArray()) + "@gmail.com",
						BirthDay = "10/24/2000",
						Phone = "011" + new string(Enumerable.Repeat("0123456789", 7)
					  .Select(s => s[random.Next(s.Length)]).ToArray()),
						Gender = (random.Next(2) == 0) ? 'M' : 'F',
						BloodGroup = (random.Next(2) == 0) ? "O+" : "B+",
						Address = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 14)
					  .Select(s => s[random.Next(s.Length)]).ToArray()),
						Weight = random.Next(60, 100),
						Height = random.Next(150, 190),
						AdmittedDate = DateTime.Now.AddDays(random.Next(7))
					};

					context.Patients.Add(patient);
				}
				context.SaveChanges();

				// -----------PRESCRIPTIONS---------------
				for (int i = 0; i < 4; i++)
				{
					var presc = new Prescription
					{
						PrescribedDate = DateTime.Now.AddDays(random.Next(7, 14)),
						PatientId = context.Patients.ToList()[random.Next(context.Patients.Count())].Id
					};
					context.Prescriptions.Add(presc);
				}
				context.SaveChanges();


				// -----------APPOINTMENTS---------------
				for (int i = 0; i < 4; i++)
				{
					var app = new Appointment
					{
						AppointedDate = DateTime.Now.AddDays(random.Next(7)),
						DoctorId = context.Doctors.ToList()[random.Next(context.Doctors.Count())].Id,
						PatientId = context.Patients.ToList()[random.Next(context.Patients.Count())].Id
					};
					context.Appointments.Add(app);
				}
				context.SaveChanges();

				// -----------BILL---------------
				for (int i = 0; i < 4; i++)
				{
					var bill = new Bill
					{
						BillAmount = 6900,
						PaymentMode = "Cash",
						Status = true,
						PaymentDate = DateTime.Now.AddDays(random.Next(7, 14)),
						PatientId = context.Patients.ToList()[random.Next(context.Patients.Count())].Id
					};
					context.Bills.Add(bill);
				}
				context.SaveChanges();

				// -----------MEDICAL_TESTS---------------
				for (int i = 0; i < 4; i++)
				{
					var mTest = new MedicalTest
					{
						Description = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 14).Select(s => s[random.Next(s.Length)]).ToArray()),
						TestId = context.Tests.ToList()[random.Next(context.Tests.Count())].Id,
						PrescriptionId = context.Prescriptions.ToList()[random.Next(context.Prescriptions.Count())].Id
					};
					context.MedicalTests.Add(mTest);
				}
				context.SaveChanges();

				// -----------DOSAGES---------------
				for (int i = 0; i < 4; i++)
				{
					var _dosages = new Dosage
					{
						DrugType = (random.Next(2) == 0) ? "Syrup" : "Tablets",
						Dose = (random.Next(3)),
						Duration = random.Next(3, 14),
						Comments = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 10).Select(s => s[random.Next(s.Length)]).ToArray()),
						DrugId = context.Drugs.ToList()[random.Next(context.Drugs.Count())].Id,
						PrescriptionId = context.Prescriptions.ToList()[random.Next(context.Prescriptions.Count())].Id
					};
					context.Dosages.Add(_dosages);
				}
				context.SaveChanges();

			}

		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			//Random random = new Random();
			//using (var context = new DataContext())
			//{
			//	// -----------PATIENTS---------------
			//	for (int i = 0; i < 4; i++)
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
			//}

			MessageBox.Show("clickw");

			using(var context = new DataContext())
			{
				var t_docs = context.Doctors.ToList();
				var t_drugs = context.Drugs.ToList();
				var t_tests = context.Tests.ToList();
				var t_pats = context.Patients.ToList();
				var t_pres = context.Prescriptions.ToList();
				var t_apps = context.Appointments.ToList();
				var t_bills = context.Bills.ToList();
				var t_medTests = context.MedicalTests.ToList();
				var t_dosages = context.Dosages.ToList();

				foreach(var tmp in t_dosages)
				{
					context.Dosages.Remove(tmp);
				}
				context.SaveChanges();
				foreach (var tmp in t_medTests)
				{
					context.MedicalTests.Remove(tmp);
				}
				context.SaveChanges();
				foreach (var tmp in t_bills)
				{
					context.Bills.Remove(tmp);
				}
				context.SaveChanges();
				foreach (var tmp in t_apps)
				{
					context.Appointments.Remove(tmp);
				}
				context.SaveChanges();
				foreach (var tmp in t_pres)
				{
					context.Prescriptions.Remove(tmp);
				}
				context.SaveChanges();
				foreach (var tmp in t_pats)
				{
					context.Patients.Remove(tmp);
				}
				context.SaveChanges();
				foreach (var tmp in t_tests)
				{
					context.Tests.Remove(tmp);
				}
				context.SaveChanges();
				foreach (var tmp in t_drugs)
				{
					context.Drugs.Remove(tmp);
				}
				context.SaveChanges();
				foreach (var tmp in t_docs)
				{
					context.Doctors.Remove(tmp);
				}
				context.SaveChanges();


			}
		}
	}
}
