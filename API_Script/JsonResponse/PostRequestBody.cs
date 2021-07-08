using System;


namespace API_Script.JsonResponse
{
   public class PostRequestBody
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Title { get; set; }
        public string TSARedress { get; set; }
        public string PassportIssuingCountryCode { get; set; }
        public int Gender { get; set; }
        //public string PassportNumber { get; set; }
        public String DOB { get; set; }
    }
}
