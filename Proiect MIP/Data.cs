
using Proiect_MIP;
using System.Xml.Serialization;

namespace Working_With_Data
{
    internal static class Files
    {
        internal const string DoctorLogingFile = "doctorLogin.xml";
        internal const string DoctorInfosFile = "doctorInfos.xml";
        internal const string PatientLogingFile = "patientLogin.xml";
        internal const string PatientInfosFile = "patientInfos.xml";
    }
    [Serializable]
    public class UserLogin
    {
        //it can be null so we could transfer it from create form to data saver without knowing the id 
        public int? Id { get; set; }
        public String? Username { get; set; }
        public String? Password { get; set; }
    }
    public class User : UserLogin
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }

    }
    public class Doctor : User
    {
        public string Specialization { get; set; }
    }
    public class Patient : User
    {
        public String CNP { get; set; }
        public List<int> Apointments = new List<int>();
    }
    [Serializable]
    public class Users
    {
        public List<UserLogin> userList = new List<UserLogin>();
        public int nextID = 0;
    }
    public static class Data
    {
        internal static Users Read_Login(Tip type)
        {
            Users? users = new Users();
            XmlSerializer serializer = new XmlSerializer(typeof(Users));
            FileStream? stream = null;

            // Deserialize the existing XML file to a Doctor object
            try
            {
                if (type == Tip.Doctor)
                {
                    stream = new FileStream(Files.DoctorLogingFile, FileMode.Open);
                }
                else
                {
                    stream = new FileStream(Files.PatientLogingFile, FileMode.Open);
                }
                users = (Users?)serializer.Deserialize(stream);
            }
            //we do this catch in case the file does not exist yet
            catch (Exception e)
            {
                if((FileNotFoundException)e != null)
                {
                    //in the case we don't have the desired file, we initiate the users with a blank list
                    users = new Users();
                }
                else
                {
                    throw;
                }
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
            if(users == null)
            {
                users = new Users();
            }
            return users;
        }
        
        internal static List<Doctor> read_Doctor_info()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Doctor>));
            List<Doctor>? doctors;
            FileStream? stream = null;
            // Deserialize the existing XML file to a Doctor object
            try
            {
                stream = new FileStream(Files.DoctorInfosFile, FileMode.Open);
                doctors = (List<Doctor>?)serializer.Deserialize(stream);
            }
            catch (Exception e)
            {
                if ((FileNotFoundException)e != null)
                {
                    //in the case we don't have the desired file, we initiate the doctors with a blank list
                    doctors = new List<Doctor>();
                }
                else
                {
                    throw;
                }
            }
            finally
            {
                if (stream != null)
                {
                    //make sure to close the file
                    stream.Close();
                }
            }
            if (doctors == null)
            {
                doctors = new List<Doctor>();
            }
            return doctors;
        }
        internal static List<Patient> read_Patient_info()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Patient>));
            List<Patient>? patients = new List<Patient>();
            FileStream? stream = null;
            // Deserialize the existing XML file to a Doctor object
            try
            {
                stream = new FileStream(Files.PatientInfosFile, FileMode.Open);
                patients = (List<Patient>?)serializer.Deserialize(stream);
            }
            catch (Exception e)
            {
                if ((FileNotFoundException)e != null)
                {
                    //in the case we don't have the desired file, we initiate the patients with a blank list
                    patients = new List<Patient>();
                }
                else
                {
                    throw;
                }
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
            if(patients == null)
            {
                patients = new List<Patient>();
            }
            return patients;
        }
    }
}
