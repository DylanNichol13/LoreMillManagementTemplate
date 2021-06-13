using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoreMill
{
    public class Profile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }

        public Profile(string firstName, string lastName, DateTime dateofBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateofBirth;
            Age = GetAge(dateofBirth);
        }

        private int GetAge(DateTime dateOfBirth)
        {
            int years = DateTime.Today.Year - dateOfBirth.Year;
            years = dateOfBirth.Date > DateTime.Today.AddYears(-years) ? years - 1 : years;
            return years;
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public string GetDobAge()
        {
            return $"{Age} years old ({DateOfBirth.ToString("dd/MM/yyyy")})";
        }
    }
}