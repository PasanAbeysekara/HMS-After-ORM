﻿using CommunityToolkit.Mvvm.ComponentModel;
using HMS.MVVM.Model;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HMS.MVVM.ViewModel
{
	public class UserPatientsVM : ObservableObject
	{
		private ObservableCollection<Patient> _patientData = new ObservableCollection<Patient>();


		public ObservableCollection<Patient> PatientData
		{
			get => _patientData;
			set
			{
				if (_patientData != value)
				{
					_patientData = value;
					OnPropertyChanged();
				}
			}
		}
		public void AddNewPatient(string fullName, string email, string birthDate, string phone, string bloodGroup, char gender, string address, double weight, double height)
		{
			var newPatient = new Patient
			{
				FullName = fullName,
				Email = email,
				BirthDay = birthDate,
				Phone = phone,
				BloodGroup = bloodGroup,
				Gender = gender,
				Address = address,
				Weight = weight,
				Height = height

			};

			PatientData.Add(newPatient);
		}
		private DelegateCommand _refreshListCommand;
		public DelegateCommand RefreshListCommand =>
			_refreshListCommand ?? (_refreshListCommand = new DelegateCommand(ExecuteRefreshListCommand));

		void ExecuteRefreshListCommand()
		{
			MessageBox.Show("You clicked refresh");
			Read();
		}

		// Delete patient command using prism core package
		private DelegateCommand<Patient> _deletePatientCommand;
		public DelegateCommand<Patient> DeletePatientCommand =>
			_deletePatientCommand ?? (_deletePatientCommand = new DelegateCommand<Patient>(ExecuteDeletePatientCommand));

		void ExecuteDeletePatientCommand(Patient parameter)
		{
			string deletedPatientName = "";
			using (DataContext context = new DataContext())
			{
				Patient selectedPatient = parameter;
				if (selectedPatient != null)
				{
					Patient pat = context.Patients.Single(x => x.Id == selectedPatient.Id);
					deletedPatientName = pat.FullName;
					context.Patients.Remove(pat);
					context.SaveChanges();
				}
			}
			MessageBox.Show($"Paitent '{deletedPatientName}' deleteed sucessfuly 😊 !");
			Read();
		}

		public UserPatientsVM()
		{
			//for (int i = 0; i < 10; i++)
			//{
			//	PatientData.Add(new Patient { FullName = "Saman Kumara", Email = "samankuamra@gmail.com", BirthDay = "24/10/2000", Phone = "0711234567", Gender = 'M', BloodGroup = "O+", Address = "No 69,Temple Road", Weight = 69, Height = 165 });
			//	PatientData.Add(new Patient { FullName = "Mala Smani", Email = "samalsamni@gmail.com", BirthDay = "12/11/2002", Phone = "075555555", Gender = 'F', BloodGroup = "A+", Address = "No 612,Cog Road", Weight = 54, Height = 140 });
			//}
			Read();

		}

		public void Read()
		{
			using (DataContext context = new DataContext())
			{
				//students = context.Students.ToList();
				_patientData.Clear();
				foreach (var std in context.Patients)
				{
					_patientData.Add(std);
				}
			}

		}

	}
}
