using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BootFlixBC9.Models
{
    public class AdultMembers : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //First we need to speak to a viewer object
            var viewer = (Viewer)validationContext.ObjectInstance;
            //Defensive programming > adding a static readonly/couldBconstant free & unknown to reach edge cases
            if (viewer.MembershipTypeId == MembershipType.Free ||
                viewer.MembershipTypeId == MembershipType.Unknown)

                return ValidationResult.Success;//ie. for the free membership is for all birthdates

            
            if (viewer.Birtdate == null)
                return new ValidationResult("Birthdate is Required");

            //Fourth
            var age = DateTime.Today.Year - viewer.Birtdate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Viewer must be an Adult");

            //default return base.IsValid(value, validationContext);
        }
    }
}