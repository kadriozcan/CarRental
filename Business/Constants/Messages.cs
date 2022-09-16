using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        public static string Listed = "The data is listed.";
        public static string Added = "The data is added.";
        public static string Updated = "The data is updated.";
        public static string Deleted = "The data is deleted.";
        public static string CarImagesLimitExceded= "You can upload maximum 5 images for each car.";
        public static string UserRegistered = "User is registered.";
        public static string UserNotFound = "User not found.";
        public static string PasswordError = "Password is not verified.";
        public static string SuccessfulLogin = "Login is successful!";
        public static string AccessTokenCreated = "Access Token is created.";
        public static string UserAlreadyExists = "User already exists.";
        public static string AuthorizationDenied = "Authorization denied.";
        public static string CarNotFound = "Car not found!";
    }
}
