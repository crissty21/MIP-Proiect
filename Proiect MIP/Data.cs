﻿
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
        private int? _id;
        private String _username = "";   
        private String _password = "";

        public int? Id { get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public String Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }
        public String Password { 
            get
            {
               return _password;  
            }
            set
            {
                _password = value;
            }
        }

    }
    public class User : UserLogin
    {
        private String _firstName = "";
        private String _lastName = "";
        public String FirstName { 
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }
        public String LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

    }
    public class Doctor : User
    {
        private string _specialization = "";
        public string Specialization { 
            get
            {
                return _specialization;
            }
            set
            {
                _specialization = value;
            }
        }
    }
    public class Patient : User
    {
        private String _CNP = "";
        public String CNP {
            get
            {
                return _CNP;
            }
            set
            {
                _CNP = value;
            }
        }
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
