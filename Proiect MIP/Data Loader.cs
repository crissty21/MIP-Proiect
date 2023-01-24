using Proiect_MIP;

namespace Working_With_Data
{
    internal class Data_Loader
    {
        public static int User_Login(Tip type, UserLogin loginUser)
        {
            //get user login from specific file
            Users users = Data.Read_Login(type);
            //use linq to find if our user exists 
            List<UserLogin> listOfUsers = (List<UserLogin>)users.userList.Where(u => u.Username == loginUser.Username && u.Password == loginUser.Password).ToList();
            if(listOfUsers.Count == 0)
            {
                throw new Exception("Unknow Username or Password");
            }
            //return its id if exists
            return listOfUsers.First().Id.Value;
        }
    }
}
