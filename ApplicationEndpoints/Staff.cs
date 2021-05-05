using System;

namespace ApplicationEndpoints
{
    public class Staff
    {

        public int id { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }
        public string emailId { get; set; }

        public string role { get; set; }

       public Staff()
        {

        }

        public Staff(int id, string firstname, string lastname, string emailId, string role)
        {
            this.id = id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.emailId = emailId;
            this.role = role;


        }
    }
}
