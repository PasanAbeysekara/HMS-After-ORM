using HMS.MVVM.Model.InsidePrescription.insideTest;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.MVVM.Model.InsidePrescription
{
	public class Test
	{
		[Key]
		public int Id { get; set; }
		public string? TestName { get; set; }
		public string? Description { get; set; }
		public double Fee { get; set; }

		// Navigation property for the related Bill object
		public virtual MedicalTest? MedicalTest { get; set; }
	}
}
