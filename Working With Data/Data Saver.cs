using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Working_With_Data
{
    public class User
    {
        //it can be null so we could transfer it from create form to data saver without knowing the id 
        public int? Id { get; set; }
        public String? Username { get; set; }
        public String? Password { get; set; }
    }
    public class Doctor:User
    {

    }
    public class Patient:User
    {

    }

    internal class Users
    {
        public List<User> userList = new List<User>();
    }
    public class Data_Saver
    {
        public void add_New_Doctor(Doctor newDoctor)
        {
            Users doctors;
            // Deserialize the existing XML file to a Doctors object
            using (FileStream stream = new FileStream("LoginDoctors.xml", FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Users));
                doctors = (Users)serializer.Deserialize(stream);
            }
            if (doctors != null)
            {
                newDoctor.Id = doctors.userList.Last().Id + 1;
            }
            else
            {
                newDoctor.Id = 0;
            }
            // Add new data to the Doctors object
            doctors.userList.Add(newDoctor);

            // Serialize the updated Doctors object back to the XML file
            using (FileStream stream = new FileStream("doctors.xml", FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Users));
                serializer.Serialize(stream, doctors);
            }
        }
    }
}
