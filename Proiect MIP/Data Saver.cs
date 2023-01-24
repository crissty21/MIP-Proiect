using Proiect_MIP;
using System.Xml.Serialization;

namespace Working_With_Data
{
    public class Data_Saver
    {
        public static void add_New_Doctor_Login(Doctor newDoctor)
        {
            try
            {
                Users doctors = Data.Read_Login(Tip.Doctor);
                //this id will be visible outside 
                newDoctor.Id = doctors.nextID;

                //add the new doctor to the user list
                doctors.userList.Add(new UserLogin() { Id = doctors.nextID++, Username = newDoctor.Username, Password = newDoctor.Password });

                //we clear the password so it stays in doctorLogin.xml only
                newDoctor.Password = null;

                // Serialize the updated Doctor object back to the XML file
                using (FileStream stream = new FileStream(Files.DoctorLogingFile, FileMode.Create))
                {
                    XmlSerializer serializer = serializer = new XmlSerializer(typeof(Users));
                    serializer.Serialize(stream, doctors);
                    stream.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void add_New_Doctor_infos(Doctor newDoctor)
        {
            try
            {
                List<Doctor> doctors = Data.read_Doctor_info();

                doctors.Add(newDoctor);

                // Serialize the updated Doctor object back to the XML file
                using (FileStream stream = new FileStream(Files.DoctorInfosFile, FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Doctor>));
                    serializer.Serialize(stream, doctors);
                    stream.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void add_New_Patient_Login(Patient newPatient)
        {
            try
            {
                Users patients = Data.Read_Login(Tip.Patient);

                //this id will be visible outside 
                newPatient.Id = patients.nextID;
                patients.userList.Add(new UserLogin() { Id = patients.nextID, Username = newPatient.Username, Password = newPatient.Password });
                patients.nextID++;
                //we clear the password so it stays in doctorLogin.xml only
                newPatient.Password = null;

                // Serialize the updated Doctor object back to the XML file
                using (FileStream stream = new FileStream(Files.PatientLogingFile, FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Users)); 
                    serializer.Serialize(stream, patients);
                    stream.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void add_New_Patient_infos(Patient newPatient)
        {
            try
            {
                List<Patient> patients = Data.read_Patient_info();

                patients.Add(newPatient);

                // Serialize the updated Doctor object back to the XML file
                using (FileStream stream = new FileStream(Files.PatientInfosFile, FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Patient>));
                    serializer.Serialize(stream, patients);
                    stream.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
